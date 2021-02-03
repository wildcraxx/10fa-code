namespace SedolValidator
{
    /// <summary>
    ///  This class is responsible for check digit calculation
    /// </summary>
    public class CheckDigit : ICheckDigit
    {
        private readonly int[] _weightings = { 1, 3, 1, 7, 3, 9 };

        /// <summary>
        /// This method is used to calculate last check digit of SEDOL
        /// </summary>
        public int GetCheckDigit(string input)
        {
            return (10 - CalculateChecksum(input) % 10) % 10;
        }

        /// <summary>
        /// This method is used to calculate checksum using 6 characters of sedol
        /// </summary>
        private int CalculateChecksum(string input)
        {
            int result = 0;

            for (int i = 0; i <= input.Length - 2; i++)
            {
                var value = char.IsLetter(input[i]) 
                                        ? (char.ToUpper(input[i]) - 64) + 9
                                        : (int)char.GetNumericValue(input[i]);

                result = result + _weightings[i] * value;
            }

            return result;
        }

    }
}
