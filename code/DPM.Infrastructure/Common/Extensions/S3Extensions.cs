using Amazon.S3.Model;

namespace DPM.Infrastructure.Common.Extensions
{
    public static class S3Extensions
    {
        public static string ReadObjectAsString<T>(T obj) where T : GetObjectResponse
        {
            using (StreamReader reader = new StreamReader(obj.ResponseStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}