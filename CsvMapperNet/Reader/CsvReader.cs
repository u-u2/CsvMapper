using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvMapperNet.Attributes;
using CsvMapperNet.Reader.Config;
using CsvMapperNet.Reader.Parser;

namespace CsvMapperNet.Reader {
	public class CsvReader : IReader, IDisposable {

		private readonly TextReader _reader;
		private readonly IReaderConfig _config;
		private readonly IParser _parser;

		/// <summary>
		/// Create a new CsvReader.
		/// </summary>
		/// <param name="reader"></param>
		public CsvReader(TextReader reader) : this(reader, new DefaultReaderConfig()) {
		}

		/// <summary>
		/// Create a new CsvReader.
		/// config is recommended to extend <see cref="DefaultReaderConfig"/>
		/// </summary>
		/// <param name="reader">reader</param>
		/// <param name="config">config</param>
		public CsvReader(TextReader reader, IReaderConfig config) {
			_reader = reader;
			_config = config;
			_parser = new CsvParser(config.Delimiter);
		}

		/// <inheritdoc/>
		public IEnumerable<string[]> ReadFields() {
			if (_config.SkipHeader) {
				for (int i = 0; i < _config.HeaderRow; i++) {
					_reader.ReadLine();
				}
			}
			string line;
			while ((line = _reader.ReadLine()) != null) {
				yield return _parser.ParseLine(line);
			}
		}

		/// <inheritdoc/>
		public IEnumerable<T> ReadRecords<T>() where T : new() {
			var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
				.Select(p => new {
					Ref = p,
					Column = p.GetCustomAttribute<ColumnAttribute>(false).Index,
				})
				.ToArray();
			foreach (var fields in ReadFields()) {
				if (_config.ValidateFieldLength && fields.Length != properties.Length) {
					throw new NotSupportedException($"not match length of the field and ColumnAttribute in {typeof(T)}");
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
