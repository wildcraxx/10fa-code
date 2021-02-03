using NUnit.Framework;
using SedolValidator;

namespace Sedol.UnitTest
{

    public class CheckDigitTest
    {
        internal ICheckDigit _systemUnderTest;

        [SetUp]
        public void Setup()
        {
            _systemUnderTest = new CheckDigit();
        }

        [Test]
        public void When_CheckDigit_Is_Valid()
        {
            var result = _systemUnderTest.GetCheckDigit("9123458");

            Assert.That(result == 8, Is.True);
        }
    }
}
