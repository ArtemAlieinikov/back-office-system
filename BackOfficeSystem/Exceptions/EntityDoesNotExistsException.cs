namespace BackOfficeSystem.Exceptions
{
	/// <summary>
	/// Represents entity does not exists exception
	/// </summary>
	public class EntityDoesNotExistsException : ValidatonException
	{
		/// <summary>
		/// Initialize <seealso cref="EntityDoesNotExistsException"></seealso> type
		/// </summary>
		/// <param name="id">Entity id</param>
		public EntityDoesNotExistsException(int id) : base($"Entity with \"{id}\" id does not exist")
		{ }
	}
}
