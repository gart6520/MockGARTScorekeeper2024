﻿namespace MockGARTScore
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
            components = new System.ComponentModel.Container();
            exitButton = new Button();
            canvas = new PictureBox();
            winsLabel = new Label();
            leftWins = new Label();
            rightWins = new Label();
            timerText = new Label();
            leftTeamName = new Label();
            rightTeamName = new Label();
            leftScore = new Label();
            rightScore = new Label();
            leftHatch = new PictureBox();
            rightHatch = new PictureBox();
            leftFuelLabel = new Label();
            rightFuelLabel = new Label();
            rightFuel = new Label();
            leftFuel = new Label();
            leftParkNo = new PictureBox();
            leftParkHalf = new PictureBox();
            leftParkFull = new PictureBox();
            rightParkFull = new PictureBox();
            rightParkHalf = new PictureBox();
            rightParkNo = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftHatch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightHatch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftParkNo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftParkHalf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftParkFull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightParkFull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightParkHalf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightParkNo).BeginInit();
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
            canvas.Size = new Size(1024, 768);
            canvas.TabIndex = 1;
            canvas.TabStop = false;
            // 
            // winsLabel
            // 
            winsLabel.AutoSize = true;
            winsLabel.BackColor = Color.White;
            winsLabel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winsLabel.Location = new Point(416, -3);
            winsLabel.Name = "winsLabel";
            winsLabel.Size = new Size(187, 70);
            winsLabel.TabIndex = 2;
            winsLabel.Text = "WINS";
            // 
            // leftWins
            // 
            leftWins.AutoSize = true;
            leftWins.BackColor = Color.Red;
            leftWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftWins.ForeColor = Color.White;
            leftWins.Location = new Point(347, -3);
            leftWins.Name = "leftWins";
            leftWins.Size = new Size(63, 70);
            leftWins.TabIndex = 3;
            leftWins.Text = "0";
            leftWins.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rightWins
            // 
            rightWins.AutoSize = true;
            rightWins.BackColor = Color.DodgerBlue;
            rightWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightWins.ForeColor = Color.White;
            rightWins.Location = new Point(609, 0);
            rightWins.Name = "rightWins";
            rightWins.Size = new Size(63, 70);
            rightWins.TabIndex = 4;
            rightWins.Text = "0";
            rightWins.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timerText
            // 
            timerText.AutoSize = true;
            timerText.BackColor = Color.White;
            timerText.Font = new Font("Arial", 96F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timerText.Location = new Point(268, 195);
            timerText.Name = "timerText";
            timerText.Size = new Size(486, 183);
            timerText.TabIndex = 5;
            timerText.Text = "00:00";
            // 
            // leftTeamName
            // 
            leftTeamName.AutoSize = true;
            leftTeamName.BackColor = Color.Red;
            leftTeamName.Font = new Font("Arial", 64.2000046F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftTeamName.ForeColor = Color.White;
            leftTeamName.Location = new Point(29, -3);
            leftTeamName.Name = "leftTeamName";
            leftTeamName.Size = new Size(280, 124);
            leftTeamName.TabIndex = 6;
            leftTeamName.Text = "RED";
            leftTeamName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rightTeamName
            // 
            rightTeamName.AutoSize = true;
            rightTeamName.BackColor = Color.DodgerBlue;
            rightTeamName.Font = new Font("Arial", 64.2000046F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightTeamName.ForeColor = Color.White;
            rightTeamName.Location = new Point(678, 0);
            rightTeamName.Name = "rightTeamName";
            rightTeamName.Size = new Size(346, 124);
            rightTeamName.TabIndex = 7;
            rightTeamName.Text = "BLUE";
            rightTeamName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // leftScore
            // 
            leftScore.AutoSize = true;
            leftScore.BackColor = Color.Red;
            leftScore.Font = new Font("Arial", 96F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftScore.ForeColor = Color.White;
            leftScore.Location = new Point(81, 195);
            leftScore.Name = "leftScore";
            leftScore.Size = new Size(166, 183);
            leftScore.TabIndex = 8;
            leftScore.Text = "0";
            // 
            // rightScore
            // 
            rightScore.AutoSize = true;
            rightScore.BackColor = Color.DodgerBlue;
            rightScore.Font = new Font("Arial", 96F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightScore.ForeColor = Color.White;
            rightScore.Location = new Point(772, 195);
            rightScore.Name = "rightScore";
            rightScore.Size = new Size(166, 183);
            rightScore.TabIndex = 9;
            rightScore.Text = "0";
            // 
            // leftHatch
            // 
            leftHatch.BackColor = Color.Red;
            leftHatch.Image = Properties.Resources.tanknohatch;
            leftHatch.Location = new Point(150, 393);
            leftHatch.Name = "leftHatch";
            leftHatch.Size = new Size(156, 221);
            leftHatch.TabIndex = 10;
            leftHatch.TabStop = false;
            // 
            // rightHatch
            // 
            rightHatch.BackColor = Color.DodgerBlue;
            rightHatch.Image = Properties.Resources.tanknohatch;
            rightHatch.Location = new Point(740, 393);
            rightHatch.Name = "rightHatch";
            rightHatch.Size = new Size(156, 221);
            rightHatch.TabIndex = 11;
            rightHatch.TabStop = false;
            // 
            // leftFuelLabel
            // 
            leftFuelLabel.AutoSize = true;
            leftFuelLabel.BackColor = Color.Red;
            leftFuelLabel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftFuelLabel.ForeColor = Color.White;
            leftFuelLabel.Location = new Point(29, 534);
            leftFuelLabel.Name = "leftFuelLabel";
            leftFuelLabel.Size = new Size(154, 70);
            leftFuelLabel.TabIndex = 12;
            leftFuelLabel.Text = "Fuel";
            // 
            // rightFuelLabel
            // 
            rightFuelLabel.AutoSize = true;
            rightFuelLabel.BackColor = Color.DodgerBlue;
            rightFuelLabel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightFuelLabel.ForeColor = Color.White;
            rightFuelLabel.Location = new Point(830, 534);
            rightFuelLabel.Name = "rightFuelLabel";
            rightFuelLabel.Size = new Size(154, 70);
            rightFuelLabel.TabIndex = 13;
            rightFuelLabel.Text = "Fuel";
            // 
            // rightFuel
            // 
            rightFuel.AutoSize = true;
            rightFuel.BackColor = Color.DodgerBlue;
            rightFuel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rightFuel.ForeColor = Color.White;
            rightFuel.Location = new Point(691, 534);
            rightFuel.Name = "rightFuel";
            rightFuel.Size = new Size(63, 70);
            rightFuel.TabIndex = 14;
            rightFuel.Text = "0";
            // 
            // leftFuel
            // 
            leftFuel.AutoSize = true;
            leftFuel.BackColor = Color.Red;
            leftFuel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leftFuel.ForeColor = Color.White;
            leftFuel.Location = new Point(268, 534);
            leftFuel.Name = "leftFuel";
            leftFuel.Size = new Size(63, 70);
            leftFuel.TabIndex = 15;
            leftFuel.Text = "0";
            // 
            // leftParkNo
            // 
            leftParkNo.BackColor = Color.Red;
            leftParkNo.Image = Properties.Resources.nopark;
            leftParkNo.Location = new Point(7, 613);
            leftParkNo.Name = "leftParkNo";
            leftParkNo.Size = new Size(143, 143);
            leftParkNo.SizeMode = PictureBoxSizeMode.CenterImage;
            leftParkNo.TabIndex = 16;
            leftParkNo.TabStop = false;
            // 
            // leftParkHalf
            // 
            leftParkHalf.BackColor = Color.Red;
            leftParkHalf.Image = Properties.Resources.partialpark;
            leftParkHalf.Location = new Point(156, 613);
            leftParkHalf.Name = "leftParkHalf";
            leftParkHalf.Size = new Size(143, 143);
            leftParkHalf.SizeMode = PictureBoxSizeMode.CenterImage;
            leftParkHalf.TabIndex = 17;
            leftParkHalf.TabStop = false;
            // 
            // leftParkFull
            // 
            leftParkFull.Anchor = AnchorStyles.None;
            leftParkFull.BackColor = Color.Red;
            leftParkFull.Image = Properties.Resources.fullpark;
            leftParkFull.InitialImage = Properties.Resources.fullpark;
            leftParkFull.Location = new Point(305, 613);
            leftParkFull.Name = "leftParkFull";
            leftParkFull.Size = new Size(143, 143);
            leftParkFull.SizeMode = PictureBoxSizeMode.CenterImage;
            leftParkFull.TabIndex = 18;
            leftParkFull.TabStop = false;
            // 
            // rightParkFull
            // 
            rightParkFull.BackColor = Color.DodgerBlue;
            rightParkFull.Image = Properties.Resources.fullpark;
            rightParkFull.Location = new Point(874, 613);
            rightParkFull.Name = "rightParkFull";
            rightParkFull.Size = new Size(143, 143);
            rightParkFull.SizeMode = PictureBoxSizeMode.CenterImage;
            rightParkFull.TabIndex = 21;
            rightParkFull.TabStop = false;
            // 
            // rightParkHalf
            // 
            rightParkHalf.BackColor = Color.DodgerBlue;
            rightParkHalf.Image = Properties.Resources.partialpark;
            rightParkHalf.Location = new Point(725, 613);
            rightParkHalf.Name = "rightParkHalf";
            rightParkHalf.Size = new Size(143, 143);
            rightParkHalf.SizeMode = PictureBoxSizeMode.CenterImage;
            rightParkHalf.TabIndex = 20;
            rightParkHalf.TabStop = false;
            // 
            // rightParkNo
            // 
            rightParkNo.BackColor = Color.DodgerBlue;
            rightParkNo.Image = Properties.Resources.nopark;
            rightParkNo.Location = new Point(576, 613);
            rightParkNo.Name = "rightParkNo";
            rightParkNo.Size = new Size(143, 143);
            rightParkNo.SizeMode = PictureBoxSizeMode.CenterImage;
            rightParkNo.TabIndex = 22;
            rightParkNo.TabStop = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            // 
            // InMatchScore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = exitButton;
            ClientSize = new Size(1024, 768);
            Controls.Add(rightParkNo);
            Controls.Add(rightParkFull);
            Controls.Add(rightParkHalf);
            Controls.Add(leftParkFull);
            Controls.Add(leftParkHalf);
            Controls.Add(leftParkNo);
            Controls.Add(leftFuel);
            Controls.Add(rightFuel);
            Controls.Add(rightFuelLabel);
            Controls.Add(leftFuelLabel);
            Controls.Add(rightHatch);
            Controls.Add(leftHatch);
            Controls.Add(rightScore);
            Controls.Add(leftScore);
            Controls.Add(rightTeamName);
            Controls.Add(leftTeamName);
            Controls.Add(timerText);
            Controls.Add(rightWins);
            Controls.Add(leftWins);
            Controls.Add(winsLabel);
            Controls.Add(canvas);
            Controls.Add(exitButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InMatchScore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MockGARTInMatchScore";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftHatch).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightHatch).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftParkNo).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftParkHalf).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftParkFull).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightParkFull).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightParkHalf).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightParkNo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private PictureBox canvas;
        private Label winsLabel;
        private Label leftWins;
        private Label rightWins;
        private Label timerText;
        private Label leftTeamName;
        private Label rightTeamName;
        private Label leftScore;
        private Label rightScore;
        private PictureBox leftHatch;
        private PictureBox rightHatch;
        private Label leftFuelLabel;
        private Label rightFuelLabel;
        private Label rightFuel;
        private Label leftFuel;
        private PictureBox leftParkNo;
        private PictureBox leftParkHalf;
        private PictureBox leftParkFull;
        private PictureBox rightParkFull;
        private PictureBox rightParkHalf;
        private PictureBox rightParkNo;
        private System.Windows.Forms.Timer timer;
    }
}