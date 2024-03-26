using static MockGARTScore.GameStat;
namespace MockGARTScore;

public partial class PostMatchScore : Form
{
    int w;
    int h;
    readonly Color DarkerRed = Color.FromArgb(239, 0, 0);
    public PostMatchScore()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;
        Size = Screen.PrimaryScreen.Bounds.Size;

        canvas.Location = new Point();
        canvas.Size = Size;
        canvas.Paint += Canvas_Paint;

        w = Width;
        h = Height;

        // Align score category labels
        teleOpCatLabel.Location = new Point(w / 2 - teleOpCatLabel.Size.Width / 2, 11 * h / 30 - teleOpCatLabel.Height / 2);
        endgameCatLabel.Location = new Point(w / 2 - endgameCatLabel.Size.Width / 2, h / 2 - endgameCatLabel.Height / 2);
        penaltyCatLabel.Location = new Point(w / 2 - penaltyCatLabel.Size.Width / 2, 19 * h / 30 - penaltyCatLabel.Height / 2);

        // Align score labels
        leftTeleOpScoreLabel.BackColor = DarkerRed;
        leftEndgameScoreLabel.BackColor = DarkerRed;
        leftPenaltyScoreLabel.BackColor = DarkerRed;
        leftTeleOpScoreLabel.Location = new Point(7 * w / 24 - leftTeleOpScoreLabel.Width / 2, 11 * h / 30 - leftTeleOpScoreLabel.Height / 2);
        leftEndgameScoreLabel.Location = new Point(7 * w / 24 - leftEndgameScoreLabel.Width / 2, h / 2 - leftEndgameScoreLabel.Height / 2);
        leftPenaltyScoreLabel.Location = new Point(7 * w / 24 - leftPenaltyScoreLabel.Width / 2, 19 * h / 30 - leftPenaltyScoreLabel.Height / 2);

        rightTeleOpScoreLabel.BackColor = Color.DarkBlue;
        rightEndgameScoreLabel.BackColor = Color.DarkBlue;
        rightPenaltyScoreLabel.BackColor = Color.DarkBlue;
        rightTeleOpScoreLabel.Location = new Point(17 * w / 24 - rightTeleOpScoreLabel.Width / 2, 11 * h / 30 - rightTeleOpScoreLabel.Height / 2);
        rightEndgameScoreLabel.Location = new Point(17 * w / 24 - rightEndgameScoreLabel.Width / 2, h / 2 - rightEndgameScoreLabel.Height / 2);
        rightPenaltyScoreLabel.Location = new Point(17 * w / 24 - rightPenaltyScoreLabel.Width / 2, 19 * h / 30 - rightPenaltyScoreLabel.Height / 2);

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

        leftPenaltyScoreLabel.Text = LeftPenalty.ToString();
        rightPenaltyScoreLabel.Text = RightPenalty.ToString();

        leftTeleOpScoreLabel.Text = (LeftFuelLevel * 2 + (LeftHatchStatus ? 20 : 0)).ToString();
        rightTeleOpScoreLabel.Text = (RightFuelLevel * 2 + (RightHatchStatus ? 20 : 0)).ToString();

        leftWins.Text = LeftWin.ToString();
        rightWins.Text = RightWin.ToString();
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
        leftTeleOpScoreLabel.Location = new Point(7 * w / 24 - leftTeleOpScoreLabel.Width / 2, 11 * h / 30 - leftTeleOpScoreLabel.Height / 2);
    }

    private void leftEndgameScoreLabel_TextChanged(object sender, EventArgs e)
    {
        leftEndgameScoreLabel.Location = new Point(7 * w / 24 - leftEndgameScoreLabel.Width / 2, h / 2 - leftEndgameScoreLabel.Height / 2);
    }

    private void leftPenaltyScoreLabel_TextChanged(object sender, EventArgs e)
    {
        leftPenaltyScoreLabel.Location = new Point(7 * w / 24 - leftPenaltyScoreLabel.Width / 2, 19 * h / 30 - leftPenaltyScoreLabel.Height / 2);
    }

    private void rightTeleOpScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightTeleOpScoreLabel.Location = new Point(17 * w / 24 - rightTeleOpScoreLabel.Width / 2, 11 * h / 30 - rightTeleOpScoreLabel.Height / 2);
    }

    private void rightEndgameScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightEndgameScoreLabel.Location = new Point(17 * w / 24 - rightEndgameScoreLabel.Width / 2, h / 2 - rightEndgameScoreLabel.Height / 2);
    }

    private void rightPenaltyScoreLabel_TextChanged(object sender, EventArgs e)
    {
        rightPenaltyScoreLabel.Location = new Point(17 * w / 24 - rightPenaltyScoreLabel.Width / 2, 19 * h / 30 - rightPenaltyScoreLabel.Height / 2);
    }

    private void teleOpCatLabel_Click(object sender, EventArgs e)
    {
        Program.SwitchForm(Program.FormEnum.InMatchScore);
    }
}