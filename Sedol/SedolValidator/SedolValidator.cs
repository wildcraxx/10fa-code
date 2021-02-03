using System.Linq;

namespace SedolValidator
{
    /// <summary>
    /// This class is responsible for validation of SEDOL string
    /// </summary>
    public class SedolValidator : ISedolValidator
    {
        /// <summary>
        /// This method is used to validate SEDOL string
        /// </summary>
        public ISedolValidationResult ValidateSedol(string input)
        {
            bool isUserDefined = !string.IsNullOrEmpty(input) && input[0] == '9';

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)  || (!string.IsNullOrEmpty(input) && input.Length != 7))
            {
                return new SedolValidationResult(input, false, isUserDefined, "Input string was not 7-characters long");
            }

            if (input.Any(ch=>!char.IsLetterOrDigit(ch)))
            {
                return new SedolValidationResult(input, false, isUserDefined, "SEDOL contains invalid characters");
            }

            var isValidCheckDigit = new CheckDigit().GetCheckDigit(input) == (int) char.GetNumericValue(input[6]);

            return new SedolValidationResult(input, isValidCheckDigit, isUserDefined, isValidCheckDigit ? null : "Checksum digit does not agree with the rest of the input");
        }
    }
}
