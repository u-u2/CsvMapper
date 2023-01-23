namespace CsvMapper.Writer.Config {
	public class DefaultWriterConfig : IWriterConfig {

		public virtual string Delimiter => ",";

		public virtual string NewLine => "\r\n";

	}
}
