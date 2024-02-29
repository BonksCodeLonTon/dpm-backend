using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Common
{
    public class Constants
    {
        public static readonly string AwsRegion = "ap-southeast-1" ?? throw new Exception("AWS_REGION is not set");

        public static readonly string AppDomain = "localhost:5000";

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
