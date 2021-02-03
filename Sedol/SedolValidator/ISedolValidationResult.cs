namespace SedolValidator
{
    /// <summary>
    /// This interface define contract for SedolValidationResult
    /// </summary>
    public interface ISedolValidationResult
    {
        string InputString { get; }
        bool IsValidSedol { get; }
        bool IsUserDefined { get; }
        string ValidationDetails { get; }
    }
}
