using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGit.Model;

namespace SharpGit.Backbone
{
    static class Status
    {
        public static Dictionary<string,string> TemporaryData { get; set; }
        public static Repository CurrentRepository { get; set; }

        public static User CurrentUser { get; set; }
        public static bool HasUserLoggedIn { get; set; }

        public static bool GetTemporaryRepositoryData(out string url, out string name, out string path)
        {
            url = ""; name = ""; path = "";
            return (TemporaryData != null &&
                TemporaryData.TryGetValue("url", out url) &&
                TemporaryData.TryGetValue("name", out name) &&
                TemporaryData.TryGetValue("path", out path));
        }
        public static void SetTemporaryRepositoryData(string url, string name, string path)
        {
            TemporaryData = new Dictionary<string, string> { { "url", url }, { "name", name }, { "path", path } };
        }
    }
}
