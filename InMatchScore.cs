namespace MockGARTScore
{
    public partial class InMatchScore : Form
    {
        // Public variables

        // Team color
        public Color leftColor = Color.Red;
        public Color rightColor = Color.DodgerBlue;

        // Park status
        public int leftParkStatus = 0;
        public int rightParkStatus = 0;

        // Return current values (to WS client)
        public int[] getCurrentValues()
        {
            int[] r =
            {
                (leftColor == Color.Red) ? 0 : 1, // Left color
                (rightColor == Color.DodgerBlue) ? 1 : 0, // Blue color 
                int.Parse((leftColor == Color.Red) ? leftWins.Text : rightWins.Text), // Red wins
                int.Parse((rightColor == Color.DodgerBlue) ? rightWins.Text : leftWins.Text), // Blue wins
                int.Parse((leftColor == Color.Red) ? leftScore.Text : rightScore.Text), // Red score
                int.Parse((rightColor == Color.DodgerBlue) ? rightScore.Text : leftScore.Text), // Blue score
                Convert.ToInt32((leftColor == Color.Red) ? leftHatch.Visible : rightHatch.Visible), // Red hatch
                Convert.ToInt32((rightColor == Color.DodgerBlue) ? rightHatch.Visible : leftHatch.Visible), // Blue hatch
                int.Parse((leftColor == Color.Red) ? leftFuel.Text : rightFuel.Text), // Red fuel
                int.Parse((rightColor == Color.DodgerBlue) ? rightFuel.Text : leftFuel.Text), // Blue fuel
                (leftColor == Color.Red) ? leftParkStatus : rightParkStatus, // Red park
                (rightColor == Color.DodgerBlue) ? rightParkStatus : leftParkStatus // Blue park
            };

            return r;
        }

        // Set team color
        public void setTeamColor(Color left, Color right)
        {
            // Window size
            int w = Size.Width;
            int h = Size.Height;

            // Set team color variables
            leftColor = left;
            rightColor = right;

            // Redraw canvas
            canvas.Refresh();

            // Change team wins text background color
            leftWins.BackColor = leftColor;
            rightWins.BackColor = rightColor;

            // Change team name
            leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

            // Realign team name
            leftTeamName.Location = new Point(
                w / 4 - leftTeamName.Size.Width / 2,
                h / 8);
            rightTeamName.Location = new Point(
                w * 3 / 4 - rightTeamName.Size.Width / 2,
                h / 8);

            // Change team name background
            leftTeamName.BackColor = leftColor;
            rightTeamName.BackColor = rightColor;

            // Change score background
            leftScore.BackColor = leftColor;
            rightScore.BackColor = rightColor;

            // Change hatch background
            leftHatch.BackColor = leftColor;
            rightHatch.BackColor = rightColor;
            //leftHatch.Refresh();
            //rightHatch.Refresh();

            // Change fuel background
            leftFuelLabel.BackColor = leftColor;
            leftFuel.BackColor = leftColor;
            rightFuelLabel.BackColor = rightColor;
            rightFuel.BackColor = rightColor;

            // Set park background
            leftParkNo.BackColor = Color.ForestGreen;
            leftParkHalf.BackColor = leftColor;
            leftParkFull.BackColor = leftColor;

            rightParkNo.BackColor = Color.ForestGreen;
            rightParkHalf.BackColor = rightColor;
            rightParkFull.BackColor = rightColor;
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

            // Align team scores
            leftScore.Location = new Point(
                w / 4 - leftScore.Size.Width / 2,
                h / 4);
            rightScore.Location = new Point(
                w * 3 / 4 - rightScore.Size.Width / 2,
                h / 4);
        }

        // Set hatch
        public void setHatch(bool left, bool right)
        {
            leftHatch.Visible = left;
            rightHatch.Visible = right;
            leftHatch.Refresh();
            rightHatch.Refresh();
        }

        // Set fuel
        public void setFuel(int left, int right)
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
        public void setPark(int left, int right)
        {
            // Set park status
            leftParkStatus = left;
            rightParkStatus = right;

            // Left
            leftParkNo.BackColor = leftColor;
            leftParkHalf.BackColor = leftColor;
            leftParkFull.BackColor = leftColor;
            switch (left)
            {
                case 0:
                    leftParkNo.BackColor = Color.ForestGreen;
                    break;
                case 1:
                    leftParkHalf.BackColor = Color.ForestGreen;
                    break;
                case 2:
                    leftParkFull.BackColor = Color.ForestGreen;
                    break;
                default:
                    // How tf
                    break;
            }

            // Right
            rightParkNo.BackColor = rightColor;
            rightParkHalf.BackColor = rightColor;
            rightParkFull.BackColor = rightColor;
            switch (right)
            {
                case 0:
                    rightParkNo.BackColor = Color.ForestGreen;
                    break;
                case 1:
                    rightParkHalf.BackColor = Color.ForestGreen;
                    break;
                case 2:
                    rightParkFull.BackColor = Color.ForestGreen;
                    break;
                default:
                    // How tf
                    break;
            }
        }

        // Set timer
        public void setTime(int seconds)
        {
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

        // Set wins
        public void setWins(int left, int right)
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
            leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

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
                w / 8 - leftParkNo.Size.Width / 2,
                h - leftParkNo.Size.Height * 4 / 3);
            leftParkHalf.Location = new Point(
                w / 4 - leftParkHalf.Size.Width / 2,
                h - leftParkNo.Size.Height * 4 / 3);
            leftParkFull.Location = new Point(
                w * 3 / 8 - leftParkFull.Size.Width / 2,
                h - leftParkFull.Size.Height * 4 / 3);

            rightParkNo.Location = new Point(
                w / 2 + w / 8 - rightParkNo.Size.Width / 2,
                h - rightParkNo.Size.Height * 4 / 3);
            rightParkHalf.Location = new Point(
                w / 2 + w / 4 - rightParkHalf.Size.Width / 2,
                h - rightParkHalf.Size.Height * 4 / 3);
            rightParkFull.Location = new Point(
                w / 2 + w * 3 / 8 - rightParkFull.Size.Width / 2,
                h - rightParkFull.Size.Height * 4 / 3);
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
            int sep_up_x = w * 9 / 16;
            int sep_down_x = w * 7 / 16;

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