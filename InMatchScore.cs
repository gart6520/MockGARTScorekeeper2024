using System.Diagnostics;
using System.Globalization;
using MockGARTScore.Properties;
using System.Media;
using static MockGARTScore.GameStat;

namespace MockGARTScore;

public partial class InMatchScore : Form
{
    // Public variables

    public event EventHandler Publish = null!;

    // Time left
    private int timeTotal = 180;
    private int timeLeft;

    readonly int w;

    readonly int h;

    // Timer running
    private bool timerRunning;

    // SFX
    private readonly SoundPlayer startGame = new("match_start.wav");
    private readonly SoundPlayer startEndGame = new("endgame_start.wav");
    private readonly SoundPlayer endGame = new("match_end.wav");
    private readonly SoundPlayer abortMatch = new("abort_match.wav");


    // Return current values (to WS client)
    public int[] GetCurrentValues()
    {
        int[] r =
        [
            LeftColor == Color.Red ? 0 : 1, // Left color
            RightColor == Color.DodgerBlue ? 1 : 0, // Right color
            int.Parse(LeftColor == Color.Red ? leftWins.Text : rightWins.Text), // Red wins
            int.Parse(RightColor == Color.DodgerBlue ? rightWins.Text : leftWins.Text), // Blue wins
            int.Parse(LeftColor == Color.Red ? leftScore.Text : rightScore.Text), // Red score
            int.Parse(RightColor == Color.DodgerBlue ? rightScore.Text : leftScore.Text), // Blue score
            Convert.ToInt32(LeftColor == Color.Red
                ? leftHatch.Image == Resources.tankwithhatch
                : rightHatch.Image == Resources.tankwithhatch), // Red hatch
            Convert.ToInt32(RightColor == Color.DodgerBlue
                ? rightHatch.Image == Resources.tankwithhatch
                : leftHatch.Image == Resources.tankwithhatch), // Blue hatch
            int.Parse(LeftColor == Color.Red ? leftFuel.Text : rightFuel.Text), // Red fuel
            int.Parse(RightColor == Color.DodgerBlue ? rightFuel.Text : leftFuel.Text), // Blue fuel
            LeftColor == Color.Red ? LeftParkStatus : RightParkStatus, // Red park
            RightColor == Color.DodgerBlue ? RightParkStatus : LeftParkStatus, // Blue park
            timerRunning ? 1 : 0 // Has match started?
        ];

        return r;
    }

    // Set team color
    private void SetTeamColor(Color left, Color right)
    {
        // Set team color variables
        LeftColor = left;
        RightColor = right;

        // Redraw canvas
        canvas.Refresh();

        // Change team wins text background color
        leftWins.BackColor = LeftColor;
        rightWins.BackColor = RightColor;

        // Change team name
        leftTeamName.Text = LeftColor == Color.Red ? "RED" : "BLUE";
        rightTeamName.Text = RightColor == Color.DodgerBlue ? "BLUE" : "RED";

        // Align team names
        leftTeamName.Location = new Point(
            w / 6 - leftTeamName.Size.Width / 2,
            h / 8);
        rightTeamName.Location = new Point(
            w * 5 / 6 - rightTeamName.Size.Width / 2,
            h / 8);

        // Change team name background
        leftTeamName.BackColor = LeftColor;
        rightTeamName.BackColor = RightColor;

        // Change score background
        leftScore.BackColor = LeftColor;
        rightScore.BackColor = RightColor;

        // Change hatch background
        leftHatch.BackColor = LeftColor;
        rightHatch.BackColor = RightColor;
        //leftHatch.Refresh();
        //rightHatch.Refresh();

        // Change fuel background
        leftFuelLabel.BackColor = LeftColor;
        leftFuel.BackColor = LeftColor;
        rightFuelLabel.BackColor = RightColor;
        rightFuel.BackColor = RightColor;

        // Change park background
        leftParkNo.BackColor = LeftColor;
        leftParkHalf.BackColor = LeftColor;
        leftParkFull.BackColor = LeftColor;
        rightParkNo.BackColor = RightColor;
        rightParkHalf.BackColor = RightColor;
        rightParkFull.BackColor = RightColor;

        // Change ball background
        leftBallPicture.BackColor = LeftColor;
        rightBallPicture.BackColor = RightColor;
    }

    private void SetBall(bool left, bool right)
    {
        LeftBallStatus = left;
        RightBallStatus = right;

        leftBallPicture.Image = left ? Resources.ball : Resources.no_ball;
        rightBallPicture.Image = right ? Resources.ball : Resources.no_ball;
    }

    private void SetMultiplier(double left, double right)
    {
        LeftMultiplier = left;
        RightMultiplier = right;

        leftMultiplierLabel.Text = @"x" + left.ToString(CultureInfo.InvariantCulture);
        rightMultiplierLabel.Text = @"x" + right.ToString(CultureInfo.InvariantCulture);
    }

    // Set score
    private void SetScore(int left, int right)
    {
        // Set team scores
        // Align team scores
        leftScore.Invoke(() =>
        {
            leftScore.Text = left.ToString();
            leftScore.Location = new Point(
                w / 6 - leftScore.Size.Width / 2,
                h / 4);
        });
        rightScore.Invoke(() =>
        {
            rightScore.Text = right.ToString();

            rightScore.Location = new Point(
                w * 5 / 6 - rightScore.Size.Width / 2,
                h / 4);
        });
        LeftScore = left;
        RightScore = right;
    }

    // Set penalty
    private void SetPenalty(int left, int right)
    {
        LeftPenalty = left;
        RightPenalty = right;
    }

    // Set hatch
    private void SetHatch(bool left, bool right)
    {
        //leftHatch.Visible = left;
        //rightHatch.Visible = right;
        leftHatch.Invoke(() => leftHatch.Image = left ? Resources.tankwithhatch : Resources.tanknohatch);
        rightHatch.Invoke(() => rightHatch.Image = right ? Resources.tankwithhatch : Resources.tanknohatch);

        LeftHatchStatus = left;
        RightHatchStatus = right;

        //leftHatch.Refresh();
        //rightHatch.Refresh();
    }

    // Set fuel
    private void SetFuel(int left, int right)
    {
        // Window size


        // Set fuel score
        // Align fuel score label
        leftFuel.Invoke(() =>
        {
            leftFuel.Text = left.ToString();
            leftFuel.Location = new Point(
                11 * w / 48 - leftFuel.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - leftFuel.Height / 2);
        });
        rightFuel.Invoke(() =>
        {
            rightFuel.Text = right.ToString();

            rightFuel.Location = new Point(
                w * 37 / 48 - rightFuel.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - rightFuel.Height / 2);
        });

        LeftFuelLevel = left;
        RightFuelLevel = right;
    }

    // Set park
    private void SetPark(int left, int right)
    {
        // Set park status
        LeftParkStatus = left;
        RightParkStatus = right;
        leftParkFull.Invoke(() =>
        {
            // Left
            switch (left)
            {
                case 0:
                    leftParkNo.Visible = true;
                    leftParkHalf.Visible = false;
                    leftParkFull.Visible = false;
                    break;
                case 1:
                    leftParkNo.Visible = false;
                    leftParkHalf.Visible = true;
                    leftParkFull.Visible = false;
                    break;
                case 2:
                    leftParkNo.Visible = false;
                    leftParkHalf.Visible = false;
                    leftParkFull.Visible = true;
                    break;
            }

            leftParkNo.Refresh();
            leftParkHalf.Refresh();
            leftParkFull.Refresh();
        });


        rightParkFull.Invoke(() =>
        {
            // Right
            switch (right)
            {
                case 0:
                    rightParkNo.Visible = true;
                    rightParkHalf.Visible = false;
                    rightParkFull.Visible = false;
                    break;
                case 1:
                    rightParkNo.Visible = false;
                    rightParkHalf.Visible = true;
                    rightParkFull.Visible = false;
                    break;
                case 2:
                    rightParkNo.Visible = false;
                    rightParkHalf.Visible = false;
                    rightParkFull.Visible = true;
                    break;
            }

            rightParkNo.Refresh();
            rightParkHalf.Refresh();
            rightParkFull.Refresh();
        });
    }

    // Set timer
    private void SetTime(int seconds)
    {
        // Set time left
        timeTotal = seconds;
        timeLeft = timeTotal;

        // Set timerText
        int m = seconds / 60;
        int s = seconds % 60;
        timerText.Invoke(() =>
        {
            timerText.Text = m.ToString("D2") + @":" + s.ToString("D2");

            // Align the timerText to center
            timerText.Location = new Point(
                (w - timerText.Size.Width) / 2,
                (h - timerText.Size.Height) / 2);
        });
    }

    private async void StartTimer()
    {
        // Start timer and play sound if it's not currently started
        if (!timerRunning)
        {
            startGame.Play();
            timerRunning = true;
        }

        while (timerRunning)
        {
            if (timeLeft == 30) startEndGame.Play();

            if (timeLeft <= 0)
            {
                timerText.Invoke(() => { timerText.Text = "00:00"; });
                timerRunning = false;
                break;
            }

            int m = timeLeft / 60;
            int s = timeLeft % 60;
            timerText.Invoke(() => { timerText.Text = m.ToString("D2") + @":" + s.ToString("D2"); });


            timeLeft--;
            await Task.Delay(1000);
        }

        if (timeLeft == 0) endGame.Play();
    }

    private void AbortMatch()
    {
        timeLeft = -1;
        abortMatch.Play();
        SetScore(0, 0);
        SetPenalty(0, 0);
        SetHatch(false, false);
        SetFuel(0, 0);
        SetPark(0, 0);
    }

    // Reset match
    private void ResetMatch()
    {
        //this.setTeamColor(Color.Red, Color.DodgerBlue);
        //this.setWins(0, 0);
        // Program.SwitchForm(Program.FormEnum.InMatchScore);
        SetTime(timeTotal);
        SetScore(0, 0);
        SetPenalty(0, 0);
        SetHatch(false, false);
        SetBall(false, false);
        SetFuel(0, 0);
        SetMultiplier(1, 1);
        SetPark(0, 0);
    }

    // Set wins
    private void SetWins(int left, int right)
    {
        // Set wins text
        // Align the leftWins and rightWins label
        leftWins.Invoke(() =>
        {
            leftWins.Text = left.ToString();
            leftWins.Location = new Point(
                w / 3 + w / 24 - leftWins.Size.Width / 2,
                (h / 10 - leftWins.Size.Height) / 2);
        });
        rightWins.Invoke(() =>
        {
            rightWins.Text = right.ToString();
            rightWins.Location = new Point(
                w / 3 + w * 7 / 24 - rightWins.Size.Width / 2,
                (h / 10 - rightWins.Size.Height) / 2);
        });

        LeftWin = left;
        RightWin = right;
    }

    public InMatchScore()
    {
        InitializeComponent();


        // Set Form to full screen
        Debug.Assert(Screen.PrimaryScreen != null, "Screen.PrimaryScreen != null");
        Size = Screen.PrimaryScreen.Bounds.Size;

        // Set PictureBox size to full Form size
        canvas.Size = Size;

        w = Width;
        h = Height;

        // Set ImageBox size to the actual image size
        leftHatch.Size = leftHatch.Image.Size;
        rightHatch.Size = rightHatch.Image.Size;
        leftParkFull.Size = leftParkFull.Image.Size;
        leftParkNo.Size = leftParkNo.Image.Size;
        leftParkHalf.Size = leftParkHalf.Image.Size;
        rightParkHalf.Size = rightParkHalf.Image.Size;
        rightParkFull.Size = rightParkFull.Image.Size;
        rightParkNo.Size = rightParkNo.Image.Size;
        leftBallPicture.Size = leftBallPicture.Image.Size;
        rightBallPicture.Size = rightBallPicture.Image.Size;


        // Add paint event handler to the canvas
        canvas.Paint += canvas_Paint!;


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

        // Align the timerText to center
        timerText.Location = new Point(
            (w - timerText.Size.Width) / 2,
            (h - timerText.Size.Height) / 2);

        // Set team name
        leftTeamName.Text = LeftColor == Color.Red ? "RED" : "BLUE";
        rightTeamName.Text = RightColor == Color.DodgerBlue ? "BLUE" : "RED";

        // Align team names
        leftTeamName.Location = new Point(
            w / 6 - leftTeamName.Size.Width / 2,
            h / 8);
        rightTeamName.Location = new Point(
            w * 5 / 6 - rightTeamName.Size.Width / 2,
            h / 8);

        // Align team scores
        leftScore.Location = new Point(
            w / 6 - leftScore.Size.Width / 2,
            h / 4);
        rightScore.Location = new Point(
            w * 5 / 6 - rightScore.Size.Width / 2,
            h / 4);

        // Align hatch images
        leftHatch.Location = new Point(
            w / 6 - leftHatch.Size.Width / 2,
            h / 2 + h / 16 - leftHatch.Size.Height / 2);
        rightHatch.Location = new Point(
            w * 5 / 6 - rightHatch.Size.Width / 2,
            h / 2 + h / 16 - rightHatch.Size.Height / 2);

        // Align fuel labels
        leftFuelLabel.Location = new Point(
            5 * w / 48 - leftFuelLabel.Width / 2,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - leftFuelLabel.Height / 2);
        leftFuel.Location = new Point(
            11 * w / 48 - leftFuel.Width / 2,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - leftFuel.Height / 2);

        rightFuelLabel.Location = new Point(
            43 * w / 48 - rightFuelLabel.Width / 2,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - rightFuelLabel.Height / 2);
        rightFuel.Location = new Point(
            w * 37 / 48 - rightFuel.Width / 2,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - rightFuel.Height / 2);

        // Align park and ball images
        leftParkNo.Location = new Point(
            w * 5 / 48 - leftParkNo.Size.Width / 2,
            h * 9 / 10 - leftParkNo.Height / 2);
        leftParkHalf.Location = new Point(
            w * 5 / 48 - leftParkHalf.Size.Width / 2,
            h * 9 / 10 - leftParkHalf.Height / 2);
        leftParkFull.Location = new Point(
            w * 5 / 48 - leftParkFull.Size.Width / 2,
            h * 9 / 10 - leftParkFull.Height / 2);

        leftBallPicture.Location = new Point(
            w * 11 / 48 - leftBallPicture.Width / 2,
            h * 9 / 10 - leftBallPicture.Height / 2);

        rightParkNo.Location = new Point(
            w * 43 / 48 - rightParkNo.Width / 2,
            h * 9 / 10 - rightParkNo.Size.Height / 2);
        rightParkHalf.Location = new Point(
            w * 43 / 48 - rightParkHalf.Width / 2,
            h * 9 / 10 - rightParkHalf.Size.Height / 2);
        rightParkFull.Location = new Point(
            w * 43 / 48 - rightParkFull.Width / 2,
            h * 9 / 10 - rightParkFull.Size.Height / 2);

        rightBallPicture.Location = new Point(
            w * 37 / 48 - rightBallPicture.Width / 2,
            h * 9 / 10 - rightBallPicture.Height / 2);

        // Align multiplier label
        leftMultiplierLabel.Location = new Point(
            w / 3,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - leftMultiplierLabel.Height / 2
        );
        rightMultiplierLabel.Location = new Point(
            2 * w / 3 - rightMultiplierLabel.Width,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - rightMultiplierLabel.Height / 2
        );

        WSUpdate.StartTimer += (_, _) => StartTimer();
        WSUpdate.SetFuel += (_, e) => SetFuel(e.Left, e.Right);
        WSUpdate.SetPark += (_, e) => SetPark(e.Left, e.Right);
        WSUpdate.SetScore += (_, e) => SetScore(e.Left, e.Right);
        WSUpdate.SetHatch += (_, e) => SetHatch(e.Left, e.Right);
        WSUpdate.SetPenalty += (_, e) => SetPenalty(e.Left, e.Right);
        WSUpdate.SetBall += (_, e) => SetBall(e.Left, e.Right);
        WSUpdate.SetMultiplier += (_, e) => SetMultiplier(e.Left, e.Right);
        WSUpdate.SetWins += (_, e) => SetWins(e.Left, e.Right);
        WSUpdate.SetTeamColor += (_, e) => SetTeamColor(e.Left, e.Right);
        WSUpdate.SetTimer += (_, e) => SetTime(e.Time);
        WSUpdate.ResetMatch += (_, _) => ResetMatch();
        WSUpdate.AbortMatch += (_, _) => AbortMatch();

        HandleCreated += (_, _) =>
        {
            SetTeamColor(Color.Red, Color.DodgerBlue);
            SetWins(0, 0);
            SetTime(timeTotal);
            ResetMatch();
            Program.PostMatchScoreForm.Show();
            Activate();
        };
    }

    protected override bool ShowWithoutActivation => true;

    void exitButton_Click(object sender, EventArgs e)
    {
        // Exit
        Application.Exit();
    }

    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        // Create a local version of the graphics object for the PictureBox.
        Graphics g = e.Graphics;


        // Calculate separator line
        int sepUpX = w * 9 / 16;
        int sepDownX = w * 7 / 16;

        // Fill red side in red
        Point[] redCurvePoints =
        [
            new(0, 0),
            new(sepUpX, 0),
            new(sepDownX, h),
            new(0, h)
        ];

        g.FillPolygon(new SolidBrush(LeftColor), redCurvePoints);

        // Fill blue side in blue
        Point[] blueCurvePoints =
        [
            new(sepUpX, 0),
            new(w, 0),
            new(w, h),
            new(sepDownX, h)
        ];

        g.FillPolygon(new SolidBrush(RightColor), blueCurvePoints);

        // Draw separator line
        g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), new Point(sepUpX, 0), new Point(sepDownX, h));

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

        // Draw timer box
        Pen timerBoxPen = new Pen(Color.Black, 16);
        g.DrawRectangle(timerBoxPen,
            new Rectangle(timerText.Left, timerText.Top, timerText.Width, timerText.Height));

        // Draw hatch box
        Pen smallBoxPen = new Pen(Color.Black, 4);
        //g.DrawRectangle(smallBoxPen,
        //    new Rectangle(leftHatch.Left, leftHatch.Top, leftHatch.Width, leftHatch.Height));
        //g.DrawRectangle(smallBoxPen,
        //    new Rectangle(rightHatch.Left, rightHatch.Top, rightHatch.Width, rightHatch.Height));

        // Draw fuel box
        g.DrawRectangle(smallBoxPen,
            new Rectangle(w / 24, h / 2 + h / 6 + h / 36, w / 4, h / 12 + h / 48));
        g.DrawRectangle(smallBoxPen,
            new Rectangle(w * 17 / 24, h / 2 + h / 6 + h / 36, w / 4, h / 12 + h / 48));
        g.DrawLine(smallBoxPen, new Point(w / 6, h / 2 + h / 6 + h / 36),
            new Point(w / 6, h / 2 + h / 6 + h / 36 + h / 12 + h / 48));
        g.DrawLine(smallBoxPen, new Point(w * 5 / 6, h / 2 + h / 6 + h / 36),
            new Point(w * 5 / 6, h / 2 + h / 6 + h / 36 + h / 12 + h / 48));
    }

    private void timerText_Click(object sender, EventArgs e)
    {
        Publish.Invoke(this, EventArgs.Empty);
    }

    private void timerText_SizeChanged(object sender, EventArgs e)
    {
        timerText.Location = new Point(
            (w - timerText.Width) / 2,
            (h - timerText.Height) / 2
        );
    }

    private void rightMultiplierLabel_SizeChanged(object sender, EventArgs e)
    {
        rightMultiplierLabel.Location = new Point(
            2 * w / 3 - rightMultiplierLabel.Width,
            h / 2 + h / 6 + h / 24 + h / 96 + h / 36 - rightMultiplierLabel.Height / 2
        );
    }
}