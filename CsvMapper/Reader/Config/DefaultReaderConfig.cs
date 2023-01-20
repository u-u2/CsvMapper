namespace CsvMapper.Reader.Config {
	internal class DefaultReaderConfig : IReaderConfig {


		public bool SkipHeader => true;

		public bool ReadAllField => true;

		public int HeaderRow => 0;

		public string Delimiter => ",";

	}
}
