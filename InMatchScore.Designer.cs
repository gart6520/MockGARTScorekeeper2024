namespace MockGARTScore
{
    partial class InMatchScore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            exitButton = new Button();
            canvas = new PictureBox();
            winsLabel = new Label();
            leftWins = new Label();
            rightWins = new Label();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Location = new Point(794, -3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(10, 10);
            exitButton.TabIndex = 0;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // canvas
            // 
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(800, 450);
            canvas.TabIndex = 1;
            canvas.TabStop = false;
            // 
            // winsLabel
            // 
            winsLabel.AutoSize = true;
            winsLabel.BackColor = Color.White;
            winsLabel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winsLabel.Location = new Point(317, 0);
            winsLabel.Name = "winsLabel";
            winsLabel.Size = new Size(187, 70);
            winsLabel.TabIndex = 2;
            winsLabel.Text = "WINS";
            // 
            // leftWins
            // 
            leftWins.AutoSize = true;
            leftWins.BackColor = Color.White;
            leftWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftWins.Location = new Point(248, 0);
            leftWins.Name = "leftWins";
            leftWins.Size = new Size(63, 70);
            leftWins.TabIndex = 3;
            leftWins.Text = "0";
            leftWins.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rightWins
            // 
            rightWins.AutoSize = true;
            rightWins.BackColor = Color.White;
            rightWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightWins.Location = new Point(510, 0);
            rightWins.Name = "rightWins";
            rightWins.Size = new Size(63, 70);
            rightWins.TabIndex = 4;
            rightWins.Text = "0";
            rightWins.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InMatchScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = exitButton;
            ClientSize = new Size(800, 450);
            Controls.Add(rightWins);
            Controls.Add(leftWins);
            Controls.Add(winsLabel);
            Controls.Add(canvas);
            Controls.Add(exitButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InMatchScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MockGARTInMatchScore";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private PictureBox canvas;
        private Label winsLabel;
        private Label leftWins;
        private Label rightWins;
    }
}
