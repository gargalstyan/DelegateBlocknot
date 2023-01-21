using Console;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParse()
        {
            // Arrange
            Record record = new Record("John", "123456789");

            string correctStr = record.ToString();
            string incorrectStr = "john smith";
            string emptyStr = "";

            // Act
            Record parsedRecord = Record.Parse(correctStr);

            // Assert
            Assert.IsTrue(parsedRecord.Name == record.Name && parsedRecord.Phone == record.Phone);
            Assert.ThrowsException<ArgumentException>(() => Record.Parse(incorrectStr));
            Assert.ThrowsException<ArgumentException>(() => Record.Parse(emptyStr));
        }
    }
}