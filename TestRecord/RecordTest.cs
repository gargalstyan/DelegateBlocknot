using Console;
namespace TestRecord
{
    [TestClass]
    public class RecordTest
    {
        [TestMethod]
        public void TestParse()
        {
            //Arrange
            Record record = new Record("Jhon","073123344");
            string correctString = record.ToString();
            string incorrectString = "jhon smtih";
            string emptyStr = "";

            //Act

            Record record1 = Record.Parse(correctString);

            // Assert
            Assert.IsTrue(record1.Name == record.Name && record1.Phone == record.Phone);
            Assert.ThrowsException<ArgumentException>(() => Record.Parse(incorrectString));
            Assert.ThrowsException<ArgumentException>(() => Record.Parse(emptyStr));
        }
    }
}