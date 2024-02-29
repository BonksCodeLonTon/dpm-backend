using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Services
{
    public interface IStorageService
    {
        public string GetUploadUrl(string objectKey, string type, long size);
        public string GetUrl(string objectKey);
    }
}
