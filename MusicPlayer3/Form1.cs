using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace MusicPlayer3
{
    public partial class Form1 : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private bool isPlaying = false;
        private bool isRepeating = false;
        private Timer timer;
        private bool userIsDragging = false;  // Флаг для отслеживания взаимодействия пользователя с ползунком


        //private string filePath = @"F:\VisualStudio\musicPlayer\Aerosmith - Dream On (Re-record).mp3";
        private string filePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Aerosmith - Dream On (Re-record).mp3";

        public Form1()
        {
            InitializeComponent();
            LoadAudioFile();



            // Установка начального уровня громкости
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 70; // 70% громкости по умолчанию
            trackBarVolume.Scroll += trackBarVolume_Scroll;

            // Настройка таймера для обновления позиции ползунка
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

            labRepaet.Text = "Repeat off";
        }

        private void LoadAudioFile()
        {
            try
            {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.PlaybackStopped += WaveOutDevice_PlaybackStopped;

                // Устанавливаем максимальное значение для трека в зависимости от длины файла
                trackBarPosition.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: " + ex.Message);
            }
        }

        // Воспроизведение
        private void ButPlyer_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice != null)
            {
                if (waveOutDevice.PlaybackState == PlaybackState.Stopped)
                {
                    audioFileReader.Position = 0;
                }
                waveOutDevice.Play();
                timer.Start(); // Запуск таймера для обновления ползунка
                isPlaying = true;
            }
        }

        // Пауза
        private void PausePlayback()
        {
            if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                waveOutDevice.Pause();
                isPlaying = false;
            }
        }

        // Обработчик для кнопки паузы
        private void ButStop_Click(object sender, EventArgs e)
        {
            PausePlayback();
            timer.Stop(); // Остановка таймера при паузе
        }

        // Повтор воспроизведения
        private void ButRepeat_Click(object sender, EventArgs e)
        {
            isRepeating = !isRepeating;
            labRepaet.Text = isRepeating ? "Repeat On" : "Repeat Off";
        }

        // Обработчик события таймера для обновления позиции трека
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOutDevice.PlaybackState == PlaybackState.Playing && !userIsDragging)
            {
                trackBarPosition.Value = (int)audioFileReader.CurrentTime.TotalSeconds;
            }

            labCurrentTime.Text = FormatTime((int)audioFileReader.CurrentTime.TotalSeconds);
        }

        // Обработчик для изменения позиции воспроизведения с помощью ползунка
        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            if (audioFileReader != null && userIsDragging)
            {
                // Обновление позиции в момент перемещения ползунка
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackBarPosition.Value);

                // Обновляем метку текущего времени при перемещении ползунка
                labCurrentTime.Text = FormatTime(trackBarPosition.Value);
            }
        }

        // События для отслеживания начала и конца перемещения ползунка
        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            userIsDragging = true; // Пользователь начал перемещение ползунка
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            userIsDragging = false; // Пользователь отпустил ползунок
            if (audioFileReader != null)
            {
                // Устанавливаем позицию воспроизведения после того, как пользователь отпустил ползунок
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackBarPosition.Value);
            }
        }

        private void WaveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isRepeating && audioFileReader != null)
            {
                audioFileReader.Position = 0;      // Сброс позиции в начало
                waveOutDevice.Play();              // Перезапуск воспроизведения
                isPlaying = true;                  // Обновление флага состояния
            }
            else
            {
                timer.Stop(); // Остановка таймера, если воспроизведение завершено
                trackBarPosition.Value = 0; // Сброс ползунка в начало при завершении воспроизведения
                isPlaying = false; // Сброс флага состояния
            }
        }

        // Остановка воспроизведения и освобождение ресурсов
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
            if (audioFileReader != null) audioFileReader.Dispose();
            if (waveOutDevice != null) waveOutDevice.Dispose();
            timer.Dispose();
            base.OnFormClosing(e);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                // Устанавливаем громкость в зависимости от положения ползунка
                audioFileReader.Volume = trackBarVolume.Value / 100.0f;
            }

            labVolume.Text = trackBarVolume.Value + "%";



        }

        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }
    }
}
