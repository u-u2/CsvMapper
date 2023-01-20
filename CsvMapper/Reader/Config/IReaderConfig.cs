namespace CsvMapper.Reader.Config {
	public interface IReaderConfig {

		/// <summary>
		/// true skip read header
		/// </summary>
		bool SkipHeader { get; }

		/// <summary>
		/// true number of properties must match number of columns
		/// </summary>
		bool ReadAllField { get; }

		/// <summary>
		/// start at 1
		/// </summary>
		int HeaderRow { get; }

		string Delimiter { get; }

	}
}
