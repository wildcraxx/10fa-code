namespace SedolValidator
{
    /// <summary>
    /// This class is used to interpret sedol validation result
    /// </summary>
    public class SedolValidationResult : ISedolValidationResult
    {
        public SedolValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            InputString = inputString;
            IsValidSedol = isValidSedol;
            IsUserDefined = isUserDefined;
            ValidationDetails = validationDetails;
        }

        public string InputString { get; }
        public bool IsValidSedol { get; }
        public bool IsUserDefined { get; }
        public string ValidationDetails { get; }
    }
}