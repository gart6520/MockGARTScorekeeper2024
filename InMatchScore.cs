using MockGARTScore.Properties;
using System.Configuration;
using System.Drawing.Text;
using System.Media;
using System.Reflection.Emit;

namespace MockGARTScore
{
    public partial class InMatchScore : Form
    {
        // Public variables
        // Time left
        public int TimeLeft = 0;

        // Timer running
        public bool TimerRunning = false;

        // SFX
        public SoundPlayer StartGame = new SoundPlayer("match_start.wav");
        public SoundPlayer StartEndGame = new SoundPlayer("endgame_start.wav");
        public SoundPlayer EndGame = new SoundPlayer("match_end.wav");

        // Team color
        public Color LeftColor = Color.Red;
        public Color RightColor = Color.DodgerBlue;

        // Park status
        public int LeftParkStatus = 0;
        public int RightParkStatus = 0;

        // Return current values (to WS client)
        public int[] GetCurrentValues()
        {
            int[] r =
            {
                (LeftColor == Color.Red) ? 0 : 1, // Left color
                (RightColor == Color.DodgerBlue) ? 1 : 0, // Blue color
                int.Parse((LeftColor == Color.Red) ? leftWins.Text : rightWins.Text), // Red wins
                int.Parse((RightColor == Color.DodgerBlue) ? rightWins.Text : leftWins.Text), // Blue wins
                int.Parse((LeftColor == Color.Red) ? leftScore.Text : rightScore.Text), // Red score
                int.Parse((RightColor == Color.DodgerBlue) ? rightScore.Text : leftScore.Text), // Blue score
                Convert.ToInt32((LeftColor == Color.Red) ? leftHatch.Visible : rightHatch.Visible), // Red hatch
                Convert.ToInt32((RightColor == Color.DodgerBlue) ? rightHatch.Visible : leftHatch.Visible), // Blue hatch
                int.Parse((LeftColor == Color.Red) ? leftFuel.Text : rightFuel.Text), // Red fuel
                int.Parse((RightColor == Color.DodgerBlue) ? rightFuel.Text : leftFuel.Text), // Blue fuel
                (LeftColor == Color.Red) ? LeftParkStatus : RightParkStatus, // Red park
                (RightColor == Color.DodgerBlue) ? RightParkStatus : LeftParkStatus // Blue park
            };

            return r;
        }

        // Set team color
        public void SetTeamColor(Color left, Color right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

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

            // Realign team name
            leftTeamName.Location = new Point(
                w / 4 - leftTeamName.Size.Width / 2,
                h / 8);
            rightTeamName.Location = new Point(
                w * 3 / 4 - rightTeamName.Size.Width / 2,
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

            // Set park visibility
            leftParkNo.Visible = true;
            leftParkHalf.Visible = false;
            leftParkFull.Visible = false;
            rightParkNo.Visible = true;
            rightParkHalf.Visible = false;
            rightParkFull.Visible = false;
        }

        // Set score
        public void SetScore(int left, int right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set team scores
            leftScore.Text = left.ToString();
            rightScore.Text = right.ToString();

            // Align team scores
            leftScore.Location = new Point(
                w / 4 - leftScore.Size.Width / 2,
                h / 4);
            rightScore.Location = new Point(
                w * 3 / 4 - rightScore.Size.Width / 2,
                h / 4);
        }

        // Set hatch
        public void SetHatch(bool left, bool right)
        {
            leftHatch.Visible = left;
            rightHatch.Visible = right;
            leftHatch.Refresh();
            rightHatch.Refresh();
        }

        // Set fuel
        public void SetFuel(int left, int right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set
            leftFuel.Text = left.ToString();
            rightFuel.Text = right.ToString();

            // Align
            leftFuel.Location = new Point(
                w / 4 + w / 16 - leftFuel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - leftFuel.Size.Height / 2);
            rightFuel.Location = new Point(
                w * 5 / 8 + w / 16 - rightFuel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - rightFuel.Size.Height / 2);
        }

        // Set park
        public void SetPark(int left, int right)
        {
            // Set park status
            LeftParkStatus = left;
            RightParkStatus = right;

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
                default:
                    // How tf
                    break;
            }
            leftParkNo.Refresh();
            leftParkHalf.Refresh();
            leftParkFull.Refresh();

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
                default:
                    // How tf
                    break;
            }
            rightParkNo.Refresh();
            rightParkHalf.Refresh();
            rightParkFull.Refresh();
        }

        // Set timer
        public void SetTime(int seconds)
        {
            // Set time left
            TimeLeft = seconds;

            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set timerText
            int m = seconds / 60;
            int s = seconds % 60;
            timerText.Text = m.ToString("D2") + ":" + s.ToString("D2");

            // Align the timerText to center
            timerText.Location = new Point(
                (w - timerText.Size.Width) / 2,
                (h - timerText.Size.Height) / 2);
        }

        public async void StartTimer()
        {
            // Start timer and play sound if it's not currently started
            if (!TimerRunning)
            {
                StartGame.Play();
                TimerRunning = true;
            }

            while (TimerRunning)
            {
                if (TimeLeft == 30) StartEndGame.Play();

                int m = TimeLeft / 60;
                int s = TimeLeft % 60;
                timerText.Text = m.ToString("D2") + ":" + s.ToString("D2");

                if (TimeLeft == 0)
                {
                    TimerRunning = false;
                    break;
                }

                TimeLeft--;
                await Task.Delay(1000);
            }

            EndGame.Play();
        }

        // Reset match
        public void ResetMatch()
        {
            //this.setTeamColor(Color.Red, Color.DodgerBlue);
            //this.setWins(0, 0);
            Program.SwitchForm(Program.FormEnum.InMatchScore);
            SetTime(180);
            SetScore(0, 0);
            SetHatch(false, false);
            SetFuel(0, 0);
            SetPark(0, 0);
        }

        // Set wins
        public void SetWins(int left, int right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set wins text
            leftWins.Text = left.ToString();
            rightWins.Text = right.ToString();

            // Align the leftWins and rightWins label
            leftWins.Location = new Point(
                w / 3 + w / 24 - leftWins.Size.Width / 2,
                (h / 10 - leftWins.Size.Height) / 2);
            rightWins.Location = new Point(
                w / 3 + w * 7 / 24 - rightWins.Size.Width / 2,
                (h / 10 - rightWins.Size.Height) / 2);
        }

        public InMatchScore()
        {
            InitializeComponent();

            // Set Form to full screen
            Size = Screen.PrimaryScreen.Bounds.Size;

            // Set PictureBox size to full Form size
            canvas.Size = Size;

            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Add paint event handler to the canvas
            canvas.Paint += canvas_Paint;

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
                w / 4 - leftTeamName.Size.Width / 2,
                h / 8);
            rightTeamName.Location = new Point(
                w * 3 / 4 - rightTeamName.Size.Width / 2,
                h / 8);

            // Align team scores
            leftScore.Location = new Point(
                w / 4 - leftScore.Size.Width / 2,
                h / 4);
            rightScore.Location = new Point(
                w * 3 / 4 - rightScore.Size.Width / 2,
                h / 4);

            // Align hatch images
            leftHatch.Location = new Point(
                w / 4 - leftHatch.Size.Width / 2,
                h / 2 + h / 16 - leftHatch.Size.Height / 2);
            rightHatch.Location = new Point(
                w * 3 / 4 - rightHatch.Size.Width / 2,
                h / 2 + h / 16 - rightHatch.Size.Height / 2);

            // Align fuel labels
            leftFuelLabel.Location = new Point(
                w / 8 + w / 16 - leftFuelLabel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - leftFuelLabel.Size.Height / 2);
            leftFuel.Location = new Point(
                w / 4 + w / 16 - leftFuel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - leftFuel.Size.Height / 2);

            rightFuelLabel.Location = new Point(
                w * 3 / 4 + w / 16 - rightFuelLabel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - rightFuelLabel.Size.Height / 2);
            rightFuel.Location = new Point(
                w * 5 / 8 + w / 16 - rightFuel.Size.Width / 2,
                h / 2 + h / 6 + h / 24 + h / 96 - rightFuel.Size.Height / 2);

            // Align park images
            leftParkNo.Location = new Point(
                w / 4 - leftParkHalf.Size.Width / 2,
                h - leftParkNo.Size.Height * 4 / 3);
            leftParkHalf.Location = new Point(
                w / 4 - leftParkHalf.Size.Width / 2,
                h - leftParkNo.Size.Height * 4 / 3);
            leftParkFull.Location = new Point(
                w / 4 - leftParkHalf.Size.Width / 2,
                h - leftParkNo.Size.Height * 4 / 3);

            rightParkNo.Location = new Point(
                w / 2 + w / 4 - rightParkHalf.Size.Width / 2,
                h - rightParkHalf.Size.Height * 4 / 3);
            rightParkHalf.Location = new Point(
                w / 2 + w / 4 - rightParkHalf.Size.Width / 2,
                h - rightParkHalf.Size.Height * 4 / 3);
            rightParkFull.Location = new Point(
                w / 2 + w / 4 - rightParkHalf.Size.Width / 2,
                h - rightParkHalf.Size.Height * 4 / 3);
        }

        void exitButton_Click(object sender, EventArgs e)
        {
            // Exit
            Application.Exit();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // Canvas size
            int w = canvas.Size.Width;
            int h = canvas.Size.Height;

            // Calculate separator line
            int sepUpX = w * 9 / 16;
            int sepDownX = w * 7 / 16;

            // Fill red side in red
            Point[] redCurvePoints =
            {
                new(0, 0),
                new(sepUpX, 0),
                new(sepDownX, h),
                new(0, h)
            };

            g.FillPolygon(new SolidBrush(LeftColor), redCurvePoints);

            // Fill blue side in blue
            Point[] blueCurvePoints =
            {
                new(sepUpX, 0),
                new(w, 0),
                new(w, h),
                new(sepDownX, h)
            };

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
            // g.FillRectangle(new SolidBrush(Color.Black),
            //     new Rectangle(new Point(w / 3, 0), new Size(w / 3, h / 10)));
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
            // g.FillRectangle(new SolidBrush(leftColor),
            //     new Rectangle(new Point(w / 3 + 8, 8), new Size(w / 12 - 8, h / 10 - 16)));
            g.FillPolygon(new SolidBrush(LeftColor), winBoxFillLeftPoints);
            Point[] winBoxFillRightPoints =
            [
                new((int)Math.Round(3 * w / 4.0 - a - w / 12.0 * (80.0 - 10.0 * b) / h), 8),
                new((int)Math.Round(2 * w / 3.0 - a + w / 12.0 * (80.0 + 10.0 * b) / h), h / 10 - 8),
                new(7 * w / 12, h / 10 - 8),
                new(7 * w / 12, 8)
            ];
            g.FillPolygon(new SolidBrush(RightColor), winBoxFillRightPoints);
            // g.FillRectangle(new SolidBrush(rightColor),
            //     new Rectangle(new Point(w / 3 + w / 4, 8), new Size(w / 12 - 8, h / 10 - 16)));

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
            Pen smallBoxPen = new Pen(Color.Black, 8);
            //g.DrawRectangle(smallBoxPen,
            //    new Rectangle(leftHatch.Left, leftHatch.Top, leftHatch.Width, leftHatch.Height));
            //g.DrawRectangle(smallBoxPen,
            //    new Rectangle(rightHatch.Left, rightHatch.Top, rightHatch.Width, rightHatch.Height));

            // Draw fuel box
            g.DrawRectangle(smallBoxPen,
                new Rectangle(w / 8, h / 2 + h / 6, w / 4, h / 12 + h / 48));
            g.DrawRectangle(smallBoxPen,
                new Rectangle(w * 5 / 8, h / 2 + h / 6, w / 4, h / 12 + h / 48));
            g.DrawLine(smallBoxPen, new Point(w / 4, h / 2 + h / 6), new Point(w / 4, h / 2 + h / 6 + h / 12 + h / 48));
            g.DrawLine(smallBoxPen, new Point(w * 3 / 4, h / 2 + h / 6), new Point(w * 3 / 4, h / 2 + h / 6 + h / 12 + h / 48));
        }
    }
}