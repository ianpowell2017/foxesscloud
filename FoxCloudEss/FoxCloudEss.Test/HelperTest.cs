namespace FoxCloudEss.Test
{
    [TestClass]
    public class HelperTest
    {
        [DataTestMethod]
        [DataRow("2022-07-19 16:00:51 BST+0100")]
        public void ConvertDateTimeTest(string value)
        {
            var dt = Helper.ConvertTime(value);
        }
    }
}