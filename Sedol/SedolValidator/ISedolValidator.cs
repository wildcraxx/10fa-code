namespace SedolValidator
{
    /// <summary>
    /// This interface is used to define sedol validation
    /// </summary>
    public interface ISedolValidator
    {
        /// <summary>
        /// This method is used to implement validation logic for sedol
        /// </summary>
        ISedolValidationResult ValidateSedol(string input);
    }
}
