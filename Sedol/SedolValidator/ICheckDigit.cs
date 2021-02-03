namespace SedolValidator
{
    /// <summary>
    /// This interface is responsible for check digit calculation
    /// </summary>
    public interface ICheckDigit
    {
        /// <summary>
        /// Use this method to implement check digit calculation.
        /// </summary>
        int GetCheckDigit(string input);
    }
}
