namespace FoxCloudEss.Test
{
    [TestClass]
    public class ServiceTest
    {
        /*
            ATTR_DEVICE_SN = "deviceSN"
            ATTR_PLANTNAME = "plantName"
            ATTR_MODULESN = "moduleSN"
            ATTR_DEVICE_TYPE = "deviceType"
            ATTR_STATUS = "status"
            ATTR_COUNTRY = "country"
            ATTR_COUNTRYCODE = "countryCode"
            ATTR_CITY = "city"
            ATTR_ADDRESS = "address"
            ATTR_FEEDINDATE = "feedinDate"
            ATTR_LASTCLOUDSYNC = "lastCloudSync"

            BATTERY_LEVELS = {"High": 80, "Medium": 50, "Low": 25, "Empty": 10}
        */

        private const string Username = "Your Username";
        private const string Password = "Your Password";
        private const string DeviceId = "Your device id";

        [TestInitialize]
        public void Initialise()
        {

        }

        private Service getService()
        {
            return new Service();
        }

        [TestMethod]
        public async Task ConnectAsyncTest()
        {
            var s = getService();
            await s.ConnectAsync(Username, Password);
        }

        [TestMethod]
        public void GenerateHashedPasswordTest()
        {
            var s = getService();
            var result = s.GenerateHashedPassword("password");
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
        }

        [TestMethod]
        public void GenerateRandomUserAgentTest()
        {
            var ua = Service.GenerateRandomUserAgent();
            Assert.AreNotEqual(string.Empty, ua);
        }

        [TestMethod]
        public async Task AddressBookTest()
        {
            var s = getService();
            var (success, token) = await s.ConnectAsync(Username, Password);
            var result = await s.GetAddressBookAsync(token, DeviceId);
        }

        [TestMethod]
        public async Task GetReportAsyncTest()
        {
            var s = getService();
            var (success, token) = await s.ConnectAsync(Username, Password); ;
            var result = await s.GetReportAsync(token, DeviceId, DateTime.Now.AddDays(-1));
        }

        [TestMethod]
        public async Task GetRawAsyncTest()
        {
            var s = getService();
            var (success, token) = await s.ConnectAsync(Username, Password);
            var result = await s.GetRawAsync(token, DeviceId, DateTime.Now.AddHours(-1));

            // Time format - 2022-07-19 16:00:51 BST+0100
        }

        [TestMethod]
        public void ConvertDateTimeToQueryDateTest()
        {
            var s = getService();
            var result = s.ConvertDateTimeToQueryDate(DateTime.Parse("2022-08-09 15:23:56"));
            Assert.AreEqual("2022", result.Year);
            Assert.AreEqual("08", result.Month);
            Assert.AreEqual("09", result.Day);
        }
    }
}