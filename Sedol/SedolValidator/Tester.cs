using System;

namespace SedolValidator
{
    /// <summary>
    /// This is sample Tester class to print output of various inputs to sedol validator.
    /// </summary>
    public static class Tester
    {
        public static void TestSedolValidation(ISedolValidator sedolValidator)
        {
            var listOfTestInputs = new[]
            {
                null, "", "12", "123456789",
                "1234567", 
                "0709954", "B0YBKJ7", 
                "9123451", "9ABCDE8", 
                "9123_51", "VA.CDE8", 
                "9123458", "9ABCDE1"
            };

            foreach (var input in listOfTestInputs)
            {
               var result =  sedolValidator.ValidateSedol(input);
               Console.WriteLine(string.Concat(result.InputString, " | ", result.IsValidSedol, " | ", result.IsUserDefined, " | ", result.ValidationDetails));
            }
            Console.ReadLine();
        }
    }
}
