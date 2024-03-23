using System.ComponentModel;
using System.Windows.Forms;

namespace MockGARTScore
{
    public partial class InMatchScore : Form
    {
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

            g.FillPolygon(new SolidBrush(Color.Red), red_curve_points);

            // Fill blue side in blue
            Point[] blue_curve_points = {
                new Point(sep_up_x, 0),
                new Point(w, 0),
                new Point(w, h),
                new Point(sep_down_x, h)
            };

            g.FillPolygon(new SolidBrush(Color.DodgerBlue), blue_curve_points);

            // Draw separator line
            g.DrawLine(new Pen(new SolidBrush(Color.White), 5), new Point(sep_up_x, 0), new Point(sep_down_x, h));

            // Draw wins box
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(w / 3, 0), new Size(w / 3, h / 10)));
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(w / 3 + 8, 8), new Size(w / 3 - 16, h / 10 - 16)));
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 12, 0), new Point(w / 3 + w / 12, h / 10));
            g.DrawLine(new Pen(new SolidBrush(Color.Black), 8), new Point(w / 3 + w / 4, 0), new Point(w / 3 + w / 4, h / 10));
        }
    }
}
