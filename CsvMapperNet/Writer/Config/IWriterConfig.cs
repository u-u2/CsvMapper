namespace CsvMapperNet.Writer.Config {
	public interface IWriterConfig {

		/// <summary>
		/// defines delimiter
		/// </summary>
		char Delimiter { get; }

		/// <summary>
		/// defines new line
		/// </summary>
		string NewLine { get; }

	}
}
