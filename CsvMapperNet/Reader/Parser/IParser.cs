using System;
using System.Collections.Generic;

namespace CsvMapperNet.Reader.Parser {
	internal interface IParser {

		string[] ParseLine(ReadOnlySpan<char> line);

	}
}
