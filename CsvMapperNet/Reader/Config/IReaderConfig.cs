namespace CsvMapperNet.Reader.Config {
	public interface IReaderConfig {

		/// <summary>
		/// true skip header.
		/// </summary>
		bool SkipHeader { get; }

		/// <summary>
		/// start at 0.
		/// </summary>
		int HeaderRow { get; }

		/// <summary>
		/// true to validate the length of field and ColumnAttribute count.
		/// </summary>
		bool ValidateFieldLength { get; }

		/// <summary>
		/// defines delimiter.
		/// </summary>
		char Delimiter { get; }

		/// <summary>
		/// the buffer size.
		/// </summary>
		int BufferSize { get; }

	}
}
