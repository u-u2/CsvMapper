using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvMapperNet.Attributes;
using CsvMapperNet.Writer.Config;

namespace CsvMapperNet.Writer {
	public class CsvWriter : IWriter, IDisposable {

		private readonly TextWriter _writer;
		private readonly IWriterConfig _config;

		private int _currentRow;

		public CsvWriter(TextWriter writer) : this(writer, new DefaultWriterConfig()) {
		}

		public CsvWriter(TextWriter writer, IWriterConfig config) {
			_writer = writer;
			_config = config;
			_currentRow = 0;
			_writer.NewLine = _config.NewLine;
		}

		public void WriteFields(IEnumerable<string> fields) {
			if (_currentRow > 0) {
				_writer.WriteLine();
			}
			var sb = new StringBuilder();
			foreach (var field in fields) {
				sb.Append(field)
					.Append(_config.Delimiter);
			}
			sb.Remove(sb.Length - 1, 1);
			_writer.Write(sb.ToString());
			_currentRow++;
		}

		public void WriteHeader<T>(T t) {
			var headers = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
				.Select(p => p.GetCustomAttribute<ColumnAttribute>(false).Name);
			WriteFields(headers);
		}

		public void WriteRecord<T>(T t) {
			var fields = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.GetCustomAttribute<ColumnAttribute>(false) != null)
				.Select(p => p.GetValue(t))
				.Select(o => o != null ? o.ToString() : string.Empty);
			WriteFields(fields);
		}

		public void WriteRecords<T>(IEnumerable<T> records) {
			foreach (var record in records) {
				WriteRecord(record);
			}
		}

		public void Dispose() {
			_writer.Dispose();
		}

	}
}
