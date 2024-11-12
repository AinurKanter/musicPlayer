using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using TagLib;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        private int triggerTimeInSeconds = 239; // Время для отображения GIF в секундах
        private bool volume = true;
        private Color dominantColor;


        private WaveInEvent waveIn; // Для захвата аудио
        private float[] audioData; // Данные для визуализации спектра
        private const int fftSize = 1024; // Размер FFT
        private Timer visualizationTimer; // Таймер для обновления визуализации


        //Пути к иконкам звука
        //private string volumeFileTrue = @"C:\Users\Admin\source\repos\MusicPlayer3\Картинки\белый звук.png"; 
        private string volumeFileTrue = @"F:\VisualStudio\musicPlayer\Картинки\белый звук.png";
        // private string volumeFileFalse = @"C:\Users\Admin\source\repos\MusicPlayer3\Картинки\белый нет звука.png";
        private string volumeFileFalse = @"F:\VisualStudio\musicPlayer\Картинки\белый нет звука.png";

//        private string filePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Aerosmith - Dream On (Re-record).mp3";
        private string filePath = @"F:\VisualStudio\musicPlayer\Aerosmith - Dream On (Re-record).mp3";

        private string gifFilePath = @"F:\VisualStudio\musicPlayer\Картинки\Кратос.gif"; // Путь к GIF-файлу
       // private string gifFilePath = @"C:\Users\Admin\source\repos\MusicPlayer3\Картинки\Кратос.gif"; // Путь к GIF-файлу
        private Image albumCover; // Сохраняем оригинальную обложку



        public Form1()
        {
            InitializeComponent();
            LoadAudioFile();

            dominantColor = GetDominantColor(pictureBoxCover.Image);

            // Установка начального уровня громкости
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 65;
            trackBarVolume.Scroll += trackBarVolume_Scroll;

            labVolume.Text = trackBarVolume.Value + "%";

            pictureVolume.Image = Image.FromFile(volumeFileTrue);


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
        //Метод определения цвета для градиента на фоне
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Создаём градиент, используя доминирующий цвет
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.Black,    // Черный для контраста (начальный цвет)
                                                                       dominantColor,  // Доминирующий цвет (конечный цвет)
                                                                       45F))           // Угол градиента
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }


        private Color GetDominantColor(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            int width = bitmap.Width;
            int height = bitmap.Height;

            long sumR = 0, sumG = 0, sumB = 0;
            int pixelCount = width * height;

            // Проходим по всем пикселям и суммируем значения цветов
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    sumR += pixelColor.R;
                    sumG += pixelColor.G;
                    sumB += pixelColor.B;
                }
            }

            // Вычисляем среднее значение для каждого цвета
            int avgR = (int)(sumR / pixelCount);
            int avgG = (int)(sumG / pixelCount);
            int avgB = (int)(sumB / pixelCount);

            return Color.FromArgb(avgR, avgG, avgB);  // Возвращаем средний цвет
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

        private void ButPlyer_Click_1(object sender, EventArgs e)
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

        private void ButStop_Click_1(object sender, EventArgs e)
        {
            PausePlayback();
            timer.Stop();
        }

        private void ButRepeat_Click_1(object sender, EventArgs e)
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

            if (userIsDragging == true)
            {
                labCurrentTime.Text = FormatTime((int)trackBarPosition.Value);

            }

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


        private void pictureVolume_Click(object sender, EventArgs e)
        {
            float tempVolume = trackBarVolume.Value ;
            if (volume == true)
            {
                
                pictureVolume.Image = Image.FromFile(volumeFileFalse);
                labVolume.Text = tempVolume + "%";
                audioFileReader.Volume = trackBarVolume.Value / 0f;
                volume = false;
            }
            else
            {
                volume = true;
                pictureVolume.Image = Image.FromFile(volumeFileTrue);
                audioFileReader.Volume = tempVolume / 100f;
                labVolume.Text = trackBarVolume.Value + "%";
            }
        }

        private void Butanekdot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Атрей: — Папа, почему мы постоянно путешествуем по разным мирам и воюем с богами?\r\n\r\nКратос, вздыхая: — Потому что так дешевле, чем ипотека.");
        }

        private void butRestart_Click(object sender, EventArgs e)
        {
            audioFileReader.Position = 0;
        }
        private int clickCount = 0;

        private void butlike_Click_1(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount == 5)
            {
                like like = new like();

                // Открываем вторую форму
                like.Show();
                labLike.Text = ":)";
                clickCount = 0;
            }
            else if (clickCount == 1)
            {
                labLike.Text = "Спасибо)";
            }
            else if (clickCount == 2)
            {
                labLike.Text = "Я это ценю)";
            }
            else if (clickCount == 3)
            {
                labLike.Text = "Ой... Ну хватит))))";
            }
            else if (clickCount == 4)
            {
                labLike.Text = "Ну давай ещё раз)";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
