using System;
using System.Collections.Generic;
using System.IO;
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
		/// config is recommended to extend <see cref="DefaultReaderConfig"/>
		/// </summary>
		/// <param name="reader">reader</param>
		/// <param name="config">config</param>
		public CsvReader(TextReader reader, IReaderConfig config) {
			_reader = reader;
			_config = config;
		}

		/// <inheritdoc/>
		public IEnumerable<string[]> ReadFields() {
			var parser = new CsvParser(_config.Delimiter);
			if (_config.SkipHeader) {
				for (int i = 0; i <= _config.HeaderRow; i++) {
					_reader.ReadLine();
				}
			}
			string line;
			while ((line = _reader.ReadLine()) != null) {
				yield return parser.ParseLine(line);
			}
		}

		/// <inheritdoc/>
		public IEnumerable<T> ReadRecords<T>() where T : new() {
			var creator = new ObjectCreator(_config.ValidateFieldLength);
			foreach (var fields in ReadFields()) {
				yield return creator.Create<T>().Invoke(fields);
			}
		}

		public void Dispose() {
			_reader.Dispose();
		}

	}
}
