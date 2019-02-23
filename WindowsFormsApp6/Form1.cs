using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.ValueMember = "Path";
            listBox1.DisplayMember = "FileName";
        }
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        private List<MediaFile> Playlist = new List<MediaFile>();

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        Playlist.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    listBox1.DataSource = Playlist;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile Video = listBox1.SelectedItem as MediaFile;
            if (Video != null)
            {
                axWindowsMediaPlayer1.URL = Video.Path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private static GlobalVariable NewMethod1(GlobalVariable resume)
        {
            return NewMethod(resume);
        }

        private static GlobalVariable NewMethod(GlobalVariable resume)
        {
            return GetResume(resume);
        }

        private static GlobalVariable GetResume(GlobalVariable resume)
        {
            return resume;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1.Ctlcontrols.currentPositionString!="" && axWindowsMediaPlayer1.Ctlcontrols.currentPositionString == axWindowsMediaPlayer1.currentMedia.durationString)
            {
                try
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                }
                catch { }
            }
            clock.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            axWindowsMediaPlayer1.URL = "";
            listBox1.DataSource = null;
            Playlist.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }
    }
}
