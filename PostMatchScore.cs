using static MockGARTScore.GameStat;

namespace MockGARTScore;

public partial class PostMatchScore : Form
{
    int w;
    int h;
    readonly Color DarkerRed = Color.FromArgb(200, 0, 0);
    public event EventHandler GoBack = null!;
    private int winner = 0; // -1 is left 0 is tie 1 is right

    public PostMatchScore()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;
        Size = Screen.PrimaryScreen.Bounds.Size;

        canvas.Location = new Point();
        canvas.Size = Size;
        canvas.Paint += Canvas_Paint;

        Activated += (_, _) => UpdateScore();

        w = Width;
        h = Height;

        // Align score category labels
        teleOpCatLabel.Location =
            new Point(w / 2 - teleOpCatLabel.Size.Width / 2, 11 * h / 30 - teleOpCatLabel.Height / 2);
        endgameCatLabel.Location =
            new Point(w / 2 - endgameCatLabel.Size.Width / 2, h / 2 - endgameCatLabel.Height / 2);
        penaltyCatLabel.Location =
            new Point(w / 2 - penaltyCatLabel.Size.Width / 2, 19 * h / 30 - penaltyCatLabel.Height / 2);

        // Align score labels
        leftTeleOpScoreLabel.BackColor = DarkerRed;
        leftEndgameScoreLabel.BackColor = DarkerRed;
        leftPenaltyScoreLabel.BackColor = DarkerRed;
        leftTeleOpScoreLabel.Location = new Point(7 * w / 24 - leftTeleOpScoreLabel.Width / 2,
            11 * h / 30 - leftTeleOpScoreLabel.Height / 2);
        leftEndgameScoreLabel.Location = new Point(7 * w / 24 - leftEndgameScoreLabel.Width / 2,
            h / 2 - leftEndgameScoreLabel.Height / 2);
        leftPenaltyScoreLabel.Location = new Point(7 * w / 24 - leftPenaltyScoreLabel.Width / 2,
            19 * h / 30 - leftPenaltyScoreLabel.Height / 2);

        rightTeleOpScoreLabel.BackColor = Color.DarkBlue;
        rightEndgameScoreLabel.BackColor = Color.DarkBlue;
        rightPenaltyScoreLabel.BackColor = Color.DarkBlue;
        rightTeleOpScoreLabel.Location = new Point(17 * w / 24 - rightTeleOpScoreLabel.Width / 2,
            11 * h / 30 - rightTeleOpScoreLabel.Height / 2);
        rightEndgameScoreLabel.Location = new Point(17 * w / 24 - rightEndgameScoreLabel.Width / 2,
            h / 2 - rightEndgameScoreLabel.Height / 2);
        rightPenaltyScoreLabel.Location = new Point(17 * w / 24 - rightPenaltyScoreLabel.Width / 2,
            19 * h / 30 - rightPenaltyScoreLabel.Height / 2);

        // Set team name
        leftTeamName.Text = LeftColor == Color.Red ? "RED" : "BLUE";
        rightTeamName.Text = RightColor == Color.DodgerBlue ? "BLUE" : "RED";

        // Align team names
        leftTeamName.Location = new Point(
            w / 6 - leftTeamName.Width / 2,
            h / 8);
        rightTeamName.Location = new Point(
            w * 5 / 6 - rightTeamName.Width / 2,
            h / 8);

        // Align team scores
        leftScore.Location = new Point(
            w / 6 - leftScore.Width / 2,
            9 * h / 10 - leftScore.Height);
        rightScore.Location = new Point(
            w * 5 / 6 - rightScore.Width / 2,
            9 * h / 10 - rightScore.Height);

        // Align the "Wins" label to the center
        winsLabel.Location = new Point(
            (w - winsLabel.Size.Width) / 2,
            (h / 10 - winsLabel.Size.Height) / 2);

        // Align the leftWins and rightWins label
        leftWins.Location = new Point(
            w / 3 + w / 24 - leftWins.Size.Width / 2,
            (h / 10 - leftWins.Size.Height) / 2);
        rightWins.Location = new Point(
            w / 3 + w * 7 / 24 - rightWins.Size.Width / 2,
            (h / 10 - rightWins.Size.Height) / 2);

        UpdateScore();
    }

    private void UpdateScore()
    {
        //TODO add score for endgame

        leftEndgameScoreLabel.Text = LeftParkStatus switch
        {
            0 => "0",
            1 => "20",
            2 => "30",
            _ => leftEndgameScoreLabel.Text
        };
        
        rightEndgameScoreLabel.Text = RightParkStatus switch
        {
            0 => "0",
            1 => "20",
            2 => "30",
            _ => rightEndgameScoreLabel.Text
        };
        
        leftPenaltyScoreLabel.Text = LeftPenalty.ToString();
        rightPenaltyScoreLabel.Text = RightPenalty.ToString();

        leftTeleOpScoreLabel.Text = (LeftFuelLevel * 2 + (LeftHatchStatus ? 20 : 0)).ToString();
        rightTeleOpScoreLabel.Text = (RightFuelLevel * 2 + (RightHatchStatus ? 20 : 0)).ToString();

        leftWins.Text = LeftWin.ToString();
        rightWins.Text = RightWin.ToString();

        leftScore.Text = LeftScore.ToString();
        rightScore.Text = RightScore.ToString();

        leftWinnerLabel.Text = @"WINNER";
        rightWinnerLabel.Text = @"WINNER";
        if (LeftScore > RightScore) winner = -1;
        else if (LeftScore < RightScore) winner = 1;
        else
        {
            leftWinnerLabel.Text = @"TIE";
            rightWinnerLabel.Text = @"TIE";
            winner = 0;
        }

        canvas.Refresh();
    }

    protected override bool ShowWithoutActivation => true;

    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        // Canvas size
        int w = canvas.Size.Width;
        int h = canvas.Size.Height;

        //Draw sereperator line
        g.FillRectangle(new SolidBrush(LeftColor), new Rectangle(0, 0, w / 2, h));
        g.FillRectangle(new SolidBrush(RightColor), new Rectangle(w / 2, 0, w / 2, h));
        g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), new Point(w / 2, 0), new Point(w / 2, h));

        //Draw category box
        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(w / 3, 19 * h / 60, w / 3, h / 10));
        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(w / 3, 9 * h / 20, w / 3, h / 10));
        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(w / 3, 7 * h / 12, w / 3, h / 10));

        // Draw category score box
        g.FillRectangle(new SolidBrush(DarkerRed), new Rectangle(w / 4, 19 * h / 60, w / 12, h / 10));
        g.FillRectangle(new SolidBrush(DarkerRed), new Rectangle(w / 4, 9 * h / 20, w / 12, h / 10));
        g.FillRectangle(new SolidBrush(DarkerRed), new Rectangle(w / 4, 7 * h / 12, w / 12, h / 10));
        g.FillRectangle(new SolidBrush(Color.DarkBlue), new Rectangle(2 * w / 3, 19 * h / 60, w / 12, h / 10));
        g.FillRectangle(new SolidBrush(Color.DarkBlue), new Rectangle(2 * w / 3, 9 * h / 20, w / 12, h / 10));
        g.FillRectangle(new SolidBrush(Color.DarkBlue), new Rectangle(2 * w / 3, 7 * h / 12, w / 12, h / 10));

        // Draw champion box
        leftWinningCupImage.Visible = false;
        leftWinnerLabel.Visible = false;
        rightWinningCupImage.Visible = false;
        rightWinnerLabel.Visible = false;
        if (winner == -1)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(0, h / 120, w / 2, h / 12));
            leftWinnerLabel.Location = new Point(w / 30, h / 20 - leftWinnerLabel.Height / 2);
            leftWinningCupImage.Size = new Size(leftWinnerLabel.Height, leftWinnerLabel.Height);
            leftWinningCupImage.Location =
                new Point(leftWinnerLabel.Right + w / 60, h / 20 - leftWinningCupImage.Height / 2);
            leftWinningCupImage.Visible = true;
            leftWinnerLabel.Visible = true;
        }
        else if (winner == 1)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(w / 2, h / 120, w / 2, h / 12));
            rightWinnerLabel.Location =
                new Point(29 * w / 30 - rightWinnerLabel.Width, h / 20 - rightWinnerLabel.Height / 2);
            rightWinningCupImage.Size = new Size(rightWinnerLabel.Height, rightWinnerLabel.Height);
            rightWinningCupImage.Location = new Point(rightWinnerLabel.Left - w / 60 - rightWinningCupImage.Width,
                h / 20 - rightWinningCupImage.Height / 2);
            rightWinningCupImage.Visible = true;
            rightWinnerLabel.Visible = true;
        }
        else
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(0, h / 120, w / 2, h / 12));
            leftWinnerLabel.Location = new Point(w / 30, h / 20 - leftWinnerLabel.Height / 2);
            leftWinningCupImage.Size = new Size(leftWinnerLabel.Height, leftWinnerLabel.Height);
            leftWinningCupImage.Location =
                new Point(leftWinnerLabel.Right + w / 60, h / 20 - leftWinningCupImage.Height / 2);

            g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(w / 2, h / 120, w / 2, h / 12));
            rightWinnerLabel.Location =
                new Point(29 * w / 30 - rightWinnerLabel.Width, h / 20 - rightWinnerLabel.Height / 2);
            rightWinningCupImage.Size = new Size(rightWinnerLabel.Height, rightWinnerLabel.Height);
            rightWinningCupImage.Location = new Point(rightWinnerLabel.Left - w / 60 - rightWinningCupImage.Width,
                h / 20 - rightWinningCupImage.Height / 2);

            leftWinningCupImage.Visible = true;
            leftWinnerLabel.Visible = true;
            rightWinningCupImage.Visible = true;
            rightWinnerLabel.Visible = true;
        }


        // Draw wins box
        Point[] winBoxLinePoints =
        [
            new(w / 4, 0),
            new(w / 3, h / 10),
            new(2 * w / 3, h / 10),
            new(3 * w / 4, 0)
        ];
        g.FillPolygon(new SolidBrush(Color.Black), winBoxLinePoints);
        g.FillRectangle(new SolidBrush(Color.White),
            new Rectangle(new Point(w / 3 + 8, 8), new Size(w / 3 - 16, h / 10 - 16)));


        // Fill team color to the wins number
        double a = 48.0 / 5.0 / Math.Sqrt(36.0 / 25.0 + (double)w * w / (h * h));
        double b = -8 / Math.Sqrt(36.0 / 25.0 * h * h / (w * w) + 1);
        Point[] winBoxFillLeftPoints =
        [
            new((int)Math.Round(w / 4.0 + a + w / 12.0 * (80.0 - 10.0 * b) / h), 8),
            new((int)Math.Round(w / 3.0 + a - w / 12.0 * (80.0 + 10.0 * b) / h), h / 10 - 8),
            new(5 * w / 12, h / 10 - 8),
            new(5 * w / 12, 8)
        ];
        g.FillPolygon(new SolidBrush(LeftColor), winBoxFillLeftPoints);
        Point[] winBoxFillRightPoints =
        [
            new((int)Math.Round(3 * w / 4.0 - a - w / 12.0 * (80.0 - 10.0 * b) / h), 8),
            new((int)Math.Round(2 * w / 3.0 - a + w / 12.0 * (80.0 + 10.0 * b) / h), h / 10 - 8),
            new(7 * w / 12, h / 10 - 8),
            new(7 * w / 12, 8)
        ];
        g.FillPolygon(new SolidBrush(RightColor), winBoxFillRightPoints);

        // Separator lines in wins box
        g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 12, 0),
            new Point(w / 3 + w / 12, h / 10));
        g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 4, 0),
            new Point(w / 3 + w / 4, h / 10));
    }

    private void leftTeleOpScoreLabel_TextChanged(object sender, EventArgs e)
    {
        leftTeleOpScoreLabel.Location = new Point(7 * w / 24 - leftTeleOpScoreLabel.Width / 2,
            11 * h / 30 - leftTeleOpScoreLabel.Height / 2);
    }

    private void leftEndgameScoreLabel_TextChanged(object sender, EventArgs e)
    {
        leftEndgameScoreLabel.Location = new Point(7 * w / 24 - leftEndgameScoreLabel.Width / 2,
            h / 2 - leftEndgameScoreLabel.Height / 2);
    }

    private void leftPenaltyScoreLabel_TextChanged(object sender, EventArgs e)
    {
        leftPenaltyScoreLabel.Location = new Point(7 * w / 24 - leftPenaltyScoreLabel.Width / 2,
            19 * h / 30 - leftPenaltyScoreLabel.Height / 2);
    }

    private void rightTeleOpScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightTeleOpScoreLabel.Location = new Point(17 * w / 24 - rightTeleOpScoreLabel.Width / 2,
            11 * h / 30 - rightTeleOpScoreLabel.Height / 2);
    }

    private void rightEndgameScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightEndgameScoreLabel.Location = new Point(17 * w / 24 - rightEndgameScoreLabel.Width / 2,
            h / 2 - rightEndgameScoreLabel.Height / 2);
    }

    private void rightPenaltyScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightPenaltyScoreLabel.Location = new Point(17 * w / 24 - rightPenaltyScoreLabel.Width / 2,
            19 * h / 30 - rightPenaltyScoreLabel.Height / 2);
    }

    private void teleOpCatLabel_Click(object sender, EventArgs e)
    {
        GoBack.Invoke(this, EventArgs.Empty);
    }

    private void rightScore_SizeChanged(object sender, EventArgs e)
    {
        // Align team scores
        rightScore.Location = new Point(
            w * 5 / 6 - rightScore.Width / 2,
            9 * h / 10 - rightScore.Height);
    }

    private void leftScore_SizeChanged(object sender, EventArgs e)
    {
        // Align team scores
        leftScore.Location = new Point(
            w / 6 - leftScore.Width / 2,
            9 * h / 10 - leftScore.Height);
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}