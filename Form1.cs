using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using Newtonsoft.Json.Linq;

namespace instagram_spam_bot_v3
{
    public partial class Form1 : MetroSetForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> online_account_list = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MetroSetMessageBox.Show(this, "eyy","Hoop burdayım");
        }

        private void metroSetButton4_Click(object sender, EventArgs e)
        {
            if (metroSetListBox1.SelectedIndex == -1 || metroSetListBox1.Items.Count == 0)
            {
                MetroSetMessageBox.Show(this, "Lütfen önce bir hesap seçiniz!", "Hata");
                return;
            }
            metroSetListBox1.Items.Remove(metroSetListBox1.Items[metroSetListBox1.SelectedIndex]);
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            if (metroSetTextBox1.Text == null || metroSetTextBox1.Text == "")
            {
                MetroSetMessageBox.Show(this, "Lütfen kullanıcı adı ve şifre boşluğunu doldurunuz!", "Hata");
                return;
            }
            if (metroSetTextBox2.Text == null || metroSetTextBox2.Text == "")
            {
                MetroSetMessageBox.Show(this, "Lütfen kullanıcı adı ve şifre boşluğunu doldurunuz!", "Hata");
                return;
            }
            if (metroSetListBox1.Items.Contains(metroSetTextBox1.Text + " " + metroSetTextBox2.Text))
            {
                MetroSetMessageBox.Show(this, "Bu kullanıcı zaten yüklü!", "Hata");
                return;
            }
            metroSetListBox1.Items.Add(metroSetTextBox1.Text + " " + metroSetTextBox2.Text);
        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "TXT Dosyası |*.txt";  
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Bir TXT Dosyası Seçiniz..";
            file.ShowDialog();

            metroSetTextBox3.Text = file.FileName;
        }

        private void metroSetButton3_Click(object sender, EventArgs e)
        {
            if (metroSetTextBox3.Text == "")
            {
                MetroSetMessageBox.Show(this, "Lütfen bir dosya yolu yazınız!", "Hata");
                return;
            }

            if (!File.Exists(metroSetTextBox3.Text))
            {
                MetroSetMessageBox.Show(this, "Dosya bulunamadı! Dosya yolunu kontrol edin!", "Hata");
                return;
            };

            string[] lines = File.ReadAllLines(metroSetTextBox3.Text, Encoding.Default);

            foreach (string line in lines)
            {
                string[] split_line = line.Split(' ');
                if (split_line.Length < 2)
                {
                    continue;
                }

                string username = split_line[0];
                string password = split_line[1];

                if (!metroSetListBox1.Items.Contains(username + " " + password))
                {
                    metroSetListBox1.Items.Add(username + " " + password);
                }
            }
        }

        public Dictionary<string, Dictionary<string, string>> online_accounts;
        public void online_accounts_callback(Dictionary<string, Dictionary<string, string>> online_accounts)
        {
            metroSetButton5.Enabled = true;
            this.metroSetLabel32.Text = online_accounts.Count.ToString();
            this.online_accounts = online_accounts;
            foreach (KeyValuePair<string, Dictionary<string, string>> entry in online_accounts)
            {
                metroSetListBox2.Items.Add(entry.Key);
            }
        }

        private void metroSetButton5_Click(object sender, EventArgs e)
        {
            metroSetButton5.Enabled = false;
            var listbox = metroSetListBox1;
            foreach (var logged_accounts in metroSetListBox2.Items)
            {
                listbox.Items.Remove(logged_accounts);
            }
            
            if (listbox.Items.Count == 0)
            {
                MetroSetMessageBox.Show(this, "Bütün hesaplar zaten giriş yaptı!", "Hata");
                return;
            }

            Form2 form2 = new Form2(listbox, online_accounts_callback);
            form2.Show();
        }

        private void metroSetButton6_Click(object sender, EventArgs e)
        {
            if (metroSetTextBox4.Text == "")
            {
                MetroSetMessageBox.Show(this, "Lütfen bir kullanıcı adı girin!", "Hata");
                return;
            }
            try
            {
                var url = "https://www.instagram.com/" + metroSetTextBox4.Text + "/?__a=1";

                HttpClient httpClient = new HttpClient();

                var doc = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(doc);
                string id = json["graphql"]["user"].Value<string>("id");
                string profile_photo_url = json["graphql"]["user"].Value<string>("profile_pic_url");
                metroSetLabel11.Text = id;
                pictureBox3.Load(profile_photo_url);
            } catch (Newtonsoft.Json.JsonReaderException){
                MetroSetMessageBox.Show(this, "Kullanıcı bulunamadı!", "Hata");
                return;
            }       
        }

        private void metroSetListBox2_SelectedIndexChanged(object sender)
        {

        }

        private void metroSetTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroSetTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroSetListBox1_SelectedIndexChanged(object sender)
        {

        }

        private void metroSetLabel13_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel8_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel9_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel11_Click(object sender, EventArgs e)
        {

        }

        private void metroSetListBox3_SelectedIndexChanged(object sender)
        {

        }

        private void metroSetLabel12_Click(object sender, EventArgs e)
        {

        }

        private void metroSetDivider1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetButton7_Click(object sender, EventArgs e)
        {
            if (metroSetLabel11.Text == "0")
            {
                MetroSetMessageBox.Show(this, "Önce bir spamlanacak kullanıcı seçmelisiniz!", "Hata");
                return;
            }

            if (metroSetComboBox1.SelectedIndex == -1)
            {
                MetroSetMessageBox.Show(this, "Lütfen bir şikayet sebebi seçin!", "Hata");
                return;
            }

            if (metroSetListBox2.Items.Count == 0)
            {
                MetroSetMessageBox.Show(this, "Lütfen önce bir hesaba giriş yapın!", "Hata");
                return;
            }

            this.BeginInvoke((MethodInvoker)delegate () {
                this.metroSetButton7.Enabled = false;
                MetroSetMessageBox.Show(this, "Şikayet işlemleri başlıyor!", "Başlar");
            });

            Thread t1 = new Thread(() =>
            {
                string reason_id = "0";

                this.metroSetComboBox1.BeginInvoke((MethodInvoker)delegate () {
                    switch (metroSetComboBox1.SelectedItem)
                    {
                        case "Spam":
                            reason_id = "1";
                            break;

                        case "Kendine Zarar Verme":
                            reason_id = "2";
                            break;

                        case "Uyuşturucu":
                            reason_id = "3";
                            break;

                        case "Çıplaklık":
                            reason_id = "4";
                            break;

                        case "Şiddet":
                            reason_id = "5";
                            break;

                        case "Nefret Söylemi":
                            reason_id = "6";
                            break;

                        case "Taciz ve Zorbalık":
                            reason_id = "7";
                            break;

                        case "Kimlik Taklidi":
                            reason_id = "8";
                            break;

                        case "Yaşı Tutmayan Çocuk":
                            reason_id = "11";
                            break;
                    }
                });

                foreach (var line in metroSetListBox2.Items)
                {
                    var username = line.ToString().Split(' ')[0];
                    var cookies = online_accounts[line.ToString()];
                    try
                    {
                        HttpClientHandler handler;

                        var baseAddress = new Uri("https://www.instagram.com");
                        var cookieContainer = new CookieContainer();

                        handler = new HttpClientHandler()
                        {
                            CookieContainer = cookieContainer
                        };

                        var httpClient = new HttpClient(handler, true) { BaseAddress = baseAddress };
                        var cookie_str = "rur=ASH; ";
                        cookieContainer.Add(baseAddress, new Cookie("csrftoken", cookies["csrftoken"]));
                        cookie_str += "csrftoken=" + cookies["csrftoken"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("ds_user_id", cookies["ds_user_id"]));
                        cookie_str += "ds_user_id=" + cookies["ds_user_id"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("mid", cookies["mid"]));
                        cookie_str += "mid=" + cookies["mid"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("rur", "ASH"));
                        cookieContainer.Add(baseAddress, new Cookie("sessionid", cookies["sessionid"]));
                        cookie_str += "sessionid=" + cookies["sessionid"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("shbid", cookies["shbid"]));
                        cookie_str += "shbid=" + cookies["shbid"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("shbts", cookies["shbts"]));
                        cookie_str += "shbts=" + cookies["shbts"] + "; ";
                        cookieContainer.Add(baseAddress, new Cookie("urlgen", cookies["urlgen"]));
                        cookie_str += "urlgen=" + cookies["urlgen"] + "; ";

                        var content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("source_name", username),
                            new KeyValuePair<string, string>("reason_id", reason_id),
                        });
                        var reportMessage = new HttpRequestMessage(HttpMethod.Post, "/users/" + metroSetLabel11.Text + "/report/") { Content = content };
                        reportMessage.Headers.Add("Accept", "*/*");
                        reportMessage.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                        reportMessage.Headers.Add("Cache-Control", "no-cache");
                        reportMessage.Headers.Add("Connection", "keep-alive");
                        reportMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                        reportMessage.Headers.Add("Cookie", cookie_str);
                        reportMessage.Headers.Add("Host", "www.instagram.com");
                        reportMessage.Headers.Add("Pragma", "no-cache");
                        reportMessage.Headers.Add("Referer", "https://www.instagram.com/accounts/login/");
                        reportMessage.Headers.Add("TE", "Trailers");
                        reportMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0");
                        reportMessage.Headers.Add("X-CSRFToken", cookies["csrftoken"]);
                        reportMessage.Headers.Add("X-IG-App-ID", "936619743392458");
                        reportMessage.Headers.Add("X-Instagram-AJAX", "0c2539981707");
                        reportMessage.Headers.Add("X-Requested-With", "XMLHttpRequest");

                        var report_result = httpClient.SendAsync(reportMessage).Result;
                        var res = report_result.Content.ReadAsStringAsync().Result;

                        if (res.StartsWith("<!DOCTYPE"))
                        {
                            this.metroSetListBox3.BeginInvoke((MethodInvoker)delegate () {
                                metroSetListBox3.Items.Add("[-] " + username + " | Kullanıcı çok fazla şikayet attı! " + res);
                            });
                            return;
                        }

                        JObject json = JObject.Parse(res);

                        if (json.Value<string>("status") == "ok" && json.Value<string>("description").StartsWith("We take"))
                        {
                            this.metroSetListBox3.BeginInvoke((MethodInvoker)delegate () {
                                metroSetListBox3.Items.Add("[+] " +  username + " | Başarıyla şikayet edildi! " + res);
                            });

                            this.metroSetLabel16.BeginInvoke((MethodInvoker)delegate () {
                                metroSetLabel16.Text = (Convert.ToInt32(metroSetLabel16.Text) + 1).ToString();
                            });
                        }
                        else
                        {
                            this.metroSetListBox3.BeginInvoke((MethodInvoker)delegate () {
                                metroSetListBox3.Items.Add("[-] " + username + " | Şikayet başarısız! " + res);
                            });

                            this.metroSetLabel17.BeginInvoke((MethodInvoker)delegate () {
                                metroSetLabel17.Text = (Convert.ToInt32(metroSetLabel16.Text) + 1).ToString();
                            });
                        }
                    } catch (Exception exp)
                    {
                        this.metroSetListBox3.BeginInvoke((MethodInvoker)delegate () {
                            metroSetListBox3.Items.Add("[-] " + username + " | Şikayet atarken bir hata oluştu! " + exp.Message);
                        });

                        this.metroSetLabel17.BeginInvoke((MethodInvoker)delegate () {
                            metroSetLabel17.Text = (Convert.ToInt32(metroSetLabel16.Text) + 1).ToString();
                        });
                    }
                }

                this.BeginInvoke((MethodInvoker)delegate () {
                    MetroSetMessageBox.Show(this, "Şikayet işlemleri tamamlandı!", "Bitti");
                    this.metroSetButton7.Enabled = true;
                });
            });

            t1.Start();

        }
    }
}
