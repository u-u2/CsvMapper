using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

namespace CsvMapperNet.Reader.Parser {
	internal class CsvParser : IParser {

		private readonly char _delimiter;

		public CsvParser(char delimiter) {
			_delimiter = delimiter;
		}

		public string[] ParseLine(ReadOnlySpan<char> line) {
			var indexes = GetSeparatorIndexes(line);
			indexes.Add(line.Length);
			var fields = new string[indexes.Count];
			var next = 0;
			for (int i = 0; i < indexes.Count; i++) {
				var index = indexes[i];
				var length = index - next;
				fields[i] = line.Slice(next, length).ToString();
				next = index + 1;
			}
			return fields;
		}

		private List<int> GetSeparatorIndexes(ReadOnlySpan<char> line) {
			var indexes = new List<int>();
			var inQuote = false;
			for (int i = 0; i < line.Length; i++) {
				var ch = line[i];
				if (ch == '"') {
					inQuote = !inQuote;
				}
				if (!inQuote && ch == _delimiter) {
					indexes.Add(i);
				}
			}
			return indexes;
		}

	}
}
