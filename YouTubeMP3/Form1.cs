using System;
using System.Windows.Forms;

namespace YouTubeMP3
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("youtube-url").SetAttribute("value", textBox1.Text);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("submit").InvokeMember("click");
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            HtmlElement dl_link = webBrowser1.Document.GetElementById("dl_link");
            HtmlElementCollection link = dl_link.GetElementsByTagName("a");

            string Url = link[0].GetAttribute("href");

            System.Diagnostics.Process.Start(Url);
        }
    }
}