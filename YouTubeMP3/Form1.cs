using System;
using System.Windows.Forms;
using VideoLibrary;
using MediaToolkit;
using System.IO;

namespace YouTubeMP3
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(textURL.Text);
                    labelStatus.Text = "Downloading...";
                    File.WriteAllBytes(fbd.SelectedPath + video.FullName, await video.GetBytesAsync());
                    labelStatus.Text = "Completed!";
                }
            }
        }
    }
}