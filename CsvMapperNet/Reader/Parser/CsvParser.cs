using System.Collections.Generic;

namespace CsvMapperNet.Reader.Parser {
	internal class CsvParser : IParser {

		private readonly char _delimiter;

		public CsvParser(char delimiter) {
			_delimiter = delimiter;
		}

		public string[] ParseLine(string line) {
			var delimiterIndexes = new List<int>();
			for (int i = 0; i < line.Length; i++) {
				if (line[i] == '"') {
					i++;
					while (line[i] != '"') {
						i++;
					}
				}
				if (line[i] == _delimiter) {
					delimiterIndexes.Add(i);
				}
			}
			// sets last delimiter position as line.Length 
			delimiterIndexes.Add(line.Length);
			var fields = new string[delimiterIndexes.Count];
			var start = 0;
			for (int i = 0; i < delimiterIndexes.Count; i++) {
				var index = delimiterIndexes[i];
				var length = index - start;
				fields[i] = line.Substring(start, length);
				start = index + 1;
			}
			return fields;
		}
	}
}
