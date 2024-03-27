using System.ComponentModel;

namespace MockGARTScore;

public partial class PostMatchScore
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        canvas = new PictureBox();
        teleOpCatLabel = new Label();
        endgameCatLabel = new Label();
        penaltyCatLabel = new Label();
        rightScore = new Label();
        leftScore = new Label();
        rightTeamName = new Label();
        leftTeamName = new Label();
        rightWins = new Label();
        leftWins = new Label();
        winsLabel = new Label();
        leftTeleOpScoreLabel = new Label();
        leftEndgameScoreLabel = new Label();
        leftPenaltyScoreLabel = new Label();
        rightPenaltyScoreLabel = new Label();
        rightEndgameScoreLabel = new Label();
        rightTeleOpScoreLabel = new Label();
        leftWinnerLabel = new Label();
        rightWinnerLabel = new Label();
        leftWinningCupImage = new PictureBox();
        rightWinningCupImage = new PictureBox();
        exitButton = new Button();
        ((ISupportInitialize)canvas).BeginInit();
        ((ISupportInitialize)leftWinningCupImage).BeginInit();
        ((ISupportInitialize)rightWinningCupImage).BeginInit();
        SuspendLayout();
        // 
        // canvas
        // 
        canvas.Location = new Point(0, 0);
        canvas.Name = "canvas";
        canvas.Padding = new Padding(4);
        canvas.Size = new Size(1280, 960);
        canvas.TabIndex = 0;
        canvas.TabStop = false;
        // 
        // teleOpCatLabel
        // 
        teleOpCatLabel.AutoSize = true;
        teleOpCatLabel.BackColor = Color.White;
        teleOpCatLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        teleOpCatLabel.Location = new Point(589, 247);
        teleOpCatLabel.Name = "teleOpCatLabel";
        teleOpCatLabel.Size = new Size(485, 74);
        teleOpCatLabel.TabIndex = 1;
        teleOpCatLabel.Text = "Driver Controlled";
        teleOpCatLabel.Click += teleOpCatLabel_Click;
        // 
        // endgameCatLabel
        // 
        endgameCatLabel.AutoSize = true;
        endgameCatLabel.BackColor = Color.White;
        endgameCatLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        endgameCatLabel.Location = new Point(574, 337);
        endgameCatLabel.Name = "endgameCatLabel";
        endgameCatLabel.Size = new Size(297, 74);
        endgameCatLabel.TabIndex = 2;
        endgameCatLabel.Text = "End Game";
        // 
        // penaltyCatLabel
        // 
        penaltyCatLabel.AutoSize = true;
        penaltyCatLabel.BackColor = Color.White;
        penaltyCatLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        penaltyCatLabel.Location = new Point(574, 424);
        penaltyCatLabel.Name = "penaltyCatLabel";
        penaltyCatLabel.Size = new Size(226, 74);
        penaltyCatLabel.TabIndex = 3;
        penaltyCatLabel.Text = "Penalty";
        // 
        // rightScore
        // 
        rightScore.AutoSize = true;
        rightScore.BackColor = Color.DodgerBlue;
        rightScore.Font = new Font("Arial", 96F, FontStyle.Bold, GraphicsUnit.Point, 0);
        rightScore.ForeColor = Color.White;
        rightScore.Location = new Point(879, 589);
        rightScore.Margin = new Padding(4, 0, 4, 0);
        rightScore.Name = "rightScore";
        rightScore.Size = new Size(199, 219);
        rightScore.TabIndex = 13;
        rightScore.Text = "0";
        rightScore.SizeChanged += rightScore_SizeChanged;
        // 
        // leftScore
        // 
        leftScore.AutoSize = true;
        leftScore.BackColor = Color.Red;
        leftScore.Font = new Font("Arial", 96F, FontStyle.Bold, GraphicsUnit.Point, 0);
        leftScore.ForeColor = Color.White;
        leftScore.Location = new Point(59, 577);
        leftScore.Margin = new Padding(4, 0, 4, 0);
        leftScore.Name = "leftScore";
        leftScore.Size = new Size(199, 219);
        leftScore.TabIndex = 12;
        leftScore.Text = "0";
        leftScore.SizeChanged += leftScore_SizeChanged;
        // 
        // rightTeamName
        // 
        rightTeamName.AutoSize = true;
        rightTeamName.BackColor = Color.DodgerBlue;
        rightTeamName.Font = new Font("Arial", 64.2000046F, FontStyle.Bold, GraphicsUnit.Point, 0);
        rightTeamName.ForeColor = Color.White;
        rightTeamName.Location = new Point(831, 25);
        rightTeamName.Margin = new Padding(4, 0, 4, 0);
        rightTeamName.Name = "rightTeamName";
        rightTeamName.Size = new Size(414, 149);
        rightTeamName.TabIndex = 11;
        rightTeamName.Text = "BLUE";
        rightTeamName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // leftTeamName
        // 
        leftTeamName.AutoSize = true;
        leftTeamName.BackColor = Color.Red;
        leftTeamName.Font = new Font("Arial", 64.2000046F, FontStyle.Bold, GraphicsUnit.Point, 0);
        leftTeamName.ForeColor = Color.White;
        leftTeamName.Location = new Point(19, 21);
        leftTeamName.Margin = new Padding(4, 0, 4, 0);
        leftTeamName.Name = "leftTeamName";
        leftTeamName.Size = new Size(335, 149);
        leftTeamName.TabIndex = 10;
        leftTeamName.Text = "RED";
        leftTeamName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // rightWins
        // 
        rightWins.AutoSize = true;
        rightWins.BackColor = Color.DodgerBlue;
        rightWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
        rightWins.ForeColor = Color.White;
        rightWins.Location = new Point(764, 4);
        rightWins.Margin = new Padding(4, 0, 4, 0);
        rightWins.Name = "rightWins";
        rightWins.Size = new Size(75, 84);
        rightWins.TabIndex = 16;
        rightWins.Text = "0";
        rightWins.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // leftWins
        // 
        leftWins.AutoSize = true;
        leftWins.BackColor = Color.Red;
        leftWins.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
        leftWins.ForeColor = Color.White;
        leftWins.Location = new Point(437, 0);
        leftWins.Margin = new Padding(4, 0, 4, 0);
        leftWins.Name = "leftWins";
        leftWins.Size = new Size(75, 84);
        leftWins.TabIndex = 15;
        leftWins.Text = "0";
        leftWins.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // winsLabel
        // 
        winsLabel.AutoSize = true;
        winsLabel.BackColor = Color.White;
        winsLabel.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
        winsLabel.Location = new Point(523, 0);
        winsLabel.Margin = new Padding(4, 0, 4, 0);
        winsLabel.Name = "winsLabel";
        winsLabel.Size = new Size(224, 84);
        winsLabel.TabIndex = 14;
        winsLabel.Text = "WINS";
        // 
        // leftTeleOpScoreLabel
        // 
        leftTeleOpScoreLabel.AutoSize = true;
        leftTeleOpScoreLabel.BackColor = Color.DarkGoldenrod;
        leftTeleOpScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        leftTeleOpScoreLabel.ForeColor = Color.White;
        leftTeleOpScoreLabel.Location = new Point(392, 247);
        leftTeleOpScoreLabel.Name = "leftTeleOpScoreLabel";
        leftTeleOpScoreLabel.Size = new Size(128, 74);
        leftTeleOpScoreLabel.TabIndex = 17;
        leftTeleOpScoreLabel.Text = "200";
        leftTeleOpScoreLabel.SizeChanged += leftTeleOpScoreLabel_TextChanged;
        // 
        // leftEndgameScoreLabel
        // 
        leftEndgameScoreLabel.AutoSize = true;
        leftEndgameScoreLabel.BackColor = Color.DarkGoldenrod;
        leftEndgameScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        leftEndgameScoreLabel.ForeColor = Color.White;
        leftEndgameScoreLabel.Location = new Point(392, 337);
        leftEndgameScoreLabel.Name = "leftEndgameScoreLabel";
        leftEndgameScoreLabel.Size = new Size(64, 74);
        leftEndgameScoreLabel.TabIndex = 18;
        leftEndgameScoreLabel.Text = "0";
        leftEndgameScoreLabel.SizeChanged += leftEndgameScoreLabel_TextChanged;
        // 
        // leftPenaltyScoreLabel
        // 
        leftPenaltyScoreLabel.AutoSize = true;
        leftPenaltyScoreLabel.BackColor = Color.DarkGoldenrod;
        leftPenaltyScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        leftPenaltyScoreLabel.ForeColor = Color.White;
        leftPenaltyScoreLabel.Location = new Point(392, 424);
        leftPenaltyScoreLabel.Name = "leftPenaltyScoreLabel";
        leftPenaltyScoreLabel.Size = new Size(64, 74);
        leftPenaltyScoreLabel.TabIndex = 19;
        leftPenaltyScoreLabel.Text = "0";
        leftPenaltyScoreLabel.SizeChanged += leftPenaltyScoreLabel_TextChanged;
        // 
        // rightPenaltyScoreLabel
        // 
        rightPenaltyScoreLabel.AutoSize = true;
        rightPenaltyScoreLabel.BackColor = Color.DarkBlue;
        rightPenaltyScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        rightPenaltyScoreLabel.ForeColor = Color.White;
        rightPenaltyScoreLabel.Location = new Point(1089, 424);
        rightPenaltyScoreLabel.Name = "rightPenaltyScoreLabel";
        rightPenaltyScoreLabel.Size = new Size(64, 74);
        rightPenaltyScoreLabel.TabIndex = 22;
        rightPenaltyScoreLabel.Text = "0";
        rightPenaltyScoreLabel.SizeChanged += rightPenaltyScoreLabel_TextChanged;
        // 
        // rightEndgameScoreLabel
        // 
        rightEndgameScoreLabel.AutoSize = true;
        rightEndgameScoreLabel.BackColor = Color.DarkBlue;
        rightEndgameScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        rightEndgameScoreLabel.ForeColor = Color.White;
        rightEndgameScoreLabel.Location = new Point(1089, 337);
        rightEndgameScoreLabel.Name = "rightEndgameScoreLabel";
        rightEndgameScoreLabel.Size = new Size(64, 74);
        rightEndgameScoreLabel.TabIndex = 21;
        rightEndgameScoreLabel.Text = "0";
        rightEndgameScoreLabel.SizeChanged += rightEndgameScoreLabel_TextChanged;
        // 
        // rightTeleOpScoreLabel
        // 
        rightTeleOpScoreLabel.AutoSize = true;
        rightTeleOpScoreLabel.BackColor = Color.DarkBlue;
        rightTeleOpScoreLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        rightTeleOpScoreLabel.ForeColor = Color.White;
        rightTeleOpScoreLabel.Location = new Point(1089, 247);
        rightTeleOpScoreLabel.Name = "rightTeleOpScoreLabel";
        rightTeleOpScoreLabel.Size = new Size(128, 74);
        rightTeleOpScoreLabel.TabIndex = 20;
        rightTeleOpScoreLabel.Text = "200";
        rightTeleOpScoreLabel.SizeChanged += rightTeleOpScoreLabel_TextChanged;
        // 
        // leftWinnerLabel
        // 
        leftWinnerLabel.AutoSize = true;
        leftWinnerLabel.BackColor = Color.Yellow;
        leftWinnerLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        leftWinnerLabel.ForeColor = Color.Black;
        leftWinnerLabel.Location = new Point(131, 10);
        leftWinnerLabel.Name = "leftWinnerLabel";
        leftWinnerLabel.Size = new Size(261, 74);
        leftWinnerLabel.TabIndex = 23;
        leftWinnerLabel.Text = "WINNER";
        // 
        // rightWinnerLabel
        // 
        rightWinnerLabel.AutoSize = true;
        rightWinnerLabel.BackColor = Color.Yellow;
        rightWinnerLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        rightWinnerLabel.ForeColor = Color.Black;
        rightWinnerLabel.Location = new Point(892, 0);
        rightWinnerLabel.Name = "rightWinnerLabel";
        rightWinnerLabel.Size = new Size(261, 74);
        rightWinnerLabel.TabIndex = 24;
        rightWinnerLabel.Text = "WINNER";
        // 
        // leftWinningCupImage
        // 
        leftWinningCupImage.BackColor = Color.Yellow;
        leftWinningCupImage.Image = Properties.Resources.winningCup;
        leftWinningCupImage.Location = new Point(366, 63);
        leftWinningCupImage.Name = "leftWinningCupImage";
        leftWinningCupImage.Size = new Size(150, 75);
        leftWinningCupImage.SizeMode = PictureBoxSizeMode.Zoom;
        leftWinningCupImage.TabIndex = 25;
        leftWinningCupImage.TabStop = false;
        // 
        // rightWinningCupImage
        // 
        rightWinningCupImage.BackColor = Color.Yellow;
        rightWinningCupImage.Image = Properties.Resources.winningCup;
        rightWinningCupImage.Location = new Point(924, 42);
        rightWinningCupImage.Name = "rightWinningCupImage";
        rightWinningCupImage.Size = new Size(150, 75);
        rightWinningCupImage.SizeMode = PictureBoxSizeMode.Zoom;
        rightWinningCupImage.TabIndex = 26;
        rightWinningCupImage.TabStop = false;
        // 
        // exitButton
        // 
        exitButton.Location = new Point(0, 0);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(0, 0);
        exitButton.TabIndex = 27;
        exitButton.Text = "esc";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += exitButton_Click;
        // 
        // PostMatchScore
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = exitButton;
        ClientSize = new Size(1258, 904);
        Controls.Add(exitButton);
        Controls.Add(rightWinningCupImage);
        Controls.Add(leftWinningCupImage);
        Controls.Add(rightWinnerLabel);
        Controls.Add(leftWinnerLabel);
        Controls.Add(rightPenaltyScoreLabel);
        Controls.Add(rightEndgameScoreLabel);
        Controls.Add(rightTeleOpScoreLabel);
        Controls.Add(leftPenaltyScoreLabel);
        Controls.Add(leftEndgameScoreLabel);
        Controls.Add(leftTeleOpScoreLabel);
        Controls.Add(rightWins);
        Controls.Add(leftWins);
        Controls.Add(winsLabel);
        Controls.Add(rightScore);
        Controls.Add(leftScore);
        Controls.Add(rightTeamName);
        Controls.Add(leftTeamName);
        Controls.Add(penaltyCatLabel);
        Controls.Add(endgameCatLabel);
        Controls.Add(teleOpCatLabel);
        Controls.Add(canvas);
        Name = "PostMatchScore";
        Text = "PostMatch";
        ((ISupportInitialize)canvas).EndInit();
        ((ISupportInitialize)leftWinningCupImage).EndInit();
        ((ISupportInitialize)rightWinningCupImage).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox canvas;
    private Label teleOpCatLabel;
    private Label endgameCatLabel;
    private Label penaltyCatLabel;
    private Label rightScore;
    private Label leftScore;
    private Label rightTeamName;
    private Label leftTeamName;
    private Label rightWins;
    private Label leftWins;
    private Label winsLabel;
    private Label leftTeleOpScoreLabel;
    private Label leftEndgameScoreLabel;
    private Label leftPenaltyScoreLabel;
    private Label rightPenaltyScoreLabel;
    private Label rightEndgameScoreLabel;
    private Label rightTeleOpScoreLabel;
    private Label leftWinnerLabel;
    private Label rightWinnerLabel;
    private PictureBox leftWinningCupImage;
    private PictureBox rightWinningCupImage;
    private Button exitButton;
}