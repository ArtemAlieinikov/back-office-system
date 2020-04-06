using System;

namespace BackOfficeSystem.Exceptions
{
	/// <summary>
	/// Represents common validation exception
	/// </summary>
	public class ValidatonException : Exception
	{
		/// <summary>
		/// Initialize <seealso cref="ValidatonException"></seealso> type
		/// </summary>
		/// <param name="message">Exception message</param>
		public ValidatonException(string message) : base(message)
		{ }
	}
}
