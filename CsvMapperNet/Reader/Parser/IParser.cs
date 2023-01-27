using System;

namespace CsvMapperNet.Reader.Parser {
	internal interface IParser {

		string[] ParseLine(ReadOnlyMemory<char> lineChunks);

	}
}
