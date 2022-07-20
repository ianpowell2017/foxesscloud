using FoxCloudEss.DTOs;
using FoxCloudEss.DTOs.AddressBook;
using FoxCloudEss.DTOs.RawData;
using FoxCloudEss.DTOs.Report;
using RestSharp;
using System.Security.Cryptography;
using System.Text;

namespace FoxCloudEss
{
    public partial class Service
    {
        private RestClient _client;

        public Service()
        {
            _client = new RestClient("https://www.foxesscloud.com");
        }

        /// <summary>
        /// Make initial connection to retrieve data
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<(bool, string)> ConnectAsync(string username, string password)
        {
            var hashedPassword = GenerateHashedPassword(password);

            var request = new RestRequest("c/v0/user/login", Method.Post);
            addHeaders(ref request);

            request.AddJsonBody(new AuthRequest { Username = username, HashedPassword = hashedPassword });
            var response = await _client.ExecuteAsync<AuthResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return (true, response.Data.Result.Token);
            }

            return (false, null);
        }

        /// <summary>
        /// Fetches all device data
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<AddressBookResponse> GetAddressBookAsync(string token, string deviceId)
        {
            if (string.IsNullOrEmpty(token))
                throw new ApplicationException("Not logged in");

            var request = new RestRequest("c/v0/device/addressbook", Method.Get);
            request.AddQueryParameter("deviceID", deviceId);
            request.AddHeader("token", token);
            addHeaders(ref request);
            var response = await _client.ExecuteAsync<AddressBookResponse>(request);

            return response.Data;
        }

        /// <summary>
        /// Fetches all data for a specific day hour totals by hour
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="reportDate"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<ReportResponse> GetReportAsync(string token, string deviceId, DateTime reportDate)
        {
            if (string.IsNullOrEmpty(token))
                throw new ApplicationException("Not logged in");

            var request = new RestRequest("c/v0/device/history/report", Method.Post);
            request.AddHeader("token", token);
            addHeaders(ref request);
            request.AddJsonBody(new ReportRequest
            {
                DeviceId = deviceId,
                ReportType = "day",
                Variables = new List<string>
                {
                    "feedin",
                    "generation",
                    "gridConsumption",
                    "chargeEnergyToTal",
                    "dischargeEnergyToTal",
                    "loads"
                },
                QueryDate = ConvertDateTimeToQueryDate(reportDate)
            });
            var response = await _client.ExecuteAsync<ReportResponse>(request);
            return response.Data;
        }

        /// <summary>
        /// Fetches full data dump for the specific hour on a specific day
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="reportDate"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<RawDataResponse> GetRawAsync(string token, string deviceId, DateTime reportDate)
        {
            if (string.IsNullOrEmpty(token))
                throw new ApplicationException("Not logged in");

            var request = new RestRequest("c/v0/device/history/raw", Method.Post);
            request.AddHeader("token", token);
            addHeaders(ref request);
            request.AddJsonBody(new RawDataRequest
            {
                DeviceId = deviceId,
                Variables = new List<string>
                {
                    "generationPower",
                    "feedinPower",
                    "batChargePower",
                    "batDischargePower",
                    "gridConsumptionPower",
                    "loadsPower",
                    "SoC",
                    "batTemperature",
                    "pv1Power",
                    "pv2Power",
                    "pv3Power",
                    "pv4Power"
                },
                TimeSpan = "hour",
                BeginDate = ConvertDateTimeToBeginDate(reportDate)
            });

            var response = await _client.ExecuteAsync<RawDataResponse>(request);
            return response.Data;
        }

        private static void addHeaders(ref RestRequest request)
        {
            var randomUserAgent = GenerateRandomUserAgent();
            request.AddHeader("User-Agent", randomUserAgent);
            request.AddHeader("Accept", "application/json, text/plain, */*");
            request.AddHeader("lang", "en");
            request.AddHeader("sec-ch-ua-platform", "macOS");
            request.AddHeader("Sec-Fetch-Site", "same-origin");
            request.AddHeader("Sec-Fetch-Mode", "cors");
            request.AddHeader("Sec-Fetch-Dest", "empty");
            request.AddHeader("Referer", "https://www.foxesscloud.com/bus/device/inverterDetail?id=xyz&flowType=1&status=1&hasPV=true&hasBattery=false");
            request.AddHeader("Accept-Language", "en-US;q=0.9,en;q=0.8,de;q=0.7,nl;q=0.6");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
        }

        internal string GenerateHashedPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        internal static string GenerateRandomUserAgent()
        {
            var agents = UserAgent.UAgentFactory.GetUserAgents();
            var rnd = RandomNumberGenerator.GetInt32(0, agents.Count);

            return agents[rnd].UAgent;
        }

        internal QueryDate ConvertDateTimeToQueryDate(DateTime dt)
        {
            return new QueryDate
            {
                Year = dt.Year.ToString(),
                Month = $"{dt.Month:00}",
                Day = $"{dt.Day:00}"
            };
        }

        internal BeginDate ConvertDateTimeToBeginDate(DateTime dt)
        {
            return new BeginDate
            {
                Year = dt.Year.ToString(),
                Month = $"{dt.Month:00}",
                Day = $"{dt.Day:00}",
                Hour = $"{dt.Hour:00}"
            };
        }
    }
}