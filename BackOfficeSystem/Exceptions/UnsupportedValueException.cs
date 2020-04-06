namespace BackOfficeSystem.Exceptions
{
	/// <summary>
	/// Represents unsupported value exception validatin exception
	/// </summary>
	public class UnsupportedValueException : ValidatonException
	{
		/// <summary>
		/// Initializes <seealso cref="UnsupportedValueException"></seealso> type
		/// </summary>
		/// <param name="value">Value that was used</param>
		public UnsupportedValueException(string value) : base($"Unsupported value \"{value}\"")
		{ }
	}
}
