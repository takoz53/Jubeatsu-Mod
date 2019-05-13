namespace Jubeatsu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPick = new System.Windows.Forms.Button();
            this.fileDialogOsu = new System.Windows.Forms.OpenFileDialog();
            this.tbOsuFile = new System.Windows.Forms.TextBox();
            this.btnCreateStoryboard = new System.Windows.Forms.Button();
            this.saveFileOsb = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPick.Location = new System.Drawing.Point(233, 6);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "Pick";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.BtnPick_Click);
            // 
            // fileDialogOsu
            // 
            this.fileDialogOsu.FileName = "Beatmapname";
            this.fileDialogOsu.Filter = "Osu Beatmap|*.osu";
            // 
            // tbOsuFile
            // 
            this.tbOsuFile.Location = new System.Drawing.Point(12, 8);
            this.tbOsuFile.Name = "tbOsuFile";
            this.tbOsuFile.ReadOnly = true;
            this.tbOsuFile.Size = new System.Drawing.Size(215, 20);
            this.tbOsuFile.TabIndex = 1;
            this.tbOsuFile.Text = "Pick a .osu File";
            // 
            // btnCreateStoryboard
            // 
            this.btnCreateStoryboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateStoryboard.Enabled = false;
            this.btnCreateStoryboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateStoryboard.Location = new System.Drawing.Point(12, 34);
            this.btnCreateStoryboard.Name = "btnCreateStoryboard";
            this.btnCreateStoryboard.Size = new System.Drawing.Size(296, 31);
            this.btnCreateStoryboard.TabIndex = 2;
            this.btnCreateStoryboard.Text = "Create Storyboard for Jubeatsu";
            this.btnCreateStoryboard.UseVisualStyleBackColor = true;
            this.btnCreateStoryboard.Click += new System.EventHandler(this.BtnCreateStoryboard_Click);
            // 
            // saveFileOsb
            // 
            this.saveFileOsb.Filter = "Osb Files|*.osb";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(314, 34);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(296, 31);
            this.progressBar.TabIndex = 3;
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(314, 8);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(296, 23);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "Progress Status";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 91);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCreateStoryboard);
            this.Controls.Add(this.tbOsuFile);
            this.Controls.Add(this.btnPick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Jubeatsu Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.OpenFileDialog fileDialogOsu;
        private System.Windows.Forms.TextBox tbOsuFile;
        private System.Windows.Forms.Button btnCreateStoryboard;
        private System.Windows.Forms.SaveFileDialog saveFileOsb;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
    }
}

