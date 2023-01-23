namespace CsvMapperNet.Writer.Config {
	public interface IWriterConfig {

		/// <summary>
		/// defines delimiter
		/// </summary>
		string Delimiter { get; }

		/// <summary>
		/// defines new line
		/// </summary>
		string NewLine { get; }

	}
}
