namespace CsvMapper.Writer.Config {
	internal class DefaultWriterConfig : IWriterConfig {

		public string Delimiter => ",";

		public string NewLine => "\r\n";

	}
}
