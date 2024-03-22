using System.Globalization;
using System.Text.Json;

namespace DPM.Infrastructure.Common
{
    public class Constants
    {
        public static readonly string AwsRegion = "ap-southeast-1";

        public static readonly string AppDomain = "localhost:5000";

        public static readonly string TimestampServerUrl = @"http://timestamp.digicert.com";

        public static readonly CultureInfo[] SupportedCultures = new[]
        {
      new CultureInfo("en-US"),
      new CultureInfo("vi-VN"),
    };

        public static readonly CultureInfo DefaultCulture = new("en-US");

        public static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };
    }
}