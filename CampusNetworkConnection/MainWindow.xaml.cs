using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ConfigApp
{
    public partial class MainWindow : Window
    {
        public class Config
        {
            public string Url { get; set; }
            public Dictionary<string, string> FormData { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public bool AutoExecute { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        private async Task LoadConfig()
        {
            string configFilePath = "config.json";

            if (!File.Exists(configFilePath))
            {
                MessageBox.Show("配置文件不存在，请输入配置信息。");
                return;
            }

            try
            {
                string json = await File.ReadAllTextAsync(configFilePath);
                var config = JsonConvert.DeserializeObject<Config>(json);

                // 填充输入框
                UrlTextBox.Text = config.Url;
                UserIdTextBox.Text = config.FormData["userId"];
                PasswordTextBox.Password = config.FormData["password"];
                ServiceTextBox.Text = config.FormData["service"];
                QueryStringTextBox.Text = config.FormData["queryString"];
                OperatorPwdTextBox.Text = config.FormData["operatorPwd"];
                OperatorUserIdTextBox.Text = config.FormData["operatorUserId"];
                ValidCodeTextBox.Text = config.FormData["validcode"];
                PasswordEncryptTextBox.Text = config.FormData["passwordEncrypt"];

                HostTextBox.Text = config.Headers["Host"];
                ConnectionTextBox.Text = config.Headers["Connection"];
                UserAgentTextBox.Text = config.Headers["User-Agent"];
                AcceptTextBox.Text = config.Headers["Accept"];
                OriginTextBox.Text = config.Headers["Origin"];
                RefererTextBox.Text = config.Headers["Referer"];
                AcceptEncodingTextBox.Text = config.Headers["Accept-Encoding"];
                AcceptLanguageTextBox.Text = config.Headers["Accept-Language"];
                CookieTextBox.Text = config.Headers["Cookie"];

                // 如果需要自动执行，则直接调用连接方法
                if (config.AutoExecute)
                {
                    await SendPostRequest(config);
                    Close(); // 可选，执行完后关闭窗口
                }
            }
            catch (JsonException)
            {
                MessageBox.Show("配置文件格式错误，请重新输入配置信息。");
            }
        }
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var config = new Config
            {
                Url = UrlTextBox.Text,
                FormData = new Dictionary<string, string>
                {
                    { "userId", UserIdTextBox.Text },
                    { "password", PasswordTextBox.Password },
                    { "service", ServiceTextBox.Text },
                    { "queryString", QueryStringTextBox.Text },
                    { "operatorPwd", OperatorPwdTextBox.Text },
                    { "operatorUserId", OperatorUserIdTextBox.Text },
                    { "validcode", ValidCodeTextBox.Text },
                    { "passwordEncrypt", PasswordEncryptTextBox.Text }
                },
                Headers = new Dictionary<string, string>
                {
                    { "Host", HostTextBox.Text },
                    { "Connection", ConnectionTextBox.Text },
                    { "User-Agent", UserAgentTextBox.Text },
                    { "Accept", AcceptTextBox.Text },
                    { "Origin", OriginTextBox.Text },
                    { "Referer", RefererTextBox.Text },
                    { "Accept-Encoding", AcceptEncodingTextBox.Text },
                    { "Accept-Language", AcceptLanguageTextBox.Text },
                    { "Cookie", CookieTextBox.Text }
                },
                AutoExecute = AutoExecuteCheckBox.IsChecked == true
            };

            try
            {
                await SaveConfigToFile("config.json", config);
                MessageBox.Show("配置已保存。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }

        private async Task SaveConfigToFile(string path, Config config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
        }

        private async Task SendPostRequest(Config config)
        {
            using (var client = new HttpClient())
            {
                foreach (var h in config.Headers)
                {
                    client.DefaultRequestHeaders.Add(h.Key, h.Value);
                }

                var content = new FormUrlEncodedContent(config.FormData);

                try
                {
                    var response = await client.PostAsync(config.Url, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("校园网登录成功");
                    }
                    else
                    {
                        MessageBox.Show("校园网登陆失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"请求失败: {ex.Message}");
                }
            }
        }

        private async void LoadConfigButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadConfig();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            var config = new Config
            {
                Url = UrlTextBox.Text,
                FormData = new Dictionary<string, string>
                {
                    { "userId", UserIdTextBox.Text },
                    { "password", PasswordTextBox.Password },
                    { "service", ServiceTextBox.Text },
                    { "queryString", QueryStringTextBox.Text },
                    { "operatorPwd", OperatorPwdTextBox.Text },
                    { "operatorUserId", OperatorUserIdTextBox.Text },
                    { "validcode", ValidCodeTextBox.Text },
                    { "passwordEncrypt", PasswordEncryptTextBox.Text }
                },
                Headers = new Dictionary<string, string>
                {
                    { "Host", HostTextBox.Text },
                    { "Connection", ConnectionTextBox.Text },
                    { "User-Agent", UserAgentTextBox.Text },
                    { "Accept", AcceptTextBox.Text },
                    { "Origin", OriginTextBox.Text },
                    { "Referer", RefererTextBox.Text },
                    { "Accept-Encoding", AcceptEncodingTextBox.Text },
                    { "Accept-Language", AcceptLanguageTextBox.Text },
                    { "Cookie", CookieTextBox.Text }
                }
            };

            await SendPostRequest(config);
        }
    }
}
