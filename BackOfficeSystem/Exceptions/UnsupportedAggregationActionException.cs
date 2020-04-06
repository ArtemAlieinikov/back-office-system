namespace BackOfficeSystem.Exceptions
{
	/// <summary>
	/// Represents unsupported aggregation exception validatin exception
	/// </summary>
	public class UnsupportedAggregationActionException : ValidatonException
	{
		/// <summary>
		/// Initialize <seealso cref="UnsupportedAggregationActionException"></seealso> type
		/// </summary>
		/// <param name="aggregationType">Aggregation operation type</param>
		/// <param name="column">Column name against which will be performed aggregation operation</param>
		public UnsupportedAggregationActionException(string aggregationType, string column) 
			: base($"Aggregation type \"{aggregationType}\" against \"{column}\" is not supported")
		{ }
	}
}
