using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvMapperNet.Delegates;
using CsvMapperNet.Writer.Config;
using CsvMapperNet.Writer.Decorator;

namespace CsvMapperNet.Writer {
	public class CsvWriter : IWriter, IDisposable {

		private readonly TextWriter _writer;
		private readonly IWriterConfig _config;

		private int _currentRow;

		/// <summary>
		/// Create a new CsvWriter.
		/// Use <see cref="DefaultWriterConfig"/>
		/// </summary>
		/// <param name="writer">writer</param>
		public CsvWriter(TextWriter writer) : this(writer, new DefaultWriterConfig()) {
		}

		/// <summary>
		/// Create a new CsvWriter.
		/// config is recommended to extend <see cref="DefaultWriterConfig"/>
		/// </summary>
		/// <param name="writer">writer</param>
		/// <param name="config">config</param>
		public CsvWriter(TextWriter writer, IWriterConfig config) {
			_writer = writer;
			_config = config;
			_currentRow = 0;
			_writer.NewLine = _config.NewLine;
		}

		/// <inheritdoc/>
		public void WriteFields(IEnumerable<string> fields) {
			if (_currentRow > 0) {
				_writer.WriteLine();
			}
			var sb = new StringBuilder();
			var decorator = new FieldDecorator(_config.Delimiter);
			foreach (var field in fields) {
				var decorated = decorator.Decorate(field);
				sb.Append(decorated).Append(_config.Delimiter);
			}
			sb.Remove(sb.Length - 1, 1);
			_writer.Write(sb.ToString());
			_currentRow++;
		}

		/// <inheritdoc/>
		public void WriteHeader<T>(T t) {
			var creator = new FieldCreator();
			WriteFields(creator.CreateHeaderCreator<T>().Invoke(t));
		}

		/// <inheritdoc/>
		public void WriteRecord<T>(T t) {
			var creator = new FieldCreator();
			WriteFields(creator.CreateRecordCreator<T>().Invoke(t));
		}

		/// <inheritdoc/>
		public void WriteRecords<T>(IEnumerable<T> records) {
			var creator = new FieldCreator().CreateRecordCreator<T>();
			foreach (var record in records) {
				WriteFields(creator.Invoke(record));
			}
		}

		public void Dispose() {
			_writer.Dispose();
		}

	}
}
