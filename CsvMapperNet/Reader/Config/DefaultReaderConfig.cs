namespace CsvMapperNet.Reader.Config {
	public class DefaultReaderConfig : IReaderConfig {

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public virtual bool SkipHeader => true;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public virtual bool ReadAllField => true;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public virtual int HeaderRow => 0;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public virtual string Delimiter => ",";

	}
}
