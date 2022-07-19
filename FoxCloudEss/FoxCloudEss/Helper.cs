using System.Globalization;

namespace FoxCloudEss
{
    internal static class Helper
    {
        internal static DateTime ConvertTime(string datetime)
        {
            var parts = datetime.Split(' ');
            var end = parts[2].Split(new[] { '+', '-' });
            var timeDiff = parts[2].Substring(end[0].Length);
            datetime = string.Join(" ", parts[0], parts[1], timeDiff);

            try
            {
                var dt = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss zzz", CultureInfo.InvariantCulture);
                return dt;
            }
            catch (FormatException fex)
            {
                throw new FormatException($"Unable to parse '{datetime}'", fex);
            }
        }
    }
}
