namespace CsvMapperNet.Reader.Config {
	public interface IReaderConfig {

		/// <summary>
		/// true skip read header
		/// </summary>
		bool SkipHeader { get; }

		/// <summary>
		/// start at 1
		/// </summary>
		int HeaderRow { get; }

		/// <summary>
		/// true read all field
		/// </summary>
		bool ReadAllField { get; }

		/// <summary>
		/// defines delimiter
		/// </summary>
		string Delimiter { get; }

	}
}
