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
        ((ISupportInitialize)canvas).BeginInit();
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
        teleOpCatLabel.BackColor = Color.Yellow;
        teleOpCatLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        teleOpCatLabel.Location = new Point(589, 247);
        teleOpCatLabel.Name = "teleOpCatLabel";
        teleOpCatLabel.Size = new Size(485, 74);
        teleOpCatLabel.TabIndex = 1;
        teleOpCatLabel.Text = "Driver Controlled";
        // 
        // endgameCatLabel
        // 
        endgameCatLabel.AutoSize = true;
        endgameCatLabel.BackColor = Color.Yellow;
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
        penaltyCatLabel.BackColor = Color.Yellow;
        penaltyCatLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        penaltyCatLabel.Location = new Point(574, 424);
        penaltyCatLabel.Name = "penaltyCatLabel";
        penaltyCatLabel.Size = new Size(226, 74);
        penaltyCatLabel.TabIndex = 3;
        penaltyCatLabel.Text = "Penalty";
        penaltyCatLabel.Click += penaltyCatLabel_Click;
        // 
        // PostMatchScore
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1258, 904);
        Controls.Add(penaltyCatLabel);
        Controls.Add(endgameCatLabel);
        Controls.Add(teleOpCatLabel);
        Controls.Add(canvas);
        Name = "PostMatchScore";
        Text = "PostMatch";
        ((ISupportInitialize)canvas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox canvas;
    private Label teleOpCatLabel;
    private Label endgameCatLabel;
    private Label penaltyCatLabel;
}