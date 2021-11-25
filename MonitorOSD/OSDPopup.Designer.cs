
namespace MonitorOSD
{
    partial class OSDPopup
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.smoothProgressBar = new SmoothProgressBar.SmoothProgressBar();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.currentStepLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(17, 32);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(349, 37);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(16, 165);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(350, 44);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Stäng";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(17, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(349, 23);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "KARDX00000000";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smoothProgressBar
            // 
            this.smoothProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.smoothProgressBar.Location = new System.Drawing.Point(16, 72);
            this.smoothProgressBar.Maximum = 100;
            this.smoothProgressBar.Minimum = 0;
            this.smoothProgressBar.Name = "smoothProgressBar";
            this.smoothProgressBar.ProgressBarColor = System.Drawing.Color.Blue;
            this.smoothProgressBar.Size = new System.Drawing.Size(350, 30);
            this.smoothProgressBar.TabIndex = 3;
            this.smoothProgressBar.Value = 0;
            // 
            // stepsLabel
            // 
            this.stepsLabel.BackColor = System.Drawing.Color.Transparent;
            this.stepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsLabel.Location = new System.Drawing.Point(0, 0);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(350, 30);
            this.stepsLabel.TabIndex = 4;
            this.stepsLabel.Text = "steg x av z";
            this.stepsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentStepLabel
            // 
            this.currentStepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStepLabel.Location = new System.Drawing.Point(16, 105);
            this.currentStepLabel.Name = "currentStepLabel";
            this.currentStepLabel.Size = new System.Drawing.Size(350, 57);
            this.currentStepLabel.TabIndex = 5;
            this.currentStepLabel.Text = "Nuvarande steg";
            this.currentStepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OSDPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(378, 221);
            this.Controls.Add(this.currentStepLabel);
            this.Controls.Add(this.stepsLabel);
            this.Controls.Add(this.smoothProgressBar);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.statusLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OSDPopup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSDPopup";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label nameLabel;
        private SmoothProgressBar.SmoothProgressBar smoothProgressBar;
        private System.Windows.Forms.Label stepsLabel;
        private System.Windows.Forms.Label currentStepLabel;
    }
}