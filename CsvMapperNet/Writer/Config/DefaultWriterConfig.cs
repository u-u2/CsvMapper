namespace CsvMapperNet.Writer.Config {
	public class DefaultWriterConfig : IWriterConfig {


		/// <inheritdoc/>
		public virtual char Delimiter => ',';

		/// <inheritdoc/>
		public virtual string NewLine => "\r\n";

	}
}
