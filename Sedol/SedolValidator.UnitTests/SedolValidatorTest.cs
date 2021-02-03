using NUnit.Framework;

namespace SedolValidator.UnitTest
{
    public class Tests
    {
        internal ISedolValidator _systemUnderTest;

        [SetUp]
        public void Setup()
        {
            _systemUnderTest = new SedolValidator();
        }

        [Test]
        public void When_Input_String_Is_Null_Or_EmptyString_Or_More_Than_7_Characters()
        {
            var result = _systemUnderTest.ValidateSedol(null);

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Input string was not 7-characters long", Is.True);

            result = _systemUnderTest.ValidateSedol("");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Input string was not 7-characters long", Is.True);

            result = _systemUnderTest.ValidateSedol("12");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Input string was not 7-characters long", Is.True);

            result = _systemUnderTest.ValidateSedol("123456789");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Input string was not 7-characters long", Is.True);
        }

        [Test]
        public void When_Checksum_Is_Invalid_For_Non_User_Defined_Sedol()
        {
        
            var result = _systemUnderTest.ValidateSedol("1234567");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Checksum digit does not agree with the rest of the input", Is.True);
        }

        [Test]
        public void When_Checksum_Is_Valid_For_Non_User_Defined_Sedol()
        {

            var result = _systemUnderTest.ValidateSedol("0709954");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.True);
            Assert.That(result.ValidationDetails, Is.Null);

            result = _systemUnderTest.ValidateSedol("B0YBKJ7");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.True);
            Assert.That(result.ValidationDetails, Is.Null);
        }

        [Test]
        public void When_Checksum_Is_Invalid_For_User_Defined_Sedol()
        {
            var result = _systemUnderTest.ValidateSedol("9123451");

            Assert.That(result.IsUserDefined, Is.True);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Checksum digit does not agree with the rest of the input", Is.True);

            result = _systemUnderTest.ValidateSedol("9ABCDE8");

            Assert.That(result.IsUserDefined, Is.True);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "Checksum digit does not agree with the rest of the input", Is.True);
        }

        [Test]
        public void When_Invalid_Characters_Exist_In_Sedol()
        {
            var result = _systemUnderTest.ValidateSedol("9123_51");

            Assert.That(result.IsUserDefined, Is.True);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "SEDOL contains invalid characters",Is.True);

            result = _systemUnderTest.ValidateSedol("VA.CDE8");

            Assert.That(result.IsUserDefined, Is.False);
            Assert.That(result.IsValidSedol, Is.False);
            Assert.That(result.ValidationDetails == "SEDOL contains invalid characters", Is.True);

        }

        [Test]
        public void When_Checksum_Is_Valid_For_User_Defined_Sedol()
        {
            var result = _systemUnderTest.ValidateSedol("9123458");

            Assert.That(result.IsUserDefined, Is.True);
            Assert.That(result.IsValidSedol, Is.True);
            Assert.That(result.ValidationDetails, Is.Null);

            result = _systemUnderTest.ValidateSedol("9ABCDE1");

            Assert.That(result.IsUserDefined, Is.True);
            Assert.That(result.IsValidSedol, Is.True);
            Assert.That(result.ValidationDetails, Is.Null);
        }
    }
}