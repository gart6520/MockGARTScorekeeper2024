namespace MockGARTScore;

public partial class PostMatchScore : Form
{
    public PostMatchScore()
    {
        InitializeComponent();
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.None;
        Size = Screen.PrimaryScreen.Bounds.Size;
        canvas.Size = Size;
        canvas.Paint += Canvas_Paint;
        int w = Width;
        int h = Height;

        teleOpCatLabel.Location = new Point(w / 2 - teleOpCatLabel.Size.Width / 2, 11 * h / 30 - teleOpCatLabel.Height / 2);
        endgameCatLabel.Location = new Point(w / 2 - endgameCatLabel.Size.Width / 2, h / 2 - endgameCatLabel.Height / 2);
        penaltyCatLabel.Location = new Point(w / 2 - penaltyCatLabel.Size.Width / 2, 19 * h / 30 - penaltyCatLabel.Height / 2);
    }

    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        // Canvas size
        int w = canvas.Size.Width;
        int h = canvas.Size.Height;

        //Draw sereperator line
        g.FillRectangle(new SolidBrush(Program.InMatchScoreForm.LeftColor), new Rectangle(0, 0, w / 2, h));
        g.FillRectangle(new SolidBrush(Program.InMatchScoreForm.RightColor), new Rectangle(w / 2, 0, w / 2, h));
        g.DrawLine(new Pen(new SolidBrush(Color.Black), 5), new Point(w / 2, 0), new Point(w / 2, h));

        //Draw category box
        g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(w / 3, 19 * h / 60, w / 3, h / 10));
        g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(w / 3, 9 * h / 20, w / 3, h / 10));
        g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(w / 3, 7 * h / 12, w / 3, h / 10));

    }

    private void penaltyCatLabel_Click(object sender, EventArgs e)
    {

    }
}