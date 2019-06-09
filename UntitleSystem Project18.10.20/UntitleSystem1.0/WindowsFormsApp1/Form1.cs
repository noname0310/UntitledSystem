#region Using

using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.Drawing;
using System.Collections.Generic;
//using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
//using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using System.Text;

#endregion

namespace UntitleSystem
{
    public partial class MainForm : Form
    {
        #region Function

        #region FileInfoValue

        static string DataFileName = "UntitleSystem.json";
        string SettingFileLink = Application.StartupPath + @"\UntitleSetting.json";
        string DefaultDataFileLink = @"C:\Users\Hosting04\Desktop\Server\rustds\oxide\data\" + DataFileName;
        string fileFullName;
        string CorrentDate;
        public static string ServerVer;
        bool FileDownLoadFinishDetect = false;
        bool whileupdate = false;
        int repeatUpdateDataLoad = 0;
        int DownTimeoutCount = 0;

        #endregion

        #region FileSystemFValue

        StreamReader SettingFileRead;
        StreamReader DataFileRead;
        StreamWriter SettingFileWrite;
        StreamWriter DataFileWrite;
        StreamReader CheckFile;
        JObject DataFilejsonObject = JObject.Parse("{}");
        JObject SettingFilejsonObject = JObject.Parse("{}");
        JObject Filetry = JObject.Parse("{}");
        JObject ListOfResetFiles = new JObject();
        JObject ListOfResetDay = new JObject();

        #endregion

        #endregion

        #region FileDownloadSystem
        private delegate void CSafeSetText(string text);
        private delegate void CSafeSetMaximum(Int32 value);
        private delegate void CSafeSetValue(Int32 value);

        //private CSafeSetText csst;
        private CSafeSetMaximum cssm;
        private CSafeSetValue cssv;
        private WebClient wc;
        private Boolean setBaseSize;
        private Boolean nowDownloading;

        void DownloadOxide()
        {
            PrintOnRichText("oxide를 다운합니다");

            if (nowDownloading)
            {
                PrintOnRichText("Error-Oxide가 이미 다운로드가 진행 중입니다.");
                return;
            }

            String remoteAddress = @"https://umod.org/games/rust/download";
            if (String.IsNullOrEmpty(remoteAddress))
            {
                PrintOnRichText("주소가 입력되지 않았습니다.");
                return;
            }
            DownTimeoutCount = 20;
            DownloadTimeoutTimer.Start();
            
            // 파일이 저장될 위치를 저장한다.
            String fileName = String.Format(Application.StartupPath + @"\Oxide.Rust.zip");

            // 폴더가 존재하지 않는다면 폴더를 생성한다.
            if (!System.IO.Directory.Exists(Application.StartupPath))
                System.IO.Directory.CreateDirectory(Application.StartupPath);

            try
            {

                // C 드라이브 밑의 downloadFiles 폴더에 파일 이름대로 저장한다.
                wc.DownloadFileAsync(new Uri(remoteAddress), fileName);
                // 다운로드 중이라는걸 알리기 위한 값을 설정하고,
                // 프로그레스바의 크기를 0으로 만든다.
                updateProgressbar.Value = 0;
                setBaseSize = false;
                nowDownloading = true;
                //btnStart.Enabled = false;
                //txtAddress.Enabled = false;

            }
            catch (Exception ex)
            {
                PrintOnRichText(ex.Message + ex.GetType().FullName);
            }
        }

        void CrossSafeSetValueMethod(Int32 value)
        {
            if (updateProgressbar.InvokeRequired)
            {
                updateProgressbar.Invoke(cssm, value);
            }
            else
                updateProgressbar.Value = value;
        }
        void CrossSafeSetMaximumMethod(Int32 value)
        {
            if (updateProgressbar.InvokeRequired)
                updateProgressbar.Invoke(cssm, value);
            else
                updateProgressbar.Maximum = value;
        }
        /*void CrossSafeSetTextMethod(String text)
        {
            if (this.InvokeRequired)
                this.Invoke(csst, text);
            else
                this.Text = text;
        }*/

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 이벤트를 연결한다.
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(fileDownloadCompleted);
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(fileDownloadProgressChanged);
        }

        void fileDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownTimeoutCount = 20;
            // e.BytesReceived
            //   받은 데이터의 크기를 저장합니다.

            // e.TotalBytesToReceive
            //   받아야 할 모든 데이터의 크기를 저장합니다.

            // 프로그레스바의 최대 크기가 정해지지 않은 경우,
            // 받아야 할 최대 데이터 량으로 설정한다.
            if (!setBaseSize)
            {
                CrossSafeSetMaximumMethod((int)e.TotalBytesToReceive);
                setBaseSize = true;
            }

            // 받은 데이터 량을 나타낸다.
            CrossSafeSetValueMethod((int)e.BytesReceived);

            // 받은 데이터 / 받아야할 데이터 (퍼센트) 로 나타낸다.
            PrintOnRichText(String.Format("{0:N0} / {1:N0} ({2:P})", e.BytesReceived, e.TotalBytesToReceive, (Double)e.BytesReceived / (Double)e.TotalBytesToReceive));
        }

        void fileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                nowDownloading = false;
                PrintOnRichText("Error-timeout");

                // Delete a file by using File class static method...
                if (System.IO.File.Exists(Application.StartupPath + @"\Oxide.Rust.zip"))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.
                    try
                    {
                        System.IO.File.Delete(Application.StartupPath + @"\Oxide.Rust.zip");
                    }
                    catch (Exception ex)
                    {
                        PrintOnRichText(ex.Message + ex.GetType().FullName);
                    }
                }

                DownloadOxide();

                return;
            }
            nowDownloading = false;
            //btnStart.Enabled = true;
            //txtAddress.Enabled = true;
            try
            {
                DeCompression(Application.StartupPath + @"\Oxide.Rust.zip", GetCutLink(SettingFilejsonObject["Link"].ToString(), 3));
            }
            catch
            {
                PrintOnRichText("Error-옥사이드 파일 복사 실패, 서버가 열려있는것 같습니다");
            }
            PrintOnRichText("Oxide파일 다운로드 완료!");
            DownloadTimeoutTimer.Stop();

            // Delete a file by using File class static method...
            if (System.IO.File.Exists(Application.StartupPath + @"\Oxide.Rust.zip"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(Application.StartupPath + @"\Oxide.Rust.zip");
                }
                catch (Exception ex)
                {
                    PrintOnRichText(ex.Message + ex.GetType().FullName);
                }
            }

            hidePrograssBar();
            whileupdate = false;

            ReadSettingFlie(SettingFileLink);
            RunProcess(SettingFilejsonObject["BatchFileLink"].ToString());
            //initServerupdate();
        }
        #endregion

        #region RunProcess

        #region ServerUpdateProcess

        Process ServerProcess;

        private void initServerupdate()
        {
            if (CheckDataFileExist() == false)
            {
                PrintOnRichText("ServerUpdate-데이터 파일이 지정됀 경로에 없습니다");
            }
            else
            {
                PrintOnRichText("서버 업데이트중 입니다");
                updateProgressbar.Value = 0;
                updateProgressbar.Maximum = 100;

                CheckForIllegalCrossThreadCalls = false; //에러방지
                ServerProcess = new Process(); //변수에 Process 값 대입
                ServerProcess.StartInfo.FileName = "cmd.exe";
                //ServerProcess.StartInfo.WorkingDirectory = GetCutLink(SettingFilejsonObject["Link"].ToString(), 4);//cmd실행경로 수정
                ServerProcess.StartInfo.WorkingDirectory = Application.StartupPath;

                ServerProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //검은창 안뜨게
                ServerProcess.EnableRaisingEvents = true; //이벤트가 발생되도록
                ServerProcess.StartInfo.UseShellExecute = false;
                ServerProcess.StartInfo.RedirectStandardOutput = true; //서버 출력 메세지를 받아올지
                ServerProcess.StartInfo.RedirectStandardInput = true; //명령어를 입력할수 있도록 할지
                ServerProcess.StartInfo.CreateNoWindow = true; //창이 안뜨게
                ServerProcess.StartInfo.RedirectStandardError = true; //에러 출력 메세지를 받아올지

                ServerProcess.Exited += new EventHandler(ServerExit); //서버가 종료되었을때
                ServerProcess.OutputDataReceived += new DataReceivedEventHandler(ServerOut); //서버에서 출력메세지가 생겼을때
                ServerProcess.ErrorDataReceived += new DataReceivedEventHandler(ServerOut); //서버에서 오류메세지가 생겼을때

                ServerProcess.Start(); //서버 시작
                ServerProcess.BeginErrorReadLine(); //에러 메세지 가져오기 시작
                ServerProcess.BeginOutputReadLine(); //서버 출력 메세지 가져오기 시작

                ReadSettingFlie(SettingFileLink);

                ServerProcess.StandardInput.Write(@"cd steam
                                                      steamcmd.exe +@ShutdownOnFailedCommand 1
                                                      @NoPromptForPassword 1
                                                      login anonymous 
                                                      force_install_dir "+ GetCutLink(SettingFilejsonObject["Link"].ToString(), 3) + @"
                                                      app_update 258550 validate 
                                                      quit
                                                      cd ..
                                                      exit" + Environment.NewLine);
                //ServerUpdateProcess.WaitForExit();
                //DownloadOxide();
            }
        }

        private void ServerExit(object sender, EventArgs e)
        {
            //ServerUpdateProcess.StandardInput.Close();
            ServerProcess.Close();
            ServerProcess.Dispose();
            //ServerUpdateProcess.CloseMainWindow();
            PrintOnRichText("ServerUpdate-업데이트 프로세스가 종료되었습니다.");
            //DownloadOxide();
            FileDownLoadFinishDetect = true;
        }

        private void ServerOut(object sender, DataReceivedEventArgs e)
        {   
            try
            {
                consoleRichTextbox.AppendText("\n" + e.Data);

                if (e.Data.Substring(0, 41) == " Update state (0x5) validating, progress:")
                {
                    //PrintOnRichText(e.Data.Substring(42, 2));
                    if(e.Data.Substring(43, 1) == ".")
                    {
                        updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(42, 1));
                    }
                    else
                    {
                        if (e.Data.Substring(44, 1) == ".")
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(42, 2));
                        }
                        else
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(42, 3));
                        }
                    }
                }

                if (e.Data.Substring(0, 43) == " Update state (0x61) downloading, progress:")
                {
                    //PrintOnRichText(e.Data.Substring(42, 2));
                    if (e.Data.Substring(45, 1) == ".")
                    {
                        updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(44, 1));
                    }
                    else
                    {
                        if (e.Data.Substring(46, 1) == ".")
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(44, 2));
                        }
                        else
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(44, 3));
                        }
                    }
                }

                if (e.Data.Substring(0, 45) == " Update state (0x11) preallocating, progress:")
                {
                    //PrintOnRichText(e.Data.Substring(42, 2));
                    if (e.Data.Substring(47, 1) == ".")
                    {
                        updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(46, 1));
                    }
                    else
                    {
                        if (e.Data.Substring(48, 1) == ".")
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(46, 2));
                        }
                        else
                        {
                            updateProgressbar.Value = Convert.ToInt16(e.Data.Substring(46, 3));
                        }
                    }
                }

            }
            catch { }
        }

        #endregion

        #region RunAnyProcessMethod

        public void RunProcess(string ProcessFileDirectory)
        {
            try
            {
                PrintOnRichText(GetCutLink(SettingFilejsonObject["Link"].ToString(), 4) + @"\" + Path.GetFileName(ProcessFileDirectory) + " 프로세스를 실행합니다.");
                ServerProcess = new Process(); //변수에 Process 값 대입
                ServerProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(ProcessFileDirectory);
                ServerProcess.StartInfo.FileName = Path.GetFileName(ProcessFileDirectory);
                ServerProcess.Start(); //서버 시작
            }
            catch
            {
                PrintOnRichText("RunProcess-배치 파일을 실행시키는데 문제가 발생했습니다");
                PrintOnRichText("RunProcess-배치 파일 경로가 설정 되어있는지 확인해주세요");
            }
        }

        #endregion

        #endregion

        #region GetServerVerToNet

        class GetUpdateVer
        {

            private const string UpdateAPI = "https://whenisupdate.com/api.json";
            private const string OxideAPI = "https://api.github.com/repos/OxideMod/Oxide.Rust/releases/latest";
            private const string _GithubUsername = "";
            private const string _GithubPassword = "";

            public static string GetServerUpdate()
            {
                ReturnData rd = GetUpdate();
                /*Console.WriteLine("Server Version: {0}", rd.ServerVersion);
                Console.WriteLine("Client Version: {0}", rd.ClientVersion);
                Console.WriteLine("Staging Version: {0}", rd.StagingVersion);
                Console.WriteLine("Oxide Version: {0}", rd.OxideVersion);

                Console.ReadLine();*/

                return rd.ServerVersion.ToString();
            }

            private static ReturnData GetUpdate()
            {
                ReturnData rd = new ReturnData();
                WebClient wc = new WebClient();
                try
                {
                    string responce = wc.DownloadString(UpdateAPI);
                    UpdateInfo updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(responce);

                    //Client Update Info
                    int latestClientUpdate = 0;
                    foreach (UpdateN ClientUpdate in updateInfo.updates)
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
                catch
                {
                    rd.ServerVersion = 0;
                    rd.ClientVersion = 0;
                    rd.StagingVersion = 0;
                    rd.OxideVersion = 0;
                    return rd;
                }
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
            public UpdateN[] updates { get; set; }
            public Serverupdate[] serverUpdates { get; set; }
            public Stagingupdate[] stagingUpdates { get; set; }
            public int estimate { get; set; }
            public int marginLow { get; set; }
            public int marginHigh { get; set; }
        }

        public class UpdateN
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
        #endregion

        #region TextModifyMethod

        public void PrintOnRichText(string msg)
        {
            consoleRichTextbox.AppendText("\n" + System.DateTime.Now.ToString("[HH:mm:ss] ") + msg);
        }

        #region LinkModify

        /*
        private string GetLinkCutFrontSpace(string Link)
        {
            int countdic = 0;

            for (int i = 1; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
            {
                //PrintOnRichText(Link.Substring(Link.Length - i, 1));
                if (Link.Substring(Link.Length - i, 1) == @"\")//링크의 경계부분이면
                {
                    countdic++;
                }
            }
            if (countdic > 0)
            {
                for (int i = 0; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
                {
                    //PrintOnRichText(Link.Substring(i,1));
                    //PrintOnRichText(i.ToString());
                    if (Link.Substring(i, 1) == @"\")//링크의 경계부분이면
                    {
                        Link = Link.Substring(0, i - 1) + Link.Substring(i);//잘라서 저장
                        PrintOnRichText(Link.Substring(0, i) + Link.Substring(i));
                        break;
                    }
                }
                return Link;
            }
            else
            {
                return Link;
            }
        }*/

        private string GetFileNameToLink(string Link)//링크
        {
            int countdic = 0;

            for (int i = 1; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
            {
                //PrintOnRichText(Link.Substring(Link.Length - i, 1));
                if (Link.Substring(Link.Length - i, 1) == @"\")//링크의 경계부분이면
                {
                    countdic++;
                }
            }
            if (!(countdic == 0))
            {
                for (int i = 1; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
                {
                    //PrintOnRichText(Link.Substring(Link.Length - i, 1));
                    if (Link.Substring(Link.Length - i, 1) == @"\")//링크의 경계부분이면
                    {
                        Link = Link.Substring(Link.Length - (i-1));//잘라서 저장
                        //PrintOnRichText(i.ToString());
                        //PrintOnRichText((Link.Length - i).ToString());
                        //PrintOnRichText(Link.Substring(Link.Length - (i-1)));
                        break;
                    }
                }
                return Link;
            }
            else
            {
                PrintOnRichText("GetCutLink-데이터 파일 경로가 잘못되었습니다");
                return Link;
            }
        }

        private string GetCutLink(string Link, int cutcount)//링크,자를휫수
        {
            int countdic = 0;

            for (int i = 1; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
            {
                //PrintOnRichText(Link.Substring(Link.Length - i, 1));
                if (Link.Substring(Link.Length - i, 1) == @"\")//링크의 경계부분이면
                {
                    countdic++;
                }
            }
            if (countdic >= 4)
            {
                for (int repeatcut = 1; repeatcut <= cutcount; repeatcut++)//자를 수만큼 반복
                {
                    for (int i = 1; i <= Link.Length; i++)//링크 길이만큼반복해서 스캔
                    {
                        //PrintOnRichText(Link.Substring(Link.Length - i, 1));
                        if (Link.Substring(Link.Length - i, 1) == @"\")//링크의 경계부분이면
                        {
                            Link = Link.Substring(0, Link.Length - i);//잘라서 저장
                            break;
                        }
                    }
                }
                return Link;
            }
            else
            {
                PrintOnRichText("GetCutLink-데이터 파일 경로가 잘못되었습니다");
                return "Error";
            }
        }

        private string LinkcutStringReturn(string Linktostring)//링크 가운데 잘라서 출력
        {
            string Linklength = Linktostring;
            if (Linklength.Length <= 40)
            {
                return Linktostring;
            }
            else
            {
                int cutLength = Linklength.Length - 30;
                return Linktostring.Substring(0, 5) + "..." + Linktostring.Substring(cutLength);
            }
        }

        private void Linkcut(string Linktostring)//링크 가운데 잘라서 출력
        {
            string Linklength = Linktostring;
            if (Linklength.Length <= 40)
            {
                correntfilelocation.Text = Linktostring;
            }
            else
            {
                int cutLength = Linklength.Length - 30;
                correntfilelocation.Text = Linktostring.Substring(0, 5) + "..." + Linktostring.Substring(cutLength);
            }
            PrintOnRichText("LinkCut-링크 표시 레이블이 업데이트 되었습니다");
        }

        #endregion
        
        #endregion

        #region FileSystem

        #region ReadFile
        public string ReadSettingInLink(string Link)//세팅값에서 링크값만 가져오기
        {
            SettingFileRead = new StreamReader(Link);//세팅값읽기
            SettingFilejsonObject = JObject.Parse(SettingFileRead.ReadToEnd());
            SettingFileRead.Close();
            return SettingFilejsonObject["Link"].ToString();//링크값 스트링으로 리턴
        }

        public void ReadDataFlie(string Link)//세팅값과 데이터값 변수에저장
        {
            SettingFileRead = new StreamReader(Link);//세팅값읽기
            SettingFilejsonObject = JObject.Parse(SettingFileRead.ReadToEnd());//변수에저장
            SettingFileRead.Close();
            DataFileRead = new StreamReader(SettingFilejsonObject["Link"].ToString());//데이터값읽기
            DataFilejsonObject = JObject.Parse(DataFileRead.ReadToEnd());//변수에저장
            DataFileRead.Close();
        }

        public void ReadSettingFlie(string Link)//세팅값 변수에 저장
        {
            SettingFileRead = new StreamReader(Link);//세팅읽읽기
            SettingFilejsonObject = JObject.Parse(SettingFileRead.ReadToEnd());//변수에저장
            SettingFileRead.Close();
        }

        #endregion

        #region WriteFile

        public void QuitServer()
        {
            ReadDataFlie(SettingFileLink);
            DataFilejsonObject["quit"] = true;

            DataFileWrite = new StreamWriter(SettingFilejsonObject["Link"].ToString(), false);//새값 덮어씌우기
            DataFileWrite.WriteLine(DataFilejsonObject.ToString());
            DataFileWrite.Close();
        }
        
        public void SetServerDisplayResetDate()
        {
            PrintOnRichText("서버 이름 날짜 디스플레이값이 변경되었습니다 " + DateTime.Now.ToString("MM.dd"));
            ReadDataFlie(SettingFileLink);
            DataFilejsonObject["LastResetDay"] = DateTime.Now.ToString("MM.dd");

            DataFileWrite = new StreamWriter(SettingFilejsonObject["Link"].ToString(), false);//새값 덮어씌우기
            DataFileWrite.WriteLine(DataFilejsonObject.ToString());
            DataFileWrite.Close();
        }

        #endregion

        #region CheckFile

        private void CheckJsonGrammarOnSettingValue()//제이슨 세팅 파일이 에러가 없는지 확인
        {
            CheckFile = new StreamReader(SettingFileLink);

            try
            {
                JObject jObjecttry = JObject.Parse(CheckFile.ReadToEnd());
                CheckFile.Close();
                PrintOnRichText("CheckSettingFile-세팅 파일이 정상입니다");
            }
            catch
            {
                CheckFile.Close();
                SettingFilejsonObject = JObject.Parse("{}");
                SetSettingDefault();//세팅값 디폴트로 제이슨 번수에 저장
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
                MessageBox.Show("세팅파일이 문법에러가 있어 초기화되었습니다");
                PrintOnRichText("CheckSettingFile-세팅파일이 문법에러가 있어 초기화되었습니다");
            }
        }

        private bool CheckJsonGrammarOnData()//제이슨 데이터 파일이 에러가 없는지 확인
        {
            CheckFile = new StreamReader(ReadSettingInLink(SettingFileLink));
            try
            {
                Filetry = JObject.Parse(CheckFile.ReadToEnd());
                CheckFile.Close();
                //PrintOnRichText("데이터 파일이 정상입니다");
                return true;
            }
            catch
            {
                CheckFile.Close();
                //MessageBox.Show("데이터 파일이 문법에러가 있습니다");
                PrintOnRichText("CheckDataFile-데이터 파일에 문법에러가 있습니다");
                return false;
            }
        }
        
        private bool CheckDataFileExist()//데이터 파일이 있는지 확인
        {
            ReadSettingFlie(SettingFileLink);//세팅파읽읽어서 변수 SettingFileJsonObject에 저장자
            if (!File.Exists(SettingFilejsonObject["Link"].ToString()))
            {
                PrintOnRichText("CheckDataExist-지정된 경로에 데이터 파일이 존재하지 않습니다");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region DeleteFile

        public void DeleteResetFiles()
        {
            PrintOnRichText("DeleteResetFiles-ResetFiles에있는 파일들을 전부 지웁니다");
            int countitem = 1;//인덱스수 세기
            while (true)//반복문
            {
                if (ListOfResetFiles[countitem.ToString()] == null)
                {
                    break;
                }
                else
                {
                    countitem++;
                }
            }
            //PrintOnRichText("DeleteResetFiles-감지됀 파일 총 " + countitem + "개");// 로직문제있음
            for (int i = 1; i < countitem; i++)
            {
                //PrintOnRichText(i.ToString());

                // Delete a file by using File class static method...
                if (System.IO.File.Exists(ListOfResetFiles[i.ToString()].ToString()))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.
                    try
                    {
                        System.IO.File.Delete(ListOfResetFiles[i.ToString()].ToString());
                    }
                    catch
                    {
                        //Console.WriteLine(e.Message);
                        return;
                    }
                }

                // Delete a directory and all subdirectories with Directory static method...
                if (System.IO.Directory.Exists(ListOfResetFiles[i.ToString()].ToString()))
                {
                    try
                    {
                        System.IO.Directory.Delete(ListOfResetFiles[i.ToString()].ToString(), true);
                    }

                    catch
                    {
                        //Console.WriteLine(e.Message);
                    }
                }
            }
        }

        #endregion

        #region UnzipFile
        /*public static void DecompressFile(string sourceFilePath, string targetDirectoryPath)
        {
            DirectoryInfo targetDirectoryinfo = new DirectoryInfo(targetDirectoryPath);
            if (!targetDirectoryinfo.Exists)
            {
                targetDirectoryinfo.Create();
            }
            FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open);
            ZipInputStream zipinputStream = new ZipInputStream(sourceFileStream);
            byte[] bufferByteArray = new byte[2048];
            while (true)
            {
                ZipEntry zipEntry = zipinputStream.GetNextEntry();
                if (zipEntry == null)
                {
                    break;
                }
                if (zipEntry.Name.LastIndexOf('\\') > 0)
                {
                    string subdirectory = zipEntry.Name.Substring(0, zipEntry.Name.LastIndexOf('\\'));
                    if (!Directory.Exists(Path.Combine(targetDirectoryinfo.FullName, subdirectory)))
                    {
                        targetDirectoryinfo.CreateSubdirectory(subdirectory);
                    }
                }
                FileInfo targetFileInfo = new FileInfo(Path.Combine(targetDirectoryinfo.FullName, zipEntry.Name));
                using (FileStream targetFileStream = targetFileInfo.Create())
                {
                    while (true)
                    {
                        int readCount = zipinputStream.Read(bufferByteArray, 0, bufferByteArray.Length);
                        if (readCount == 0)
                        {
                            break;
                        }
                        targetFileStream.Write(bufferByteArray, 0, readCount);
                    }
                }
            }
            zipinputStream.Close();
        }*/

        void DeCompression(string filename, string extrat)
        {
            string zipPath = filename;
            string extractDir = extrat;

            System.IO.FileStream fs = new System.IO.FileStream(zipPath,
                                                 System.IO.FileMode.Open,
                                         System.IO.FileAccess.Read, System.IO.FileShare.Read);

            ICSharpCode.SharpZipLib.Zip.ZipInputStream zis =
                                    new ICSharpCode.SharpZipLib.Zip.ZipInputStream(fs);

            ICSharpCode.SharpZipLib.Zip.ZipEntry ze;

            while ((ze = zis.GetNextEntry()) != null)
            {
                if (!ze.IsDirectory)
                {
                    string fileName = System.IO.Path.GetFileName(ze.Name);

                    string destDir = System.IO.Path.Combine(extractDir,
                                     System.IO.Path.GetDirectoryName(ze.Name));

                    if (false == Directory.Exists(destDir))
                    {
                        System.IO.Directory.CreateDirectory(destDir);
                    }

                    string destPath = System.IO.Path.Combine(destDir, fileName);

                    System.IO.FileStream writer = new System.IO.FileStream(
                                    destPath, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write,
                                                System.IO.FileShare.Write);

                    byte[] buffer = new byte[2048];
                    int len;
                    while ((len = zis.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, len);
                    }

                    writer.Close();
                }
            }

            zis.Close();
            fs.Close();
        }
        #endregion

        #region SettingFileMethod

        public void LoadConfig()//세팅값불러오기
        {
            if (!File.Exists(SettingFileLink))
            {
                MessageBox.Show("세팅파일이 손실되어 새로 생성합니다");
                PrintOnRichText("LoadConfig-세팅파일이 손실되어 새로 생성합니다");
                File.WriteAllText(SettingFileLink, "{}");//세팅파일 새로생성
            }

            CheckJsonGrammarOnSettingValue();//json파일이 에러가 없는지 확인

            ReadSettingFlie(SettingFileLink);//세팅 파읽 읽어서 settingfilejsonobj변수에 저장

            if (SettingFilejsonObject["Link"] == null || 
                SettingFilejsonObject["BatchFileLink"] == null || 
                SettingFilejsonObject["AutoServerUpdate"] == null || 
                SettingFilejsonObject["AutoServerReset"] == null || 
                SettingFilejsonObject["StartOnBackground"] == null || 
                SettingFilejsonObject["ResetFiles"] == null ||
                SettingFilejsonObject["ResetDays"] == null
                )
                //데이터가 빠진경우 데이터 생성
            {
                SetSettingDefault();
                Linkcut(SettingFilejsonObject["Link"].ToString());
                SettingFileWrite = new StreamWriter(SettingFileLink, false);//쓰기 열기
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());//파일 쓰기
                SettingFileWrite.Close();//파일 닫기
                Linkcut(DefaultDataFileLink);//링크 레이블 업데이트
                CorrentBatchFileLocationlabel.Text = LinkcutStringReturn(SettingFilejsonObject["BatchFileLink"].ToString());
                MessageBox.Show("세팅파일이 손실되어 초기화 합니다");
                PrintOnRichText("LoadConfig-세팅파일이 손실되어 초기화 합니다");
            }
            else
            {
                Linkcut(SettingFilejsonObject["Link"].ToString());//링크 잘라서 레이블에 표시
                CorrentBatchFileLocationlabel.Text = LinkcutStringReturn(SettingFilejsonObject["BatchFileLink"].ToString());
            }
        }

        private void Setconfig()//데이터파일경로 변경
        {
            if (LinktextBox.Text == "")
                MessageBox.Show("값이 공백입니다");
            else
            {
                if (!File.Exists(LinktextBox.Text))
                    MessageBox.Show("지정됀 경로에 파일이 없습니다");
                else
                {
                    ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트
                    SettingFilejsonObject["Link"] = LinktextBox.Text;//값 수정
                    Linkcut(SettingFilejsonObject["Link"].ToString());// 링크 레이블 출력
                    SettingFileWrite = new StreamWriter(SettingFileLink, false);
                    SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                    SettingFileWrite.Close();
                    DataFileReset();
                    MessageBox.Show(LinktextBox.Text + "데이터 파일주소가 변경되었습니다");
                    PrintOnRichText("SetConfig-" + LinktextBox.Text + "데이터 파일주소가 변경되었습니다");
                    PrintOnRichText("SetConfig-현재 인식됀 서버파일 경로 :  " + GetCutLink(SettingFilejsonObject["Link"].ToString(), 4));
                }
            }
        }

        private void SetBatchFileconfig()//데이터파일경로 변경
        {
            if (ResetFileLinktextBox.Text == "")
                MessageBox.Show("값이 공백입니다");
            else
            {
                if (!File.Exists(ResetFileLinktextBox.Text))
                    MessageBox.Show("지정됀 경로에 파일이 없습니다");
                else
                {
                    if (Path.GetExtension(ResetFileLinktextBox.Text) == ".bat")
                    {
                        ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트
                        SettingFilejsonObject["BatchFileLink"] = ResetFileLinktextBox.Text;//값 수정
                        CorrentBatchFileLocationlabel.Text = LinkcutStringReturn(SettingFilejsonObject["BatchFileLink"].ToString());// 링크 레이블 출력
                        SettingFileWrite = new StreamWriter(SettingFileLink, false);
                        SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                        SettingFileWrite.Close();
                        DataFileReset();// 디버깅
                        MessageBox.Show(ResetFileLinktextBox.Text + "배치파일 주소가 변경되었습니다");
                        PrintOnRichText("SetBatchFileConfig-" + ResetFileLinktextBox.Text + "배치파일주소가 변경되었습니다");
                    }
                    else
                    {
                        MessageBox.Show(ResetFileLinktextBox.Text + "파일의 확장자가 .bat 가 아닙니다");
                        PrintOnRichText("SetBatchFileConfig-" + ResetFileLinktextBox.Text + "파일의 확장자가 .bat 가 아닙니다");
                    }
                }
            }
        }

        public void LoadResetFiles()
        {
            ReadSettingFlie(SettingFileLink);
            if(SettingFilejsonObject["ResetFiles"] == null)
            {
                PrintOnRichText("LoadResetFiles-리셋 파일 데이터가 없습니다");
            }
            else
            {
                ListOfResetFiles = JObject.Parse(SettingFilejsonObject["ResetFiles"].ToString());
                //ResetFilesListBox. ListOfResetFiles["1"].ToString();
                int ScanFileIndex = 1;
                while(true)
                {
                    if(ListOfResetFiles[ScanFileIndex.ToString()] == null)
                    {
                        break;
                    }
                    else
                    {
                        ListViewItem Item = new ListViewItem();
                        Item.SubItems.Add(GetFileNameToLink(ListOfResetFiles[ScanFileIndex.ToString()].ToString()));
                        Item.SubItems.Add(ListOfResetFiles[ScanFileIndex.ToString()].ToString());
                        ResetFileslistView.Items.Add(Item);
                        ScanFileIndex++;
                    }
                }
                PrintOnRichText("LoadResetFiles-리셋 파일이 로드 되었습니다");
            }
        }

        public void LoadResetDays()
        {
            ReadSettingFlie(SettingFileLink);
            if (SettingFilejsonObject["ResetDays"] == null)
            {
                PrintOnRichText("LoadResetDays-리셋 날짜 데이터가 없습니다");
            }
            else
            {
                ListOfResetDay = JObject.Parse(SettingFilejsonObject["ResetDays"].ToString());
                int ScanFileIndex = 1;
                while (true)
                {
                    if (ListOfResetDay[ScanFileIndex.ToString()] == null)
                    {
                        break;
                    }
                    else
                    {
                        ResetDateListBox.Items.Add(ListOfResetDay[ScanFileIndex.ToString()].ToString());
                        ScanFileIndex++;
                    }
                }
                PrintOnRichText("LoadResetDays-리셋 날짜가 로드 되었습니다");
            }
        }

        public int SetResetListIndex()
        {
            int FileScanIndex = 1;
            while (true)
            {
                if (ListOfResetFiles[FileScanIndex.ToString()] == null)
                {
                    break;
                }
                else
                {
                    FileScanIndex ++;
                }
            }
            return FileScanIndex;
        }

        public int SetResetDayIndex()
        {
            int FileScanIndex = 1;
            while (true)
            {
                if (ListOfResetDay[FileScanIndex.ToString()] == null)
                {
                    break;
                }
                else
                {
                    FileScanIndex++;
                }
            }
            return FileScanIndex;
        }

        #endregion

        public void Updatedata()//타이머로 데이터 업데이트
        {
            if (updatestat.Text == ".")//스테이트 레이블 설정
                updatestat.Text = "..";
            else
                updatestat.Text = ".";

            ReadDataFlie(SettingFileLink);//데이터 파일 읽어서 data jsonobj변수에 저장


            if (DataFilejsonObject["reboot"].ToString() == "True")
            {
                Rebootstatinfo.Text = "true";
                ShutdownHelper.Reboot(false);
            }
            else
                Rebootstatinfo.Text = "false";

            if (DataFilejsonObject["shutdown"].ToString() == "True")
            {
                ShutdownStatInfo.Text = "true";
                ShutdownHelper.Shutdown(true);
            }
            else
                ShutdownStatInfo.Text = "false";

            if (repeatUpdateDataLoad == 0)
            {
                //PrintOnRichText("서버 버전을 인터넷으로 부터 로드합니다");
                //PrintOnRichText("false");
                if (GetUpdateVer.GetServerUpdate() == "0")
                {
                    VerstatInfo.Text = GetUpdateVer.GetServerUpdate();
                    PrintOnRichText("서버 버전을 로드하는데 실패하였습니다");
                }
                else
                {
                    VerstatInfo.Text = GetUpdateVer.GetServerUpdate();
                    //PrintOnRichText("버전 로드에 성공했습니다 버젼: " + GetUpdateVer.GetServerUpdate());
                    if (ServerVer == null)
                    {
                        ServerVer = GetUpdateVer.GetServerUpdate();
                    }
                    else if (!(ServerVer == GetUpdateVer.GetServerUpdate()))
                    {
                        ServerVer = GetUpdateVer.GetServerUpdate();
                        PrintOnRichText("서버 업데이트가 감지되었습니다");
                        if (AutoServerUpdatecheckBox.Checked == true)
                        {
                            if (DateTime.Now.ToString("dd") == "01" ||
                                DateTime.Now.ToString("dd") == "02" ||
                                DateTime.Now.ToString("dd") == "03" ||
                                DateTime.Now.ToString("dd") == "04" ||
                                DateTime.Now.ToString("dd") == "05" ||
                                DateTime.Now.ToString("dd") == "06" ||
                                DateTime.Now.ToString("dd") == "07")
                            {
                                ServerUpdate(true);
                            }
                            else
                            {
                                ServerUpdate(false);
                            }
                        }
                    }
                }
                repeatUpdateDataLoad = 31;
            }

            repeatUpdateDataLoad = repeatUpdateDataLoad - 1;
            /*if (DataFilejsonObject["ServerVer"].ToString() == "0")
            {
                VerstatInfo.Text = DataFilejsonObject["ServerVer"].ToString();
            }
            else
            {
                VerstatInfo.Text = DataFilejsonObject["ServerVer"].ToString();
                if (ServerVer == null)
                {
                    ServerVer = DataFilejsonObject["ServerVer"].ToString();
                }
                else if (!(ServerVer == DataFilejsonObject["ServerVer"].ToString()))
                {
                    ServerVer = DataFilejsonObject["ServerVer"].ToString();
                    PrintOnRichText("서버 업데이트가 감지되었습니다");
                    if(AutoServerUpdatecheckBox.Checked == true)
                    {
                        ServerUpdate();
                    }
                }
            }*/
        }

        public void DataFileReset()//데이터 값 초기화 하기
        {
            if (CheckDataFileExist() == true)
            {
                if (CheckJsonGrammarOnData() == true)
                {
                    ReadDataFlie(SettingFileLink);
                    DataFilejsonObject["reboot"] = false;
                    DataFilejsonObject["shutdown"] = false;

                    DataFileWrite = new StreamWriter(SettingFilejsonObject["Link"].ToString(), false);//새값 덮어씌우기
                    DataFileWrite.WriteLine(DataFilejsonObject.ToString());
                    DataFileWrite.Close();
                }
            }
        }

        #region JsonDefault

        private void SetSettingDefault()
        {
            SettingFilejsonObject["Link"] = DefaultDataFileLink;
            SettingFilejsonObject["BatchFileLink"] = "null";
            SettingFilejsonObject["AutoServerReset"] = false;
            SettingFilejsonObject["AutoServerUpdate"] = false;
            SettingFilejsonObject["StartOnBackground"] = false;
            SettingFilejsonObject["ResetFiles"] = ListOfResetFiles;
            SettingFilejsonObject["ResetDays"] = ListOfResetDay;
        }

        private void SetDataDefault()
        {
            DataFilejsonObject["reboot"] = false;//데이터
            DataFilejsonObject["shutdown"] = false;
        }

        #endregion
        
        #endregion

        public MainForm()
        {
            try
            {
                // 대리자를 초기화한다.
                //csst = new CSafeSetText(CrossSafeSetTextMethod);
                cssm = new CSafeSetMaximum(CrossSafeSetMaximumMethod);
                cssv = new CSafeSetValue(CrossSafeSetValueMethod);

                // 웹 클라이언트 개체를 초기화하고,
                wc = new WebClient();

                InitializeComponent();

                LoadConfig();//콘피그 파일을 불러온다
                DataFileReset();// 데이터 파일을 오류확인, 지정됀 값만 초기화 한다

                LoadResetFiles();//리셋 파일 리스트를 띄운다
                LoadResetDays();// 리셋 날짜 리스트를 띄운다

                LoadCheckBoxValue();//체크 박스 값을 띄운다

                CkeckDate();//날짜를 확인하고 만료됀 날짜는 지운다

                LoadFormSetting();
                msgOnBoot();
                
                EventUpdatetimer.Start();

                //GetUpdateVer.GetServerUpdate();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        #region Gui

        #region GUIMethod

        private void LoadCheckBoxValue()
        {
            ReadSettingFlie(SettingFileLink);

            if (SettingFilejsonObject["AutoServerReset"].ToString() == "True")
                AutoServerResetcheckBox.Checked = true;
            else
                AutoServerResetcheckBox.Checked = false;

            if (SettingFilejsonObject["AutoServerUpdate"].ToString() == "True")
                AutoServerUpdatecheckBox.Checked = true;
            else
                AutoServerUpdatecheckBox.Checked = false;

            if (SettingFilejsonObject["StartOnBackground"].ToString() == "True")
                StartonbackgroundcheckBox.Checked = true;
            else
                StartonbackgroundcheckBox.Checked = false;

            PrintOnRichText("LoadCheckBox-체크박스 상태가 업데이트 되었습니다");
        }

        private void msgOnBoot()
        {
            if (CheckDataFileExist() == false)
            {
                PrintOnRichText("MsgOnBoot-데이터 파일이 지정됀 경로에 없습니다");
            }
            else
            {
                if (CheckJsonGrammarOnData() == true)
                {
                    PrintOnRichText("MsgOnBoot-데이터 파일이 정상입니다");
                }
                ReadDataFlie(SettingFileLink);
                PrintOnRichText("MsgOnBoot-현재 인식됀 서버파일 경로 :  " + GetCutLink(SettingFilejsonObject["Link"].ToString(), 4));
            }
        }

        bool Panelsmall = false;

        private void SetFormSizebig()
        {
            if (AutoResetSchedule.Visible == false)
            {
                /*if(this.Size.Width == 510)//작았다가 바로커짐
                {
                    this.MinimumSize = new System.Drawing.Size(1150, 380);
                    this.Size = new System.Drawing.Size(1150, this.Size.Height);
                }
                else if(this.MinimumSize == new System.Drawing.Size(900, 380))//중간에서 커짐
                {
                    this.Size = new System.Drawing.Size(this.Size.Width + 250, this.Size.Height);
                    this.MinimumSize = new System.Drawing.Size(1150, 380);

                    AutoResetFilesgroup.Size = new System.Drawing.Size(AutoResetFilesgroup.Size.Width - 250, AutoResetFilesgroup.Size.Height);
                    SetServerRunFilegroupBox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Size.Width - 250, SetServerRunFilegroupBox.Size.Height);
                }*/
                PrintOnRichText("창이 큰 사이즈로 됍니다");
                if (Panelsmall == true)
                {
                    Panelsmall = false;
                    this.Size = new System.Drawing.Size(this.Size.Width + 640, this.Size.Height);
                }
                this.MinimumSize = new System.Drawing.Size(1150, 380);
                this.MaximumSize = new System.Drawing.Size(0, 0);
                //this.Size = new System.Drawing.Size(1150, this.Size.Height);
                AutoResetFilesgroup.Size = new System.Drawing.Size(this.Size.Width - AutoResetFilesgroup.Location.X - 250 - 30, AutoResetFilesgroup.Size.Height);
                SetServerRunFilegroupBox.Size = new System.Drawing.Size(this.Size.Width - SetServerRunFilegroupBox.Location.X - 250 - 30, SetServerRunFilegroupBox.Size.Height);

                AutoResetSchedule.Visible = true;
                AutoResetFilesgroup.Visible = true;
                SetServerRunFilegroupBox.Visible = true;

                AutoResetSchedule.Location = new System.Drawing.Point(AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width + 6, AutoResetSchedule.Location.Y);
                AutoResetSchedule.Size = new System.Drawing.Size(this.Width - (AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width) - 40, AutoResetFilesgroup.Height);
            }
        }

        private void SetFormSizemedium()
        {
            /*if (this.Size.Width == 510)//작았다가 중간
            {
                //this.Size = new System.Drawing.Size(900, this.Size.Height);
                this.Size = new System.Drawing.Size(1150, this.Size.Height);

                AutoResetFilesgroup.Size = new System.Drawing.Size(AutoResetFilesgroup.Size.Width + 250, AutoResetFilesgroup.Size.Height);
                SetServerRunFilegroupBox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Size.Width + 250, SetServerRunFilegroupBox.Size.Height);

                this.Size = new System.Drawing.Size(900, this.Size.Height);
            }
            else//켜졌다가 중간
            {
                //this.Size = new System.Drawing.Size(this.Size.Width - 250, this.Size.Height);

                AutoResetFilesgroup.Size = new System.Drawing.Size(AutoResetFilesgroup.Size.Width + 250, AutoResetFilesgroup.Size.Height);
                SetServerRunFilegroupBox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Size.Width + 250, SetServerRunFilegroupBox.Size.Height);

                this.Size = new System.Drawing.Size(this.Size.Width - 250, this.Size.Height);
            }*/
            PrintOnRichText("창이 중간 사이즈로 됍니다");
            if (Panelsmall == true)
            {
                Panelsmall = false;
                this.Size = new System.Drawing.Size(this.Size.Width + 640, this.Size.Height);
            }
            this.MinimumSize = new System.Drawing.Size(1150, 380);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            //this.Size = new System.Drawing.Size(1150, this.Size.Height);

            AutoResetFilesgroup.Size = new System.Drawing.Size(this.Size.Width - AutoResetFilesgroup.Location.X - 28, AutoResetFilesgroup.Size.Height);
            SetServerRunFilegroupBox.Size = new System.Drawing.Size(this.Size.Width - SetServerRunFilegroupBox.Location.X - 28, SetServerRunFilegroupBox.Size.Height);

            AutoResetSchedule.Visible = false;

            AutoResetFilesgroup.Visible = true;
            SetServerRunFilegroupBox.Visible = true;
        }

        private void SetFormSizesmall()
        {
            /*if (this.MinimumSize == new System.Drawing.Size(900, 380))//중간에서 작아짐
            {
                this.Size = new System.Drawing.Size(1150, this.Size.Height);
                AutoResetFilesgroup.Size = new System.Drawing.Size(AutoResetFilesgroup.Size.Width - 250, AutoResetFilesgroup.Size.Height);
                SetServerRunFilegroupBox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Size.Width - 250, SetServerRunFilegroupBox.Size.Height);
                this.Size = new System.Drawing.Size(510, this.Size.Height);
            }
            else//켜졌다가 작아짐
            {
                //AutoResetFilesgroup.Size = new System.Drawing.Size(AutoResetFilesgroup.Size.Width - 250, AutoResetFilesgroup.Size.Height);
                //SetServerRunFilegroupBox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Size.Width - 250, SetServerRunFilegroupBox.Size.Height);
                this.Size = new System.Drawing.Size(510, this.Size.Height);
            }*/

            PrintOnRichText("창이 작은 사이즈로 됍니다");
            Panelsmall = true;

            this.MinimumSize = new System.Drawing.Size(consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Size.Width, 380);
            this.MaximumSize = new System.Drawing.Size(consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Size.Width, 10000);
            this.Size = new System.Drawing.Size(consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Location.X + consoleRichTextbox.Size.Width, this.Size.Height);

            AutoResetSchedule.Visible = false;
            AutoResetFilesgroup.Visible = false;
            SetServerRunFilegroupBox.Visible = false;
        }

        private void hidePrograssBar()
        {
            consoleRichTextbox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Location.X - 18, consoleRichTextbox.Size.Height + 29);
            updateProgressbar.Visible = false;
        }

        private void showPrograssBar()
        {
            consoleRichTextbox.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Location.X - 18, consoleRichTextbox.Size.Height - 29);
            updateProgressbar.Visible = true;
        }

        private void LoadFormSetting()//폼세팅여부
        {
            ReadSettingFlie(SettingFileLink);

            if (SettingFilejsonObject["StartOnBackground"].ToString() == "True")
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
            else
            {
                TrayIcon.Visible = false;
                this.Opacity = 100;
                this.ShowInTaskbar = true;
            }

            //AutoResetSchedule.Location = new System.Drawing.Point(AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width + 6, AutoResetSchedule.Location.Y);
            //AutoResetSchedule.Size = new System.Drawing.Size(this.Width - (AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width) - 40, AutoResetFilesgroup.Height);

            hidePrograssBar();
            updateProgressbar.Size = new System.Drawing.Size(SetServerRunFilegroupBox.Location.X - 18, updateProgressbar.Height);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////기본 창 비율 조정 로직
            this.MinimumSize = new System.Drawing.Size(1150, 380);
            this.MaximumSize = new System.Drawing.Size(0, 0);

            AutoResetFilesgroup.Size = new System.Drawing.Size(this.Size.Width - AutoResetFilesgroup.Location.X - 250 - 30, AutoResetFilesgroup.Size.Height);
            SetServerRunFilegroupBox.Size = new System.Drawing.Size(this.Size.Width - SetServerRunFilegroupBox.Location.X - 250 - 30, SetServerRunFilegroupBox.Size.Height);

            AutoResetSchedule.Location = new System.Drawing.Point(AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width + 6, AutoResetSchedule.Location.Y);
            AutoResetSchedule.Size = new System.Drawing.Size(this.Width - (AutoResetFilesgroup.Location.X + AutoResetFilesgroup.Width) - 40, AutoResetFilesgroup.Height);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (SettingFilejsonObject["AutoServerReset"].ToString() == "False" && SettingFilejsonObject["AutoServerUpdate"].ToString() == "False")
            {
                SetFormSizesmall();
            }
            else if (SettingFilejsonObject["AutoServerUpdate"].ToString() == "True")
            {
                if (SettingFilejsonObject["AutoServerReset"].ToString() == "False")
                {
                    SetFormSizemedium();
                }
                else
                {
                    SetFormSizebig();
                }
            }
        }

        #endregion

        #region GuiEvent

        #region UnVisualGui

        #region timer

        private void EventUpdatetimer_Tick(object sender, EventArgs e)
        {

            if (CheckDataFileExist() == false)
            {
                updatestat.Text = "DataFile dont exist";
                Rebootstatinfo.Text = "Error";
                ShutdownStatInfo.Text = "Error";
            }
            else
            {
                if (CheckJsonGrammarOnData() == true)
                {
                    Updatedata();
                }
                else
                {
                    updatestat.Text = "DataFile GrammarError";
                    Rebootstatinfo.Text = "Error";
                    ShutdownStatInfo.Text = "Error";
                }
            }
            GC.Collect();//가비지 콜랙트

            if(FileDownLoadFinishDetect == true)
            {
                FileDownLoadFinishDetect = false;
                DownloadOxide();
            }

            UpdateDate();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!(repeatUpdateDataLoad == 0))
            {
                repeatUpdateDataLoad = 31;
                //PrintOnRichText("TestMsg");
            }
        }

        private void DownloadTimeoutTimer_Tick(object sender, EventArgs e)
        {
            PrintOnRichText(DownTimeoutCount.ToString());
            if (DownTimeoutCount <= 0)
            {
                wc.CancelAsync();
                DownloadTimeoutTimer.Stop();
            }
            else
                DownTimeoutCount--;
        }

        #endregion

        #region FormEvent

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                TrayIcon.Visible = true;
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                e.Cancel = true;
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TrayIcon.Visible = false;
            this.Opacity = 100;
            this.ShowInTaskbar = true;
        }

        private void OpenForm(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            this.Opacity = 100;
            this.ShowInTaskbar = true;
        }

        private void FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
        
        #endregion

        #region VisualGui

        #region SetData/File

        #region SetDataFileLink

        private void LinkApply_Click(object sender, EventArgs e)
        {
            Setconfig();
        }

        private void broserbutton_Click(object sender, EventArgs e)
        {
            ReadSettingFlie(SettingFileLink);
            SetdatafileopenFileDialog.InitialDirectory = GetCutLink(SettingFilejsonObject["Link"].ToString(), 1);
            //openFileDialog1.ShowDialog();
            if (SetdatafileopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //File경로와 File명을 모두 가지고 온다.
                fileFullName = SetdatafileopenFileDialog.FileName;
                LinktextBox.Text = fileFullName;
            }
        }

        private void LinktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LinkApply_Click(sender, null);
            }
        }

        #endregion

        #region SetResetFile

        private void ResetFileBrowseButton_Click(object sender, EventArgs e)
        {
            ReadSettingFlie(SettingFileLink);
            SetResetFilesopenFileDialog.InitialDirectory = GetCutLink(SettingFilejsonObject["Link"].ToString(), 1);
            //openFileDialog1.ShowDialog();
            if (SetResetFilesopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //File경로와 File명을 모두 가지고 온다.
                fileFullName = SetResetFilesopenFileDialog.FileName;
                ResetLinktextBox.Text = fileFullName;
            }
        }

        private void ResetLinktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ResetFileAddButton_Click(sender, null);
            }
        }

        private void ResetFileAddButton_Click(object sender, EventArgs e)
        {
            //File경로와 File명을 모두 가지고 온다.
            fileFullName = ResetLinktextBox.Text;

            if (fileFullName == "")
                MessageBox.Show("값이 공백입니다");
            else
            {
                if (!File.Exists(fileFullName)&&!Directory.Exists(fileFullName))
                    MessageBox.Show("지정됀 경로에 파일 또는 디렉토리가 없습니다");
                else
                {
                    int countitem = 1;//인덱스수 세기
                    while (true)//반복문
                    {
                        if (ListOfResetFiles[countitem.ToString()] == null)
                        {
                            break;
                        }
                        else
                        {
                            countitem++;
                        }
                    }
                    countitem = countitem - 1;//여기까지 인덱스 수 세기
                    //PrintOnRichText(countitem.ToString());
                    if (countitem == 0)
                    {
                        ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트

                        ListOfResetFiles.Add(SetResetListIndex().ToString(), fileFullName);
                        SettingFilejsonObject["ResetFiles"] = ListOfResetFiles;
                        SettingFileWrite = new StreamWriter(SettingFileLink, false);
                        SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                        SettingFileWrite.Close();

                        ListViewItem Item = new ListViewItem();
                        Item.SubItems.Add(GetFileNameToLink(fileFullName));
                        Item.SubItems.Add(fileFullName);
                        ResetFileslistView.Items.Add(Item);

                        PrintOnRichText("AddResetFile-" + GetFileNameToLink(fileFullName) + "파일이 추가 되었습니다");
                    }
                    else
                    {
                        for (int i = 1; i < (countitem + 1); i++)
                        {
                            //PrintOnRichText(i.ToString());
                            if (ListOfResetFiles[i.ToString()].ToString() == fileFullName)
                            {
                                PrintOnRichText("AddResetFile-이미 있는 파일입니다");
                                break;
                            }
                            if (countitem == i)
                            {
                                ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트

                                ListOfResetFiles.Add(SetResetListIndex().ToString(), fileFullName);
                                SettingFilejsonObject["ResetFiles"] = ListOfResetFiles;
                                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                                SettingFileWrite.Close();

                                ListViewItem Item = new ListViewItem();
                                Item.SubItems.Add(GetFileNameToLink(fileFullName));
                                Item.SubItems.Add(fileFullName);
                                ResetFileslistView.Items.Add(Item);

                                 PrintOnRichText("AddResetFile-" + GetFileNameToLink(fileFullName) + "파일이 추가 되었습니다");
                            }
                        }
                    }
                }
            }
        }

        #endregion

        # region SetRunFile

        private void SetServerRunFilebutton_Click(object sender, EventArgs e)
        {
            SetBatchFileconfig();
        }

        private void ResetFileLinktextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetServerRunFilebutton_Click(sender, null);
            }
        }

        private void RunFileBrowseButton_Click(object sender, EventArgs e)
        {
            ReadSettingFlie(SettingFileLink);
            if (SettingFilejsonObject["BatchFileLink"].ToString() == "null")
            {
                SetServerRunFileopenFileDialog.InitialDirectory = GetCutLink(SettingFilejsonObject["Link"].ToString(), 4);
                //PrintOnRichText(GetCutLink(SettingFilejsonObject["Link"].ToString(), 4));
            }
            else
            {
                SetServerRunFileopenFileDialog.InitialDirectory = GetCutLink(SettingFilejsonObject["BatchFileLink"].ToString(), 1);
            }
            if (SetServerRunFileopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //File경로와 File명을 모두 가지고 온다.
                fileFullName = SetServerRunFileopenFileDialog.FileName;
                ResetFileLinktextBox.Text = fileFullName;
            }
        }

        #endregion

        #region SetScadule

        private void resetCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            //PrintOnRichText(resetCalendar.SelectionStart.ToString("yyyy-MM-dd"));

            int countitem = 1;//인덱스수 세기
            while (true)//반복문
            {
                if (ListOfResetDay[countitem.ToString()] == null)
                {
                    break;
                }
                else
                {
                    countitem++;
                }
            }
            countitem = countitem - 1;//여기까지 인덱스 수 세기
            //PrintOnRichText(countitem.ToString());
            if (countitem == 0)
            {
                ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트

                ListOfResetDay.Add(SetResetDayIndex().ToString(), resetCalendar.SelectionStart.ToString("yyyy-MM-dd"));
                SettingFilejsonObject["ResetDays"] = ListOfResetDay;
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();

                ResetDateListBox.Items.Add(resetCalendar.SelectionStart.ToString("yyyy-MM-dd"));

                PrintOnRichText("AddResetDay-" + resetCalendar.SelectionStart.ToString("yyyy-MM-dd") + "날짜가 추가 되었습니다");
            }
            else
            {
                for (int i = 1; i < (countitem + 1); i++)
                {
                    //PrintOnRichText(i.ToString());
                    if (ListOfResetDay[i.ToString()].ToString() == resetCalendar.SelectionStart.ToString("yyyy-MM-dd"))
                    {
                        PrintOnRichText("AddResetDay-이미 있는 날짜입니다");
                        break;
                    }
                    if (countitem == i)
                    {
                        ReadSettingFlie(SettingFileLink);//세팅파일읽기//제이슨 파일로 컴버트

                        ListOfResetDay.Add(SetResetDayIndex().ToString(), resetCalendar.SelectionStart.ToString("yyyy-MM-dd"));
                        SettingFilejsonObject["ResetDays"] = ListOfResetDay;
                        SettingFileWrite = new StreamWriter(SettingFileLink, false);
                        SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                        SettingFileWrite.Close();

                        ResetDateListBox.Items.Add(resetCalendar.SelectionStart.ToString("yyyy-MM-dd"));

                        PrintOnRichText("AddResetDay-" + resetCalendar.SelectionStart.ToString("yyyy-MM-dd") + "날짜가 추가 되었습니다");
                    }
                }
            }
        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            DeleteDayChecked_listView(ResetDateListBox);
        }

        private void RemoveAllbutton_Click(object sender, EventArgs e)
        {
            DeleteAllDayChecked_listView(ResetDateListBox);
        }

        public void DeleteDay(CheckedListBox LV, string itemname)
        {
            ReadSettingFlie(SettingFileLink);
            //PrintOnRichText(LV.Items[row].SubItems[2].Text);
            int countitem = 1;//인덱스수 세기
            while (true)//반복문
            {
                if (ListOfResetDay[countitem.ToString()] == null)
                {
                    break;
                }
                else
                {
                    countitem++;
                }
            }
            countitem = countitem - 1;//여기까지 인덱스 수 세기

            //PrintOnRichText(countitem.ToString());
            for (int ii = 1; ii < (countitem + 1); ii++)//인덱스 수만큼 반복
            {
                if (ListOfResetDay[ii.ToString()].ToString() == itemname)//만약 지금 보고있는 인덱스가 내가 지울 인덱스 라면
                {
                    for (int i = ii; i < countitem; i++)//뒤에있는 아이템 수만큼 반복
                    {
                        //PrintOnRichText(i.ToString());
                        ListOfResetDay[i.ToString()] = ListOfResetDay[(i + 1).ToString()];//뒤에이쓰는 아이템들 인덱스 재부여
                    }
                    ListOfResetDay.Remove(countitem.ToString());//마지막 인덱스 아이템 삭제

                    SettingFilejsonObject["ResetDays"] = ListOfResetDay;//저장
                    SettingFileWrite = new StreamWriter(SettingFileLink, false);
                    SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                    SettingFileWrite.Close();

                    PrintOnRichText(itemname + "가 기간이 만료되어 삭제 되었습니다");
                    LV.Items.RemoveAt(ii - 1);//리스트에서 삭제
                    break;
                }
            }
        }

        private void DeleteDayChecked_listView(CheckedListBox LV)
        {
            for (int row = LV.Items.Count - 1; row >= 0; row--)
            {
                if (LV.GetItemChecked(row))
                {
                    ReadSettingFlie(SettingFileLink);
                    //PrintOnRichText(LV.Items[row].SubItems[2].Text);
                    int countitem = 1;//인덱스수 세기
                    while (true)//반복문
                    {
                        if (ListOfResetDay[countitem.ToString()] == null)
                        {
                            break;
                        }
                        else
                        {
                            countitem++;
                        }
                    }
                    countitem = countitem - 1;//여기까지 인덱스 수 세기

                    //PrintOnRichText(countitem.ToString());
                    for (int ii = 1; ii < (countitem + 1); ii++)//인덱스 수만큼 반복
                    {
                        if (ListOfResetDay[ii.ToString()].ToString() == LV.Items[row].ToString())//만약 지금 보고있는 인덱스가 내가 지울 인덱스 라면
                        {
                            for (int i = ii; i < countitem; i++)//뒤에있는 아이템 수만큼 반복
                            {
                                //PrintOnRichText(i.ToString());
                                ListOfResetDay[i.ToString()] = ListOfResetDay[(i + 1).ToString()];//뒤에이쓰는 아이템들 인덱스 재부여
                            }
                            ListOfResetDay.Remove(countitem.ToString());//마지막 인덱스 아이템 삭제

                            SettingFilejsonObject["ResetDays"] = ListOfResetDay;//저장
                            SettingFileWrite = new StreamWriter(SettingFileLink, false);
                            SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                            SettingFileWrite.Close();

                            break;
                        }
                    }
                    PrintOnRichText(LV.Items[row].ToString() + "가 삭제 되었습니다");
                    LV.Items.RemoveAt(row);//리스트에서 삭제
                }
            }
        }

        private void DeleteAllDayChecked_listView(CheckedListBox LV)
        {
            for (int row = LV.Items.Count - 1; row >= 0; row--)
            {
                ReadSettingFlie(SettingFileLink);
                //PrintOnRichText(LV.Items[row].SubItems[2].Text);
                int countitem = 1;//인덱스수 세기
                while (true)//반복문
                {
                    if (ListOfResetDay[countitem.ToString()] == null)
                    {
                        break;
                    }
                    else
                    {
                        countitem++;
                    }
                }
                countitem = countitem - 1;//여기까지 인덱스 수 세기

                //PrintOnRichText(countitem.ToString());
                for (int ii = 1; ii < (countitem + 1); ii++)//인덱스 수만큼 반복
                {
                    if (ListOfResetDay[ii.ToString()].ToString() == LV.Items[row].ToString())//만약 지금 보고있는 인덱스가 내가 지울 인덱스 라면
                    {
                        for (int i = ii; i < countitem; i++)//뒤에있는 아이템 수만큼 반복
                        {
                            //PrintOnRichText(i.ToString());
                            ListOfResetDay[i.ToString()] = ListOfResetDay[(i + 1).ToString()];//뒤에이쓰는 아이템들 인덱스 재부여
                        }
                        ListOfResetDay.Remove(countitem.ToString());//마지막 인덱스 아이템 삭제

                        SettingFilejsonObject["ResetDays"] = ListOfResetDay;//저장
                        SettingFileWrite = new StreamWriter(SettingFileLink, false);
                        SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                        SettingFileWrite.Close();

                        break;
                    }
                }
                PrintOnRichText(LV.Items[row].ToString() + "가 삭제 되었습니다");
                LV.Items.RemoveAt(row);//리스트에서 삭제

            }
        }
        #endregion

        #endregion

        #region FunctionSetting
        
        private void AutoServerUpdatecheckBox_Click(object sender, EventArgs e)
        {

            if (AutoServerUpdatecheckBox.Checked == true)
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["AutoServerUpdate"] = true;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
                if (AutoServerResetcheckBox.Checked == false)
                {
                    SetFormSizemedium();
                }
            }
            else
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["AutoServerUpdate"] = false;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
                if (AutoServerResetcheckBox.Checked == false)
                {
                    SetFormSizesmall();
                }
            }
        }

        private void AutoServerResetcheckBox_Click(object sender, EventArgs e)
        {

            if (AutoServerResetcheckBox.Checked == true)
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["AutoServerReset"] = true;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
                SetFormSizebig();
            }
            else
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["AutoServerReset"] = false;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
                if (AutoServerUpdatecheckBox.Checked == true)
                {
                    SetFormSizemedium();
                }
                else
                {
                    SetFormSizesmall();
                }
            }
        }

        private void StartonbackgroundcheckBox_Click(object sender, EventArgs e)
        {

            if (StartonbackgroundcheckBox.Checked == true)
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["StartOnBackground"] = true;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
            }
            else
            {
                ReadSettingFlie(SettingFileLink);
                SettingFilejsonObject["StartOnBackground"] = false;//값 수정
                SettingFileWrite = new StreamWriter(SettingFileLink, false);
                SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                SettingFileWrite.Close();
            }
        }

        #endregion

        #region ConsoleEvent
        private void consoleRichTextbox_TextChanged(object sender, EventArgs e)
        {
            if (consoleRichTextbox.Focused == false)
            {
                consoleRichTextbox.ScrollToCaret();
            }
        }
        #endregion

        #region ListviewCheckBox
        private void ResetFileslistView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 1), value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ResetFileslistView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ResetFileslistView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void DeleteLineChecked_listView(ListView LV)
        {
            for (int row = LV.Items.Count - 1; row >= 0; row--)
            {
                if (LV.Items[row].Checked)
                {
                    ReadSettingFlie(SettingFileLink);
                    //PrintOnRichText(LV.Items[row].SubItems[2].Text);
                    int countitem = 1;//인덱스수 세기
                    while (true)//반복문
                    {
                        if(ListOfResetFiles[countitem.ToString()] == null)
                        {
                            break;
                        }
                        else
                        {
                            countitem++;
                        }
                    }
                    countitem = countitem - 1;//여기까지 인덱스 수 세기

                    //PrintOnRichText(countitem.ToString());
                    for(int ii = 1; ii < (countitem+1); ii++)//인덱스 수만큼 반복
                    {
                        if(ListOfResetFiles[ii.ToString()].ToString() == LV.Items[row].SubItems[2].Text)//만약 지금 보고있는 인덱스가 내가 지울 인덱스 라면
                        {
                            //PrintOnRichText(ii.ToString());
                            //ListOfResetFiles.Remove(ii.ToString());//현재 보고있는 인덱스 지우기
                            for (int i = ii; i < countitem; i++)//뒤에있는 아이템 수만큼 반복
                            {
                                //PrintOnRichText(i.ToString());
                                ListOfResetFiles[i.ToString()] = ListOfResetFiles[(i + 1).ToString()];//뒤에이쓰는 아이템들 인덱스 재부여
                            }
                            ListOfResetFiles.Remove(countitem.ToString());//마지막 인덱스 아이템 삭제

                            SettingFilejsonObject["ResetFiles"] = ListOfResetFiles;//저장
                            SettingFileWrite = new StreamWriter(SettingFileLink, false);
                            SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                            SettingFileWrite.Close();

                            break;
                        }
                    }
                    PrintOnRichText(LV.Items[row].SubItems[1].Text + "가 삭제 되었습니다");
                    LV.Items.RemoveAt(row);//리스트에서 삭제
                }
            }
        }

        private void ResetFileRemoveButton_Click(object sender, EventArgs e)
        {
            DeleteLineChecked_listView(ResetFileslistView);
        }

        private void ResetFileslistView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.ResetFileslistView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.ResetFileslistView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.ResetFileslistView.Items) item.Checked = !value;
                this.ResetFileslistView.Invalidate();
            }
        }

        #region old-solution
        /*
        private void ResetFileslistView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if ((e.ColumnIndex == 0))
            {
                CheckBox cck = new CheckBox();
                Text = "";
                ResetFileslistView.SuspendLayout();  // 컨트롤의 레이아웃 논리를 임시로 일시 중단
                e.DrawBackground();  // 열 머리글의 배경색을 그리기
                cck.BackColor = Color.Transparent;
                cck.UseVisualStyleBackColor = true;  // 비주얼 스타일을 사용하여 배경을 그리면 true

                // 컨트롤의 범위를 지정된 위치와 크기로 설정 (Left x, Top y, width, height)
                cck.SetBounds(e.Bounds.X, e.Bounds.Y, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);

                // 컨트롤의 높이와 너비를 가져오거나 설정

                cck.Size = new Size((cck.GetPreferredSize(new Size((e.Bounds.Width - 1), e.Bounds.Height)).Width + 1), e.Bounds.Height);
                cck.Location = new Point(4, 0); // 왼쪽 위를 기준으로 컨트롤의 왼쪽 위의 좌표를 가져오거나 설정
                //ResetFileslistView.Controls.Add(cck);
                cck.Show();
                //cck.BringToFront();
                Visible = true;  // 컨트롤과 모든 해당 자식 컨트롤이 표시되면 true

                e.DrawText((TextFormatFlags.VerticalCenter | TextFormatFlags.Left));
                cck.Click += new EventHandler(Bink);  // 컨트롤을 클릭하면 발생
                ResetFileslistView.ResumeLayout(true);  // 일반 레이아웃 논리를 다시 시작

            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void Bink(object sender, System.EventArgs e)
        {
            CheckBox cck = sender as CheckBox;
            for (int i = 0; i < ResetFileslistView.Items.Count; i++)
            {
                ResetFileslistView.Items[i].Checked = cck.Checked;
            }
        }

        private void ResetFileslistView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ResetFileslistView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void DeleteLineChecked_listView(ListView LV)
        {
            for (int row = LV.Items.Count - 1; row >= 0; row--)
            {
                if (LV.Items[row].Checked)
                {
                    //LV.Items.Remove(LV.Items[row]);
                    LV.Items.RemoveAt(row);
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void ResetFileRemoveButton_Click(object sender, EventArgs e)
        {
            DeleteLineChecked_listView(ResetFileslistView);
        }*/
            #endregion

            #endregion

        #endregion

        #region Debug
            private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStripOnTestMenu.Show(MousePosition);
        }

        #region TestMenu

        #region ServerUpdateTestMenu
        private void DefaultUpdateToolStripItem_Click(object sender, EventArgs e)
        {
            ServerUpdate(true);
        }

        private void ServerQuitToolStripItem_Click(object sender, EventArgs e)
        {
            QuitServer();
        }

        private void DeleteResetFilesToolStripItem_Click(object sender, EventArgs e)
        {
            DeleteResetFiles();
        }

        private void RunUpdateProcessToolStripItem_Click(object sender, EventArgs e)
        {
            showPrograssBar();// 프로그래스바를 보여준다
            initServerupdate();// 서버 업데이트를 한다, 옥사이드 다운, 설치도 포함이다, 나중에 프로그래스바도 알아서 닫힌다 그리고 서버가 켜진다
        }

        private void RunServerToolStripItem_Click(object sender, EventArgs e)
        {
            RunProcess(SettingFilejsonObject["BatchFileLink"].ToString());//서버를 연다
        }

        private void oxideDownloadToolStripItem_Click(object sender, EventArgs e)
        {
            DownloadOxide();
        }
        
        private void oxideDownloadCancelToolStripItem_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();
        }
        
        private void ResetDisplayUpdatetoolStripItem_Click(object sender, EventArgs e)
        {
            SetServerDisplayResetDate();
        }
        #endregion

        #region ServerResetTestMenu
        private void DefaultResetToolStripItem_Click(object sender, EventArgs e)
        {
            ServerReset();
        }

        private void ServerQuitOnResetToolStripItem_Click(object sender, EventArgs e)
        {
            QuitServer();
        }

        private void DeleteResetFilesOnResetToolStripItem_Click(object sender, EventArgs e)
        {
            DeleteResetFiles();
        }

        private void RunServerOnResetToolStripItem_Click(object sender, EventArgs e)
        {
            RunProcess(SettingFilejsonObject["BatchFileLink"].ToString());//서버를 연다
        }

        private void ResetDisplayUpdatetoolStripItem1_Click(object sender, EventArgs e)
        {
            SetServerDisplayResetDate();
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region EventMethod
        public void CkeckDate()
        {
            if (CorrentDate == null || !(CorrentDate == DateTime.Now.ToString("yyyy-MM-dd")))
            {
                CorrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                //resetCalendar.TodayDate = DateTime.Now;
                resetCalendar.MinDate = DateTime.Now.AddDays(1);
                PrintOnRichText("현재 날짜값이 업데이트 되었습니다 " + DateTime.Now.ToString("yyyy-MM-dd"));

                //PrintOnRichText(ListOfResetDay.Count.ToString());
                List<string> Deletelist = new List<string>();

                DateTime CorrentDateOnDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                int result;

                for (int i = 1; i < (ListOfResetDay.Count + 1); i++)
                {
                    //PrintOnRichText("e" + i.ToString());

                    DateTime ListDate = Convert.ToDateTime(ListOfResetDay[i.ToString()].ToString());
                    result = DateTime.Compare(CorrentDateOnDateTime, ListDate);
                    if (result < 0)
                    {
                        //PrintOnRichText("none" + ListDate);
                    }
                    else if (result >= 0)
                    {
                        //DeleteDay(ResetDateListBox, ListDate.ToString("yyyy-MM-dd"));
                        //PrintOnRichText("y" + ListDate);
                        Deletelist.Add(ListDate.ToString("yyyy-MM-dd"));
                    }
                }
                for (int i = 0; i < Deletelist.Count; i++)
                {
                    DeleteDay(ResetDateListBox, Deletelist[i]);
                }
            }
        }

        public void UpdateDate()
        {
            if (CorrentDate == null || !(CorrentDate == DateTime.Now.ToString("yyyy-MM-dd")))
            {
                CorrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                //resetCalendar.TodayDate = DateTime.Now;
                resetCalendar.MinDate = DateTime.Now.AddDays(1);
                PrintOnRichText("현재 날짜값이 업데이트 되었습니다 " + DateTime.Now.ToString("yyyy-MM-dd"));

                ReadSettingFlie(SettingFileLink);
                int countitem = 1;//인덱스수 세기
                while (true)//반복문
                {
                    if (ListOfResetDay[countitem.ToString()] == null)
                    {
                        break;
                    }
                    else
                    {
                        countitem++;
                    }
                }
                countitem = countitem - 1;//여기까지 인덱스 수 세기

                //PrintOnRichText(countitem.ToString());
                for (int ii = 1; ii < (countitem + 1); ii++)//인덱스 수만큼 반복
                {
                    if (ListOfResetDay[ii.ToString()].ToString() == CorrentDate)//만약 지금 보고있는 인덱스가 내가 지울 인덱스 라면
                    {
                        for (int i = ii; i < countitem; i++)//뒤에있는 아이템 수만큼 반복
                        {
                            //PrintOnRichText(i.ToString());
                            ListOfResetDay[i.ToString()] = ListOfResetDay[(i + 1).ToString()];//뒤에이쓰는 아이템들 인덱스 재부여
                        }
                        ListOfResetDay.Remove(countitem.ToString());//마지막 인덱스 아이템 삭제

                        SettingFilejsonObject["ResetDays"] = ListOfResetDay;//저장
                        SettingFileWrite = new StreamWriter(SettingFileLink, false);
                        SettingFileWrite.WriteLine(SettingFilejsonObject.ToString());
                        SettingFileWrite.Close();

                        PrintOnRichText(CorrentDate + "가 기간이 만료되어 삭제 되었습니다");
                        ResetDateListBox.Items.RemoveAt(ii - 1);//리스트에서 삭제

                        if (AutoServerResetcheckBox.Checked == true)
                        { 
                            ServerReset();
                        }

                        break;
                    }
                }
            }
        }

        public void ServerReset()
        {
            ReadSettingFlie(SettingFileLink);
            if (!(CheckDataFileExist()))
            {
                PrintOnRichText("데이터 파일이 지정됀 경로에 존재하지 않습니다");
            }
            else
            {
                if (CheckJsonGrammarOnData() == true)
                {
                    PrintOnRichText("서버를 초기화 합니다");/////////////////////////////////////////////////////////////////////////////////////////////////
                    QuitServer();//서버를 끈다
                    Delay(20000);
                    DeleteResetFiles();//리셋 리스트에 있는 파일들을 모두 지운다
                    SetServerDisplayResetDate();
                    RunProcess(SettingFilejsonObject["BatchFileLink"].ToString());//서버를 연다
                }
                else
                {
                    PrintOnRichText("Reset-리셋 파일 데이터가 json 문법에 맞지 않습니다");
                }
            }
        }

        public void ServerUpdate(bool resetdata)
        {
            ReadSettingFlie(SettingFileLink);
            if (!(CheckDataFileExist()))
            {
                PrintOnRichText("데이터 파일이 지정됀 경로에 존재하지 않습니다");
            }
            else
            {
                if (CheckJsonGrammarOnData() == true)
                {
                    //PrintOnRichText(Application.StartupPath + @"\steam");
                    if (System.IO.Directory.Exists(Application.StartupPath + @"\steam"))
                    {
                        if (System.IO.File.Exists(Application.StartupPath + @"\steam\steamcmd.exe"))
                        {
                            if (whileupdate == false)
                            {
                                if(resetdata == true)
                                {
                                    PrintOnRichText("업데이트 함과 동시에 서버를 초기화 합니다");
                                    PrintOnRichText("*1일~7일 일때 업데이트가 감지되면 초기화가 업데이트때 같이 진행됍니다"); 
                                }
                                else
                                {
                                    PrintOnRichText("초기화 없이 업데이트만 합니다");
                                    PrintOnRichText("*1일~7일 일때 업데이트가 감지되면 초기화가 업데이트때 같이 진행됍니다");
                                }
                                whileupdate = true;// 업데이트 중으로 값을 설정
                                PrintOnRichText("서버 업데이트를 시작합니다");
                                QuitServer();//서버를 끈다
                                if (resetdata == true)
                                {
                                    DeleteResetFiles();//리셋 리스트에 있는 파일들을 모두 지운다
                                    SetServerDisplayResetDate();
                                }
                                showPrograssBar();// 프로그래스바를 보여준다
                                initServerupdate();// 서버 업데이트를 한다, 옥사이드 다운, 설치도 포함이다, 나중에 프로그래스바도 알아서 닫힌다 그리고 서버가 켜진다
                            }
                            else
                            {
                                PrintOnRichText("Error-이미 업데이트 중입니다");
                            }
                        }
                        else
                        {
                            PrintOnRichText("Error-" + Application.StartupPath + @"\steam 에 steamcmd.exe파일이 존재하지 않습니다");
                        }
                    }
                    else
                    {
                        PrintOnRichText("Error-" + Application.StartupPath + "에steam디렉토리가 존재하지 않습니다");
                    }
                }
                else
                {
                    PrintOnRichText("Reset-리셋 파일 데이터가 json 문법에 맞지 않습니다");
                }
            }
        }

        /// <summary>
        /// Delay 함수 MS
        /// </summary>
        /// <param name="MS">(단위 : MS)
        ///
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        #endregion

        #endregion
    }
    #region OtherClass

    public static class ShutdownHelper//셧다운 매니저 클래스
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, int desiredAccess, ref IntPtr tokenHandle);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string hostName, string name, ref long luid);
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr tokenHandle, bool disableAllPrivileges,
        ref TOKEN_PRIVILEGES newState, int bufferLength, IntPtr previousState, IntPtr returnLength);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool ExitWindowsEx(int flag, int reason);
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TOKEN_PRIVILEGES
        {
            public int PrivilegeCount;
            public long LUID;
            public int Attributes;
        }
        public const int SE_PRIVILEGE_ENABLED = 0x00000002;
        public const int TOKEN_QUERY = 0x00000008;
        public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        public const int EWX_LOGOFF = 0x00000000;
        public const int EWX_SHUTDOWN = 0x00000001;
        public const int EWX_REBOOT = 0x00000002;
        public const int EWX_FORCE = 0x00000004;
        public const int EWX_POWEROFF = 0x00000008;
        public const int EWX_FORCEIFHUNG = 0x00000010;
        public static void ExitWindow(int flag)
        {
            bool result;
            IntPtr processHandle = GetCurrentProcess();
            IntPtr tokenHandle = IntPtr.Zero;
            result = OpenProcessToken(processHandle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref tokenHandle);
            TOKEN_PRIVILEGES tokenPrivileges;
            tokenPrivileges.PrivilegeCount = 1;
            tokenPrivileges.LUID = 0;
            tokenPrivileges.Attributes = SE_PRIVILEGE_ENABLED;
            result = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tokenPrivileges.LUID);
            result = AdjustTokenPrivileges(tokenHandle, false, ref tokenPrivileges, 0, IntPtr.Zero, IntPtr.Zero);
            result = ExitWindowsEx(flag, 0);
        }
        public static void Shutdown(bool forced = true)
        {
            if (forced)
            { ExitWindow(EWX_SHUTDOWN | EWX_FORCE); }
            else
            { ExitWindow(EWX_SHUTDOWN); }
        }
        public static void Reboot(bool forced = true)
        {
            if (forced)
            { ExitWindow(EWX_REBOOT | EWX_FORCE); }
            else
            { ExitWindow(EWX_REBOOT); }
        }
    }

    /*public class FileDownloader
    {
        private readonly string _url;
        private readonly string _fullPathWhereToSave;
        private bool _result = false;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public FileDownloader(string url, string fullPathWhereToSave)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            if (string.IsNullOrEmpty(fullPathWhereToSave)) throw new ArgumentNullException("fullPathWhereToSave");

            this._url = url;
            this._fullPathWhereToSave = fullPathWhereToSave;
        }

        public bool StartDownload(int timeout)
        {
            try
            {
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(_fullPathWhereToSave));

                if (File.Exists(_fullPathWhereToSave))
                {
                    File.Delete(_fullPathWhereToSave);
                }
                using (WebClient client = new WebClient())
                {
                    var ur = new Uri(_url);
                    // client.Credentials = new NetworkCredential("username", "password");
                    client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                    client.DownloadFileCompleted += WebClientDownloadCompleted;
                    Console.Write(@"Downloading file:");
                    client.DownloadFileAsync(ur, _fullPathWhereToSave);
                    _semaphore.Wait(timeout);
                    return _result && File.Exists(_fullPathWhereToSave);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Was not able to download file!");
                Console.Write(e);
                return false;
            }
            finally
            {
                this._semaphore.Dispose();
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\r     -->    {0}%.", e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            _result = !args.Cancelled;
            if (!_result)
            {
                Console.Write(args.Error.ToString());
            }
            Console.WriteLine(Environment.NewLine + "Download finished!");
            _semaphore.Release();
        }

        public static bool DownloadFile(string url, string fullPathWhereToSave, int timeoutInMilliSec)
        {
            return new FileDownloader(url, fullPathWhereToSave).StartDownload(timeoutInMilliSec);
        }
    }*/

    #endregion
}