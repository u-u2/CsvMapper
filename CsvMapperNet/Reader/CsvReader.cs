using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using CsvMapperNet.Attributes;
using CsvMapperNet.Reader.Config;

namespace CsvMapperNet.Reader {
	public class CsvReader : IReader, IDisposable {

		private readonly TextReader _reader;
		private readonly IReaderConfig _config;
		private readonly string _separatorPattern;

		public CsvReader(TextReader reader) : this(reader, new DefaultReaderConfig()) {
		}

		public CsvReader(TextReader reader, IReaderConfig config) {
			_reader = reader;
			_config = config;
			_separatorPattern = string.Concat(_config.Delimiter, "(?=(?:[^\"]*\"[^\"]*\")|[^\"]*$)");
		}

		public IEnumerable<string[]> ReadFields() {
			if (_config.SkipHeader) {
				for (int i = 0; i < _config.HeaderRow; i++) {
					_reader.ReadLine();
				}
			}
			string line;
			while ((line = _reader.ReadLine()) != null) {
				yield return Regex.Split(line, _separatorPattern);
			}
		}

		public IEnumerable<T> ReadRecords<T>() where T : new() {
			var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
				.Select(p => new {
					Ref = p,
					Column = p.GetCustomAttribute<ColumnAttribute>(false).Index,
				})
				.ToArray();
			foreach (var fields in ReadFields()) {
				if (_config.ReadAllField) {
					if (properties.Length != fields.Length) {
						throw new NotSupportedException("Column counts not match between entity and fields");
					}
				}
				var obj = new T();
				foreach (var property in properties) {
					var value = Convert.ChangeType(fields[property.Column], property.Ref.PropertyType);
					property.Ref.SetValue(obj, value);
				}
				yield return obj;
			}
		}

		public void Dispose() {
			_reader.Dispose();
		}

	}
}
