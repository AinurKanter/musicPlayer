using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace MusicPlayer3
{


    public partial class Form1 : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private bool isPlaying = false;
        private bool isRepeating = false;

        private string filePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Aerosmith - Dream On (Re-record).mp3";
        public Form1()
        {
            InitializeComponent();
            LoadAudioFile();
            
        }

        private void LoadAudioFile()
        {
            try
            {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: " + ex.Message);
            }
        }


        private void ButStop_Click(object sender, EventArgs e)
        {
            StopPlayback();
        }

        private void ButRepeat_Click(object sender, EventArgs e)
        {
            isRepeating = !isRepeating;
            ButRepeat.Text = isRepeating ? "Repeat On" : "Repeat Off";
        }

        private void ButPlyer_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice != null)
            {
                waveOutDevice.Play();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isRepeating && audioFileReader != null)
            {
                audioFileReader.Position = 0;
                waveOutDevice.Play();
            }
        }

        // Остановка воспроизведения и освобождение ресурсов
        private void StopPlayback()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopPlayback();
            base.OnFormClosing(e);
        }

    }
}
