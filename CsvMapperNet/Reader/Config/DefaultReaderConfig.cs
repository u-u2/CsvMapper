namespace CsvMapperNet.Reader.Config {
	public class DefaultReaderConfig : IReaderConfig {

		/// <inheritdoc/>
		public virtual bool SkipHeader => true;

		/// <inheritdoc/>
		public virtual int HeaderRow => 0;

		/// <inheritdoc/>
		public virtual bool ValidateFieldLength => true;

		/// <inheritdoc/>
		public virtual char Delimiter => ',';

		public int BufferSize => 8192;

	}
}
