namespace MusicPlayer3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButStop = new System.Windows.Forms.Button();
            this.ButRepeat = new System.Windows.Forms.Button();
            this.ButPlyer = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.NameMusic = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labRepaet = new System.Windows.Forms.Label();
            this.labVolume = new System.Windows.Forms.Label();
            this.labCurrentTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // ButStop
            // 
            this.ButStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButStop.BackgroundImage")));
            this.ButStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButStop.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ButStop.ForeColor = System.Drawing.Color.Cornsilk;
            this.ButStop.Location = new System.Drawing.Point(369, 219);
            this.ButStop.Name = "ButStop";
            this.ButStop.Size = new System.Drawing.Size(55, 36);
            this.ButStop.TabIndex = 0;
            this.ButStop.UseVisualStyleBackColor = true;
            this.ButStop.Click += new System.EventHandler(this.ButStop_Click);
            // 
            // ButRepeat
            // 
            this.ButRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButRepeat.BackgroundImage")));
            this.ButRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButRepeat.Location = new System.Drawing.Point(491, 219);
            this.ButRepeat.Name = "ButRepeat";
            this.ButRepeat.Size = new System.Drawing.Size(43, 36);
            this.ButRepeat.TabIndex = 1;
            this.ButRepeat.UseVisualStyleBackColor = true;
            this.ButRepeat.Click += new System.EventHandler(this.ButRepeat_Click);
            // 
            // ButPlyer
            // 
            this.ButPlyer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButPlyer.BackgroundImage")));
            this.ButPlyer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButPlyer.Location = new System.Drawing.Point(247, 219);
            this.ButPlyer.Name = "ButPlyer";
            this.ButPlyer.Size = new System.Drawing.Size(59, 36);
            this.ButPlyer.TabIndex = 2;
            this.ButPlyer.UseVisualStyleBackColor = true;
            this.ButPlyer.Click += new System.EventHandler(this.ButPlyer_Click);
            // 
            // NameMusic
            // 
            this.NameMusic.AutoSize = true;
            this.NameMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameMusic.Location = new System.Drawing.Point(335, 108);
            this.NameMusic.Name = "NameMusic";
            this.NameMusic.Size = new System.Drawing.Size(111, 25);
            this.NameMusic.TabIndex = 3;
            this.NameMusic.Text = "TextMusic";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Location = new System.Drawing.Point(247, 168);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(287, 45);
            this.trackBarPosition.TabIndex = 4;
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(341, 299);
            this.trackBarVolume.Maximum = 1;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(105, 45);
            this.trackBarVolume.TabIndex = 5;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labRepaet
            // 
            this.labRepaet.AutoSize = true;
            this.labRepaet.Location = new System.Drawing.Point(488, 258);
            this.labRepaet.Name = "labRepaet";
            this.labRepaet.Size = new System.Drawing.Size(12, 13);
            this.labRepaet.TabIndex = 6;
            this.labRepaet.Text = "\\";
            // 
            // labVolume
            // 
            this.labVolume.AutoSize = true;
            this.labVolume.Location = new System.Drawing.Point(375, 331);
            this.labVolume.Name = "labVolume";
            this.labVolume.Size = new System.Drawing.Size(27, 13);
            this.labVolume.TabIndex = 7;
            this.labVolume.Text = "70%";
            // 
            // labCurrentTime
            // 
            this.labCurrentTime.AutoSize = true;
            this.labCurrentTime.Location = new System.Drawing.Point(550, 181);
            this.labCurrentTime.Name = "labCurrentTime";
            this.labCurrentTime.Size = new System.Drawing.Size(28, 13);
            this.labCurrentTime.TabIndex = 8;
            this.labCurrentTime.Text = "0:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labCurrentTime);
            this.Controls.Add(this.labVolume);
            this.Controls.Add(this.labRepaet);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.NameMusic);
            this.Controls.Add(this.ButPlyer);
            this.Controls.Add(this.ButRepeat);
            this.Controls.Add(this.ButStop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButStop;
        private System.Windows.Forms.Button ButRepeat;
        private System.Windows.Forms.Button ButPlyer;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label NameMusic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labRepaet;
        private System.Windows.Forms.Label labVolume;
        private System.Windows.Forms.Label labCurrentTime;
    }
}

