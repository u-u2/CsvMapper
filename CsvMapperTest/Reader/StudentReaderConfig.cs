using CsvMapper.Reader.Config;

namespace CsvMapperTest2.Reader {
	internal class StudentReaderConfig : IReaderConfig {

		public bool SkipHeader => true;
		public bool ReadAllField => false;
		public int HeaderRow => 5;
		public string Delimiter => ",";

	}
}
