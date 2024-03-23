using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            this.leftWins.BackColor = leftColor;
            this.rightWins.BackColor = rightColor;

            // Change team name
            this.leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            this.rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

            // Change team name background
            this.leftTeamName.BackColor = leftColor;
            this.rightTeamName.BackColor = rightColor;
        }

        // Set score
        public void setScore(int left, int right)
        {
            // Window size
            int w = this.Size.Width;
            int h = this.Size.Height;

            // Set team scores
            this.leftScore.Text = left.ToString();
            this.rightScore.Text = right.ToString();

            // Aligin team scores
            this.leftScore.Location = new Point(
                w / 4 - this.leftScore.Size.Width / 2,
                h / 2 - this.leftScore.Size.Height / 2);
            this.rightScore.Location = new Point(
                w * 3 / 4 - this.rightScore.Size.Width / 2,
                h / 2 - this.rightScore.Size.Height / 2);
        }

        public InMatchScore()
        {
            InitializeComponent();

            // Set Form to full screen
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            // Set PictureBox size to full Form size
            this.canvas.Size = this.Size;

            // Window size
            int w = this.Size.Width;
            int h = this.Size.Height;

            // Add paint event handler to the canvas
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);

            // Aligin the "Wins" label to the center
            this.winsLabel.Location = new Point(
                (w - this.winsLabel.Size.Width) / 2,
                (h / 10 - this.winsLabel.Size.Height) / 2);

            // Aligin the leftWins and rightWins label
            this.leftWins.Location = new Point(
                w / 3 + w / 24 - this.leftWins.Size.Width / 2,
                (h / 10 - this.leftWins.Size.Height) / 2);
            this.rightWins.Location = new Point(
                w / 3 + w * 7 / 24 - this.rightWins.Size.Width / 2,
                (h / 10 - this.rightWins.Size.Height) / 2);

            // Aligin the timerText to center
            this.timerText.Location = new Point(
                (w - this.timerText.Size.Width) / 2,
                (h - this.timerText.Size.Height) / 2);

            // Set team name
            this.leftTeamName.Text = leftColor == Color.Red ? "RED" : "BLUE";
            this.rightTeamName.Text = rightColor == Color.DodgerBlue ? "BLUE" : "RED";

            // Aligin team names
            this.leftTeamName.Location = new Point(
                w / 4 - this.leftTeamName.Size.Width / 2,
                h / 4 - this.leftTeamName.Size.Height / 2);
            this.rightTeamName.Location = new Point(
                w * 3 / 4 - this.rightTeamName.Size.Width / 2,
                h / 4 - this.rightTeamName.Size.Height / 2);

            // Aligin team scores
            this.leftScore.Location = new Point(
                w / 4 - this.leftScore.Size.Width / 2,
                h / 2 - this.leftScore.Size.Height / 2);
            this.rightScore.Location = new Point(
                w * 3 / 4 - this.rightScore.Size.Width / 2,
                h / 2 - this.rightScore.Size.Height / 2);

            // Aligin hatch images
            this.leftHatch.Location = new Point(
                w / 4 - this.leftHatch.Size.Width / 2,
                h / 2 + h / 6 - this.leftHatch.Size.Height / 2);
            this.rightHatch.Location = new Point(
                w * 3 / 4 - this.rightHatch.Size.Width / 2,
                h / 2 + h / 6 - this.rightHatch.Size.Height / 2);
        }

        void exitButton_Click(object sender, EventArgs e)
        {
            // Exit
            Application.Exit();
        }

        private void canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // Canvas size
            int w = this.canvas.Size.Width;
            int h = this.canvas.Size.Height;

            // Calculate separator line
            int sep_up_x = w / 2;
            int sep_down_x = w / 2;

            // Fill red side in red
            Point[] red_curve_points = {
                new Point(0, 0),
                new Point(sep_up_x, 0),
                new Point(sep_down_x, h),
                new Point(0, h)
            };

            g.FillPolygon(new SolidBrush(leftColor), red_curve_points);

            // Fill blue side in blue
            Point[] blue_curve_points = {
                new Point(sep_up_x, 0),
                new Point(w, 0),
                new Point(w, h),
                new Point(sep_down_x, h)
            };

            g.FillPolygon(new SolidBrush(rightColor), blue_curve_points);

            // Draw separator line
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), new Point(sep_up_x, 0), new Point(sep_down_x, h));

            // Draw wins box
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(w / 3, 0), new Size(w / 3, h / 10)));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(w / 3 + 8, 8), new Size(w / 3 - 16, h / 10 - 16)));

            // Fill team color to the wins number
            g.FillRectangle(new SolidBrush(leftColor), new Rectangle(new Point(w / 3 + 8, 8), new Size(w / 12 - 8, h / 10 - 16)));
            g.FillRectangle(new SolidBrush(rightColor), new Rectangle(new Point(w / 3 + w / 4, 8), new Size(w / 12 - 8, h / 10 - 16)));

            // Separator lines in wins box
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 12, 0), new Point(w / 3 + w / 12, h / 10));
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 4, 0), new Point(w / 3 + w / 4, h / 10));

            // Draw timer box
            Pen borderBoxPen = new Pen(Color.Black, 16);
            g.DrawRectangle(borderBoxPen, new Rectangle(this.timerText.Left, this.timerText.Top, this.timerText.Width, this.timerText.Height));

            // Draw hatch box
            g.DrawRectangle(borderBoxPen, new Rectangle(this.leftHatch.Left, this.leftHatch.Top, this.leftHatch.Width, this.leftHatch.Height));
            g.DrawRectangle(borderBoxPen, new Rectangle(this.rightHatch.Left, this.rightHatch.Top, this.rightHatch.Width, this.rightHatch.Height));
        }
    }
}
