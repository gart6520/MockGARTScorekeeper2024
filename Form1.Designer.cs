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
            // InMatchScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = exitButton;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InMatchScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MockGARTInMatchScore";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button exitButton;

        void exitButton_Click(object sender, EventArgs e)
        {
            // Exit
            Application.Exit();
        }
    }
}
