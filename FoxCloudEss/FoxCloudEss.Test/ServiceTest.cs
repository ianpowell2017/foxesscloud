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

        [TestMethod]
        public async Task ConnectAsyncTest()
        {
            var s = new Service();
            await s.ConnectAsync("username", "password");
        }

        [TestMethod]
        public void GenerateHashedPasswordTest()
        {
            var s = new Service();
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
            var deviceId = Guid.NewGuid().ToString();
            var s = new Service();
            await s.ConnectAsync("username", "password");
            var result = await s.GetAddressBookAsync(deviceId);
        }

        [TestMethod]
        public async Task GetReportAsyncTest()
        {
            var deviceId = Guid.NewGuid().ToString();
            var s = new Service();
            await s.ConnectAsync("username", "password");
            var result = await s.GetReportAsync(deviceId, DateTime.Now.AddDays(-1));
        }

        [TestMethod]
        public async Task GetRawAsyncTest()
        {
            var deviceId = Guid.NewGuid().ToString();
            var s = new Service();
            await s.ConnectAsync("username", "password");
            var result = await s.GetRawAsync(deviceId, DateTime.Now.AddHours(-1));

            // Time format - 2022-07-19 16:00:51 BST+0100
        }

        [TestMethod]
        public void ConvertDateTimeToQueryDateTest()
        {
            var s = new Service();
            var result = s.ConvertDateTimeToQueryDate(DateTime.Parse("2022-08-09 15:23:56"));
            Assert.AreEqual("2022", result.Year);
            Assert.AreEqual("08", result.Month);
            Assert.AreEqual("09", result.Day);
        }
    }
}