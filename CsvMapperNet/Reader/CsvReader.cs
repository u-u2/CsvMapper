using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvMapperNet.Mapper;
using CsvMapperNet.Reader.Config;
using CsvMapperNet.Reader.Parser;

namespace CsvMapperNet.Reader {
	public class CsvReader : IReader, IDisposable {

		private readonly TextReader _reader;
		private readonly IReaderConfig _config;

		/// <summary>
		/// Create a new CsvReader.
		/// </summary>
		/// <param name="reader"></param>
		public CsvReader(TextReader reader) : this(reader, new DefaultReaderConfig()) {
		}

		/// <summary>
		/// Create a new CsvReader.
		/// </summary>
		/// <param name="reader">reader</param>
		/// <param name="config">config</param>
		public CsvReader(TextReader reader, IReaderConfig config) {
			_reader = reader;
			_config = config;
		}

		/// <inheritdoc/>
		public IEnumerable<string[]> ReadTable() {
			var parser = new CsvParser(_config.Delimiter);
			foreach (var line in ReadLines().Skip(_config.HeaderRow + 1)) {
				yield return parser.ParseLine(line.Span);
			}
		}

		public IEnumerable<string> ReadFields() {
			var parser = new CsvParser(_config.Delimiter);
			foreach (var line in ReadLines().Skip(_config.HeaderRow + 1)) {
				foreach (var field in parser.ParseLine(line.Span)) {
					yield return field;
				}
			}
		}

		/// <inheritdoc/>
		public IEnumerable<T> ReadRecords<T>() where T : new() {
			var creator = new ObjectCreator(_config.ValidateFieldLength);
			foreach (var fields in ReadTable()) {
				yield return creator.Create<T>().Invoke(fields);
			}
		}

		public void Dispose() {
			_reader.Dispose();
		}

		private IEnumerable<ReadOnlyMemory<char>> ReadLines() {
			var buffer = new char[_config.BufferSize];
			var inQuote = false;
			int readBytes;
			var builder = new StringBuilder();
			while ((readBytes = _reader.Read(buffer, 0, buffer.Length)) > 0) {
				var next = 0;
				for (int i = 0; i < readBytes; i++) {
					if (buffer[i] == '"') {
						inQuote = !inQuote;
					}
					if (!inQuote && buffer[i] == '\n') {
						yield return builder.Append(buffer, next, i - next)
							.ToString()
							.AsMemory();
						builder.Clear();
						next = i + 1;
					}
				}
				builder.Append(buffer, next, readBytes - next);
			}
			yield return builder.ToString().AsMemory();
		}

	}
}
