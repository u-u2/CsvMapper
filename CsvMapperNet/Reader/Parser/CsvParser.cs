using System;
using System.Collections.Generic;

namespace CsvMapperNet.Reader.Parser {
	internal class CsvParser : IParser {

		private readonly char _delimiter;

		public CsvParser(char delimiter) {
			_delimiter = delimiter;
		}

		public string[] ParseLine(ReadOnlyMemory<char> lineChunks) {
			var inQuote = false;
			var fields = new List<string>();
			var nextFieldStart = 0;
			for (int i = 0; i < lineChunks.Length; i++) {
				if (lineChunks.Span[i] == '"') {
					inQuote = !inQuote;
				}
				if (!inQuote && lineChunks.Span[i] == ',') {
					fields.Add(lineChunks.Slice(nextFieldStart, i - nextFieldStart).ToString());
					nextFieldStart = i + 1;
				}
				if (i == lineChunks.Length - 1) {
					fields.Add(lineChunks.Slice(nextFieldStart, i + 1 - nextFieldStart).ToString());
				}
			}
			return fields.ToArray();
		}

	}
}
