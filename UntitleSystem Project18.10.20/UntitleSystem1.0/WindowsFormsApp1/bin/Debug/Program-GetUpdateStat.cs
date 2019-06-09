using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace RustUpdateInfoServer
{
    class Program
    {

        private const string UpdateAPI = "https://whenisupdate.com/api.json";
        private const string OxideAPI = "https://api.github.com/repos/OxideMod/Oxide.Rust/releases/latest";
        private const string _GithubUsername = "";
        private const string _GithubPassword = "";

        static void Main(string[] args)
        {
            ReturnData rd = GetUpdate();
            Console.WriteLine("Server Version: {0}", rd.ServerVersion);
            Console.WriteLine("Client Version: {0}", rd.ClientVersion);
            Console.WriteLine("Staging Version: {0}", rd.StagingVersion);
            Console.WriteLine("Oxide Version: {0}", rd.OxideVersion);

            Console.ReadLine();
        }

        private static ReturnData GetUpdate()
        {
            ReturnData rd = new ReturnData();
            WebClient wc = new WebClient();
            string responce = wc.DownloadString(UpdateAPI);
            UpdateInfo updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(responce);

            //Client Update Info
            int latestClientUpdate = 0;
            foreach (Update ClientUpdate in updateInfo.updates)
            {
                if (ClientUpdate.buildId > latestClientUpdate)
                {
                    latestClientUpdate = ClientUpdate.buildId;
                }
            }

            //Server Update Info
            int latestServerUpdate = 0;
            foreach (Serverupdate ServerUpdate in updateInfo.serverUpdates)
            {
                if (ServerUpdate.buildId > latestServerUpdate)
                {
                    latestServerUpdate = ServerUpdate.buildId;
                }
            }

            //Staging Update Info
            int latestStagingUpdate = 0;
            foreach (Stagingupdate StagingUpdate in updateInfo.stagingUpdates)
            {
                if (StagingUpdate.buildId > latestServerUpdate)
                {
                    latestStagingUpdate = StagingUpdate.buildId;
                }
            }

            //Oxide Update Info
            int latestOxideUpdate = 0;
            try
            {
                WebClient oxideWc = new WebClient();
                oxideWc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                if (!string.IsNullOrWhiteSpace(_GithubUsername) || !string.IsNullOrWhiteSpace(_GithubPassword))
                {
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_GithubUsername + ":" + _GithubPassword));
                    oxideWc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                }
                string oxideResponce = oxideWc.DownloadString(OxideAPI);
                long cLimit = Convert.ToInt64(oxideWc.ResponseHeaders["X-RateLimit-Remaining"]);
                if (cLimit > 1)
                {
                    OxideInfo oxideInfo = JsonConvert.DeserializeObject<OxideInfo>(oxideResponce);
                    
                    int oxideVersion = Convert.ToInt32(oxideInfo.name.Replace(".", ""));
                    if (oxideVersion > latestOxideUpdate)
                    {
                        latestOxideUpdate = oxideVersion;
                    }
                }
            }
            catch { }

            rd.ServerVersion = latestClientUpdate;
            rd.ClientVersion = latestClientUpdate;
            rd.StagingVersion = latestStagingUpdate;
            rd.OxideVersion = latestOxideUpdate;

            return rd;
        }
    }

    //ReturnData
    public class ReturnData
    {
        public int ServerVersion { get; set; }
        public int ClientVersion { get; set; }
        public int StagingVersion { get; set; }
        public int OxideVersion { get; set; }
        public int Version { get; set; }
    }

    //API whenisupdate
    public class UpdateInfo
    {
        public string version { get; set; }
        public int latest { get; set; }
        public Update[] updates { get; set; }
        public Serverupdate[] serverUpdates { get; set; }
        public Stagingupdate[] stagingUpdates { get; set; }
        public int estimate { get; set; }
        public int marginLow { get; set; }
        public int marginHigh { get; set; }
    }

    public class Update
    {
        public int timestamp { get; set; }
        public int buildId { get; set; }
        public int forecast { get; set; }
        public int marginLow { get; set; }
        public int marginHigh { get; set; }
    }

    public class Serverupdate
    {
        public int timestamp { get; set; }
        public int buildId { get; set; }
    }

    public class Stagingupdate
    {
        public int timestamp { get; set; }
        public int buildId { get; set; }
    }

    //API Oxide.Rust
    public class OxideInfo
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public bool draft { get; set; }
        public Author author { get; set; }
        public bool prerelease { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public Asset[] assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public string body { get; set; }
    }

    public class Author
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Asset
    {
        public string url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public Uploader uploader { get; set; }
        public string content_type { get; set; }
        public string state { get; set; }
        public int size { get; set; }
        public int download_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string browser_download_url { get; set; }
    }

    public class Uploader
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }
}
