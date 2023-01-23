namespace CsvMapperNet.Reader.Config {
	public class DefaultReaderConfig : IReaderConfig {

		/// <inheritdoc/>
		public virtual bool SkipHeader => true;

		/// <inheritdoc/>
		public virtual bool ReadAllField => true;

		/// <inheritdoc/>
		public virtual int HeaderRow => 0;

		/// <inheritdoc/>
		public virtual string Delimiter => ",";

	}
}
