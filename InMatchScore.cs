namespace MockGARTScore
{
    public partial class InMatchScore : Form
    {
        // Public variables

        // Team color
        public Color leftColor = Color.Red;
        public Color rightColor = Color.DodgerBlue;

        // Match time (in seconds)
        public int matchTime = 180;

        // Set team color
        public void setTeamColor(Color left, Color right)
        {
            // Set team color variables
            leftColor = left;
            rightColor = right;

            // Change team wins text background color
            leftWins.BackColor = leftColor;
            rightWins.BackColor = rightColor;

            // Change team name
            leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

            // Change team name background
            leftTeamName.BackColor = leftColor;
            rightTeamName.BackColor = rightColor;
        }

        // Set score
        public void setScore(int left, int right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set team scores
            leftScore.Text = left.ToString();
            rightScore.Text = right.ToString();

            // Aligin team scores
            leftScore.Location = new Point(
                w / 4 - leftScore.Size.Width / 2,
                h / 2 - leftScore.Size.Height / 2);
            rightScore.Location = new Point(
                w * 3 / 4 - rightScore.Size.Width / 2,
                h / 2 - rightScore.Size.Height / 2);
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
            leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

            // Align team names
            leftTeamName.Location = new Point(
                w / 4 - leftTeamName.Size.Width / 2,
                h / 4 - leftTeamName.Size.Height / 2);
            rightTeamName.Location = new Point(
                w * 3 / 4 - rightTeamName.Size.Width / 2,
                h / 4 - rightTeamName.Size.Height / 2);

            // Align team scores
            leftScore.Location = new Point(
                w / 4 - leftScore.Size.Width / 2,
                h / 2 - leftScore.Size.Height / 2);
            rightScore.Location = new Point(
                w * 3 / 4 - rightScore.Size.Width / 2,
                h / 2 - rightScore.Size.Height / 2);

            // Align hatch images
            leftHatch.Location = new Point(
                w / 4 - leftHatch.Size.Width / 2,
                h / 2 + h / 6 - leftHatch.Size.Height / 2);
            rightHatch.Location = new Point(
                w * 3 / 4 - rightHatch.Size.Width / 2,
                h / 2 + h / 6 - rightHatch.Size.Height / 2);
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
            int sep_up_x = w / 2;
            int sep_down_x = w / 2;

            // Fill red side in red
            Point[] red_curve_points =
            {
                new(0, 0),
                new(sep_up_x, 0),
                new(sep_down_x, h),
                new(0, h)
            };

            g.FillPolygon(new SolidBrush(leftColor), red_curve_points);

            // Fill blue side in blue
            Point[] blue_curve_points =
            {
                new(sep_up_x, 0),
                new(w, 0),
                new(w, h),
                new(sep_down_x, h)
            };

            g.FillPolygon(new SolidBrush(rightColor), blue_curve_points);

            // Draw separator line
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), new Point(sep_up_x, 0), new Point(sep_down_x, h));

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
            g.FillPolygon(new SolidBrush(leftColor), winBoxFillLeftPoints);
            Point[] winBoxFillRightPoints =
            [
                new((int)Math.Round(3 * w / 4.0 - a - w / 12.0 * (80.0 - 10.0 * b) / h), 8),
                new((int)Math.Round(2 * w / 3.0 - a + w / 12.0 * (80.0 + 10.0 * b) / h), h / 10 - 8),
                new(7 * w / 12, h / 10 - 8),
                new(7 * w / 12, 8)
            ];
            g.FillPolygon(new SolidBrush(rightColor), winBoxFillRightPoints);
            // g.FillRectangle(new SolidBrush(rightColor),
            //     new Rectangle(new Point(w / 3 + w / 4, 8), new Size(w / 12 - 8, h / 10 - 16)));

            // Separator lines in wins box
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 12, 0),
                new Point(w / 3 + w / 12, h / 10));
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 4, 0),
                new Point(w / 3 + w / 4, h / 10));

            // Draw timer box
            Pen borderBoxPen = new Pen(Color.Black, 16);
            g.DrawRectangle(borderBoxPen,
                new Rectangle(timerText.Left, timerText.Top, timerText.Width, timerText.Height));

            // Draw hatch box
            g.DrawRectangle(borderBoxPen,
                new Rectangle(leftHatch.Left, leftHatch.Top, leftHatch.Width, leftHatch.Height));
            g.DrawRectangle(borderBoxPen,
                new Rectangle(rightHatch.Left, rightHatch.Top, rightHatch.Width, rightHatch.Height));
        }
    }
}