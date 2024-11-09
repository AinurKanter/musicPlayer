using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using TagLib;
using System.Drawing;

namespace MusicPlayer3
{
    public partial class Form1 : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private bool isPlaying = false;
        private bool isRepeating = false;
        private Timer timer;
        private Timer gifTimer; // Таймер для возврата к обложке после завершения GIF
        private bool userIsDragging = false;
        private bool gifShown = false; // Флаг для отображения GIF только один раз
        private int triggerTimeInSeconds = 240; // Время для отображения GIF в секундах
 

        private string filePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Aerosmith - Dream On (Re-record).mp3";
        private string gifFilePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Картинки\Кратос.gif"; // Путь к GIF-файлу
        private Image albumCover; // Сохраняем оригинальную обложку

        

        public Form1()
        {
            InitializeComponent();
            LoadAudioFile();

            // Установка начального уровня громкости
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 65;
            trackBarVolume.Scroll += trackBarVolume_Scroll;

            labVolume.Text = trackBarVolume.Value + "%";

            // Получаем название файла без пути и расширения
            string musicTitle = Path.GetFileNameWithoutExtension(filePath);
            labMusicTitle.Text = musicTitle;

            // Настройка таймера для обновления позиции ползунка
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

            // Таймер для возврата обложки после завершения GIF
            gifTimer = new Timer();
            gifTimer.Interval = 29000; // Настройка времени, равного длительности GIF
            gifTimer.Tick += GifTimer_Tick;

            labRepaet.Text = "Repeat off";
            checkBoxGif.Checked = true;

            // Подписка на события для trackBarPosition
            trackBarPosition.Scroll += trackBarPosition_Scroll;
            trackBarPosition.MouseDown += trackBarPosition_MouseDown;
            trackBarPosition.MouseUp += trackBarPosition_MouseUp;
        }

        private void LoadAudioFile()
        {
            try
            {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;

                trackBarPosition.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                maxCurrentTime.Text = FormatTime((int)audioFileReader.TotalTime.TotalSeconds);

                // Загружаем обложку или GIF в PictureBox
                TagLib.File tagFile = TagLib.File.Create(filePath);
                if (tagFile.Tag.Pictures.Length > 0)
                {
                    var bin = tagFile.Tag.Pictures[0].Data.Data;
                    using (var ms = new MemoryStream(bin))
                    {
                        albumCover = Image.FromStream(ms); // Сохраняем оригинальную обложку
                        pictureBoxCover.Image = albumCover;
                        pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pictureBoxCover.Image = null;
                    MessageBox.Show("No image");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: " + ex.Message);
            }
        }

        private void ButPlyer_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice != null)
            {
                if (waveOutDevice.PlaybackState == PlaybackState.Stopped)
                {
                    audioFileReader.Position = 0;
                }
                waveOutDevice.Play();
                timer.Start();
                isPlaying = true;
            }
        }

        private void PausePlayback()
        {
            if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                waveOutDevice.Pause();
                isPlaying = false;
            }
        }

        private void ButStop_Click(object sender, EventArgs e)
        {
            PausePlayback();
            timer.Stop();
        }

        private void ButRepeat_Click(object sender, EventArgs e)
        {
            isRepeating = !isRepeating;
            labRepaet.Text = isRepeating ? "Repeat On" : "Repeat Off";
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice.PlaybackState == PlaybackState.Playing && !userIsDragging)
            {
                trackBarPosition.Value = (int)audioFileReader.CurrentTime.TotalSeconds;
            }
            labCurrentTime.Text = FormatTime((int)audioFileReader.CurrentTime.TotalSeconds);

            // Показать GIF в заданное время
            if ((int)audioFileReader.CurrentTime.TotalSeconds >= triggerTimeInSeconds && !gifShown && checkBoxGif.Checked == true)
            {
                ShowGif();
                gifShown = true; // Устанавливаем флаг, чтобы GIF отображался только один раз
            }
        }

        private void ShowGif()
        {
            pictureBoxCover.Image = Image.FromFile(gifFilePath);
            pictureBoxCover.SizeMode = PictureBoxSizeMode.StretchImage;

            gifTimer.Start(); // Запускаем таймер для возврата к обложке
        }

        private void GifTimer_Tick(object sender, EventArgs e)
        {
            pictureBoxCover.Image = albumCover; // Возвращаем исходную обложку
            gifTimer.Stop(); // Останавливаем таймер после возврата обложки
        }

        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Если воспроизведение завершилось и включен режим повторения
            if (isRepeating)
            {
                audioFileReader.Position = 0; // Возвращаем трек в начало
                waveOutDevice.Play();         // Запускаем воспроизведение
                timer.Start();                // Перезапускаем таймер
                isPlaying = true;             // Устанавливаем флаг воспроизведения в true
            }
            else
            {
                // Если не нужно повторять, останавливаем все
                timer.Stop();
                trackBarPosition.Value = 0;
                isPlaying = false;
                gifShown = false; // Сброс флага для GIF при завершении трека
                LoadAudioFile();  // Загружаем начальную обложку
            }
        }


        private void StopPlayback()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                isPlaying = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopPlayback();
            audioFileReader?.Dispose();
            waveOutDevice?.Dispose();
            timer.Dispose();
            gifTimer.Dispose();
            base.OnFormClosing(e);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = trackBarVolume.Value / 100.0f;
            }
            labVolume.Text = trackBarVolume.Value + "%";
        }

        // Управление ползунком позиции трека
        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            if (audioFileReader != null && userIsDragging)
            {
                labCurrentTime.Text = FormatTime(trackBarPosition.Value);
            }
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            userIsDragging = true;
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            userIsDragging = false;
            if (audioFileReader != null)
            {
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackBarPosition.Value);
            }
        }

        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }

        private void checkBoxGif_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
