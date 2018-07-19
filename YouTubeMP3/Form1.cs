using System;
using System.Windows.Forms;
using VideoLibrary;
using System.IO;
using MediaToolkit.Model;
using MediaToolkit;

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

                    labelStatus.Text = "Downloading... Please wait...";
                    File.WriteAllBytes(fbd.SelectedPath + video.FullName, await video.GetBytesAsync());

                    var inputFile = new MediaFile { Filename = fbd.SelectedPath + video.FullName };
                    var outputFile = new MediaFile { Filename = $"{fbd.SelectedPath + video.FullName}.mp3" };

                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputFile);
                        engine.Convert(inputFile, outputFile);
                    }

                    labelStatus.Text = "Completed!";
                }
            }
        }

        private void buttonLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.intengine.pl");
        }
    }
}