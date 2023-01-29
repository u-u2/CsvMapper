namespace CsvMapperNet.Reader.Config {
	public class DefaultReaderConfig : IReaderConfig {

		/// <inheritdoc/>
		public virtual bool SkipHeader => false;

		/// <inheritdoc/>
		public virtual int HeaderRow => 0;

		/// <inheritdoc/>
		public virtual bool SkipFooter => false;

		/// <inheritdoc/>
		public virtual int FooterRowCount => 1;

		/// <inheritdoc/>
		public virtual bool ValidateFieldLength => true;

		/// <inheritdoc/>
		public virtual char Delimiter => ',';

		/// <inheritdoc/>
		public virtual int BufferSize => 8192;

	}
}
