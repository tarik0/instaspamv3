using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Controls;
using MetroSet_UI.Forms;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace instagram_spam_bot_v3
{
    public partial class Form2 : MetroSetForm
    {
        public MetroSetListBox accounts;
        public Action<Dictionary<string, Dictionary<string, string>>> online_accounts_callback;

        public Form2(MetroSetListBox accounts, Action<Dictionary<string, Dictionary<string, string>>> online_accounts_callback)
        {
            this.accounts = accounts;
            this.online_accounts_callback = online_accounts_callback;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            metroSetProgressBar1.Minimum = 0;
            metroSetProgressBar1.Maximum = this.accounts.Items.Count;
        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        class InstaSession {
            public HttpClient httpClient;
            public CookieContainer cookieContainer;
            public string cookie_str = @"rur=PRN; shbid=7184; shbts=1559309415.434849; ";
            public string csrftoken = "SfOe8iszDgUuiUPKo5zSqusBd2AeQdbX";
            public string mid = "XHwi-QALAAGyn-BcQlg6TVpVrTLX";
            public string shbid = "7123";
            public string shbts = "1559309415.434849";
            public Uri baseAddress;

            public InstaSession(string proxy_ip, int proxy_port)
            {
                HttpClientHandler handler;

                this.baseAddress = new Uri("https://www.instagram.com");
                this.cookieContainer = new CookieContainer();

                if (proxy_ip != null && proxy_port != 0)
                {
                    cookieContainer.Add(baseAddress, new Cookie("urlgen", "\"{\"" + proxy_ip + "\": 12735}:1hWhef:4nDtEZ_rmwETgqp8blPmsf561no\""));
                    cookie_str += "urlgen=\"{\"" + proxy_ip + "\": 12735}:1hWhef:4nDtEZ_rmwETgqp8blPmsf561no\"; "; 
                    handler = new HttpClientHandler()
                    {
                        Proxy = new WebProxy("http://185.130.144.207:55420"),
                        UseProxy = true,
                        CookieContainer = cookieContainer
                    };
                } else
                {
                    handler = new HttpClientHandler()
                    {
                        CookieContainer = cookieContainer
                    };
                }

                this.httpClient = new HttpClient(handler, true) { BaseAddress = baseAddress };
                cookieContainer.Add(baseAddress, new Cookie("rur", "PRN"));
                cookieContainer.Add(baseAddress, new Cookie("shbid", shbid));
                cookieContainer.Add(baseAddress, new Cookie("shbts", shbts));
            }
            public HttpResponseMessage Login(string path, string username, string password)
            {
                
                var message = new HttpRequestMessage(HttpMethod.Get, path);
                message.Headers.Add("Accept", "*/*");
                message.Headers.Add("Accept-Encoding", "gzip");
                message.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                message.Headers.Add("Cache-Control", "no-cache");
                message.Headers.Add("Connection", "keep-alive");         
                message.Headers.Add("Cookie", this.cookie_str);
                message.Headers.Add("Host", "www.instagram.com");
                message.Headers.Add("Pragma", "no-cache");
                message.Headers.Add("Referer", "https://www.instagram.com/accounts/login/");
                message.Headers.Add("TE", "Trailers");
                message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0");

                var result = this.httpClient.SendAsync(message).Result;
                var set_cookies = result.Headers.GetValues("set-cookie");
                foreach (var set_cookie in set_cookies){
                    foreach (var cookie in set_cookie.Split(';'))
                    {
                        if (cookie.StartsWith("csrftoken="))
                        {
                            var value = cookie.Split(new string[] { "csrftoken=" }, StringSplitOptions.None)[1];
                            this.csrftoken = value;
                            cookieContainer.Add(baseAddress, new Cookie("csrftoken", value));
                            this.cookie_str += "csrftoken=" + value + "; ";
                        } else if (cookie.StartsWith("mid="))
                        {
                            var value = cookie.Split(new string[] { "mid=" }, StringSplitOptions.None)[1];
                            this.mid = value;
                            this.cookie_str += "mid=" + value + "; ";
                            cookieContainer.Add(baseAddress, new Cookie("mid", value));
                        }
                    }
                }
                
                var content = new FormUrlEncodedContent(new[]
{
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("queryParams", "{}"),
                    new KeyValuePair<string, string>("optIntoOneTap", "true")
                });
                var loginMessage = new HttpRequestMessage(HttpMethod.Post, "/accounts/login/ajax/") { Content = content };

                /*
                var handler = new HttpClientHandler()
                {
                    CookieContainer = cookieContainer
                };
                this.httpClient = new HttpClient(handler, true) { BaseAddress = baseAddress };
                cookieContainer.Add(baseAddress, new Cookie("rur", "PRN"));
                cookieContainer.Add(baseAddress, new Cookie("shbid", "7184"));
                cookieContainer.Add(baseAddress, new Cookie("shbts", "1559309415.434849"));
                */

                //this.httpClient.BaseAddress = new Uri("http://scooterlabs.com");
                //var loginMessage = new HttpRequestMessage(HttpMethod.Post, "/echo") { Content = content };
                loginMessage.Headers.Add("Accept", "*/*");
                loginMessage.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                loginMessage.Headers.Add("Cache-Control", "no-cache");
                loginMessage.Headers.Add("Connection", "keep-alive");
                loginMessage.Content.Headers.ContentType  = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                loginMessage.Headers.Add("Cookie", this.cookie_str);
                loginMessage.Headers.Add("Host", "www.instagram.com");
                loginMessage.Headers.Add("Pragma", "no-cache");
                loginMessage.Headers.Add("Referer", "https://www.instagram.com/accounts/login/");
                loginMessage.Headers.Add("TE", "Trailers");
                loginMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0");
                loginMessage.Headers.Add("X-CSRFToken", this.csrftoken);
                loginMessage.Headers.Add("X-IG-App-ID", "936619743392458");
                loginMessage.Headers.Add("X-Instagram-AJAX", "0c2539981707");
                loginMessage.Headers.Add("X-Requested-With", "XMLHttpRequest");

                var login_result = this.httpClient.SendAsync(loginMessage).Result;

                return login_result;
            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Dictionary<string, Dictionary<string, string>> online_accounts = new Dictionary<string, Dictionary<string, string>>();
                foreach (string account_line in accounts.Items)
                {
                    string username = account_line.Split(' ')[0];
                    string password = account_line.Split(' ')[1];

                    if (this.metroSetLabel4.InvokeRequired)
                    {
                        this.listBox1.BeginInvoke((MethodInvoker)delegate () { this.metroSetLabel4.Text = username; });
                    }
                    else
                    {
                        this.metroSetLabel4.Text = username;
                    }
                    

                    var ses = new InstaSession(null, 0);

                    try
                    {
                        var login_result = ses.Login("/accounts/login/", username, password);
                        var cont = login_result.Content.ReadAsStringAsync().Result;

                        JObject json = JObject.Parse(cont);

                        if (json.Value<bool>("authenticated") == true && json.Value<bool>("user") == true)
                        {
                            if (this.listBox1.InvokeRequired)
                            {
                                this.listBox1.BeginInvoke((MethodInvoker)delegate () { this.listBox1.Items.Add(username); });
                            }
                            else
                            {
                                this.listBox1.Items.Add(username);
                            }
                            
                            string csrftoken = "";
                            string sessionid = "";
                            string urlgen = "";
                            string ds_user_id = "";
                            string shbid = "";
                            string shbts = "";
                            var set_cookies = login_result.Headers.GetValues("set-cookie");
                            foreach (var set_cookie in set_cookies)
                            {
                                foreach (var cookie in set_cookie.Split(';'))
                                {
                                    if (cookie.StartsWith("csrftoken="))
                                    {
                                        var value = cookie.Split(new string[] { "csrftoken=" }, StringSplitOptions.None)[1];
                                        csrftoken = value;
                                    }
                                    else if (cookie.StartsWith("sessionid="))
                                    {
                                        var value = cookie.Split(new string[] { "sessionid=" }, StringSplitOptions.None)[1];
                                        sessionid = value;
                                    }
                                    else if (cookie.StartsWith("urlgen="))
                                    {
                                        var value = cookie.Split(new string[] { "urlgen=" }, StringSplitOptions.None)[1];
                                        urlgen = value;
                                    }
                                    else if (cookie.StartsWith("ds_user_id="))
                                    {
                                        var value = cookie.Split(new string[] { "ds_user_id=" }, StringSplitOptions.None)[1];
                                        ds_user_id = value;
                                    }
                                    else if (cookie.StartsWith("shbid="))
                                    {
                                        var value = cookie.Split(new string[] { "urlgen=" }, StringSplitOptions.None)[1];
                                        shbid = value;
                                    }
                                    else if (cookie.StartsWith("shbts="))
                                    {
                                        var value = cookie.Split(new string[] { "shbts=" }, StringSplitOptions.None)[1];
                                        shbts = value;
                                    }
                                }
                            }

                            online_accounts.Add(username + " " + password, new Dictionary<string, string>() {
                            { "csrftoken", csrftoken },
                            { "mid", ses.mid},
                            { "sessionid", sessionid },
                            { "urlgen", "" },
                            { "ds_user_id", ds_user_id },
                            { "shbid", ses.shbid },
                            { "shbts", ses.shbts }
                            });
                        }
                        else
                        {
                            if (this.listBox2.InvokeRequired)
                            {
                                this.listBox2.BeginInvoke((MethodInvoker)delegate () { this.listBox2.Items.Add(username + " | Giriş bilgileri yanlış veya doğrulamaya düştü!"); });
                            }
                            else
                            {
                                listBox2.Items.Add(username + " | Giriş bilgileri yanlış veya doğrulamaya düştü!");
                            }
                            
                        }
                    }
                    catch (Exception exp)
                    {
                        if (this.listBox2.InvokeRequired)
                        {
                            this.listBox2.BeginInvoke((MethodInvoker)delegate () { this.listBox2.Items.Add(username + " | " + exp.Message); });
                        }
                        else
                        {
                            listBox2.Items.Add("[-] " +username + " | " + exp.Message);
                        }
                    }

                    if (this.metroSetProgressBar1.InvokeRequired)
                    {
                        this.metroSetProgressBar1.BeginInvoke((MethodInvoker)delegate () { metroSetProgressBar1.Value++; });
                    }
                    else
                    {
                        metroSetProgressBar1.Value++;
                    }

                    if (accounts.Items.IndexOf(account_line) + 1 >= accounts.Items.Count())
                    {

                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            MetroSetMessageBox.Show(this, "Giriş işlemleri yapıldı!", "Başarılı");
                            this.Hide();
                            online_accounts_callback(online_accounts);
                        });

                    }
                }
            });
            th.Start();

        }
    }
}
