﻿namespace MusicPlayer3
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
            this.labMusicTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labRepaet = new System.Windows.Forms.Label();
            this.labVolume = new System.Windows.Forms.Label();
            this.labCurrentTime = new System.Windows.Forms.Label();
            this.maxCurrentTime = new System.Windows.Forms.Label();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.checkBoxGif = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.SuspendLayout();
            // 
            // ButStop
            // 
            this.ButStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButStop.BackgroundImage")));
            this.ButStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButStop.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ButStop.ForeColor = System.Drawing.Color.Cornsilk;
            this.ButStop.Location = new System.Drawing.Point(167, 222);
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
            this.ButRepeat.Location = new System.Drawing.Point(289, 222);
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
            this.ButPlyer.Location = new System.Drawing.Point(45, 222);
            this.ButPlyer.Name = "ButPlyer";
            this.ButPlyer.Size = new System.Drawing.Size(59, 36);
            this.ButPlyer.TabIndex = 2;
            this.ButPlyer.UseVisualStyleBackColor = true;
            this.ButPlyer.Click += new System.EventHandler(this.ButPlyer_Click);
            // 
            // labMusicTitle
            // 
            this.labMusicTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labMusicTitle.AutoSize = true;
            this.labMusicTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labMusicTitle.Location = new System.Drawing.Point(40, 113);
            this.labMusicTitle.Name = "labMusicTitle";
            this.labMusicTitle.Size = new System.Drawing.Size(139, 25);
            this.labMusicTitle.TabIndex = 3;
            this.labMusicTitle.Text = "labMusicTitle";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Location = new System.Drawing.Point(45, 171);
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(287, 45);
            this.trackBarPosition.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(139, 302);
            this.trackBarVolume.Maximum = 1;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(105, 45);
            this.trackBarVolume.TabIndex = 5;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labRepaet
            // 
            this.labRepaet.AutoSize = true;
            this.labRepaet.Location = new System.Drawing.Point(286, 261);
            this.labRepaet.Name = "labRepaet";
            this.labRepaet.Size = new System.Drawing.Size(12, 13);
            this.labRepaet.TabIndex = 6;
            this.labRepaet.Text = "\\";
            // 
            // labVolume
            // 
            this.labVolume.AutoSize = true;
            this.labVolume.Location = new System.Drawing.Point(173, 334);
            this.labVolume.Name = "labVolume";
            this.labVolume.Size = new System.Drawing.Size(27, 13);
            this.labVolume.TabIndex = 7;
            this.labVolume.Text = "70%";
            // 
            // labCurrentTime
            // 
            this.labCurrentTime.AutoSize = true;
            this.labCurrentTime.Location = new System.Drawing.Point(11, 183);
            this.labCurrentTime.Name = "labCurrentTime";
            this.labCurrentTime.Size = new System.Drawing.Size(28, 13);
            this.labCurrentTime.TabIndex = 8;
            this.labCurrentTime.Text = "0:00";
            // 
            // maxCurrentTime
            // 
            this.maxCurrentTime.AutoSize = true;
            this.maxCurrentTime.Location = new System.Drawing.Point(339, 183);
            this.maxCurrentTime.Name = "maxCurrentTime";
            this.maxCurrentTime.Size = new System.Drawing.Size(28, 13);
            this.maxCurrentTime.TabIndex = 9;
            this.maxCurrentTime.Text = "0:00";
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(420, 31);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(354, 343);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCover.TabIndex = 10;
            this.pictureBoxCover.TabStop = false;
            // 
            // checkBoxGif
            // 
            this.checkBoxGif.AutoSize = true;
            this.checkBoxGif.Checked = true;
            this.checkBoxGif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxGif.Location = new System.Drawing.Point(420, 397);
            this.checkBoxGif.Name = "checkBoxGif";
            this.checkBoxGif.Size = new System.Drawing.Size(59, 22);
            this.checkBoxGif.TabIndex = 11;
            this.checkBoxGif.Text = "Мем";
            this.checkBoxGif.UseVisualStyleBackColor = true;
            this.checkBoxGif.CheckedChanged += new System.EventHandler(this.checkBoxGif_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxGif);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.maxCurrentTime);
            this.Controls.Add(this.labCurrentTime);
            this.Controls.Add(this.labVolume);
            this.Controls.Add(this.labRepaet);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.labMusicTitle);
            this.Controls.Add(this.ButPlyer);
            this.Controls.Add(this.ButRepeat);
            this.Controls.Add(this.ButStop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButStop;
        private System.Windows.Forms.Button ButRepeat;
        private System.Windows.Forms.Button ButPlyer;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label labMusicTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labRepaet;
        private System.Windows.Forms.Label labVolume;
        private System.Windows.Forms.Label labCurrentTime;
        private System.Windows.Forms.Label maxCurrentTime;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.CheckBox checkBoxGif;
    }
}

