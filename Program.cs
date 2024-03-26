using WebSocketSharp;
using WebSocketSharp.Server;

namespace MockGARTScore;
public static class GameStat
{
    // Team color
    public static Color LeftColor = Color.Red;
    public static Color RightColor = Color.DodgerBlue;

    // Park status
    public static int LeftParkStatus = 0;
    public static int RightParkStatus = 0;

    // Fuel level
    public static int LeftFuelLevel = 0;
    public static int RightFuelLevel = 0;

    // Hatch status
    public static bool LeftHatchStatus = false;
    public static bool RightHatchStatus = false;

    // Score
    public static int LeftScore = 0;
    public static int RightScore = 0;

    // Wins
    public static int LeftWin = 0;
    public static int RightWin = 0;

    // Penalty
    public static int LeftPenalty = 0;
    public static int RightPenalty = 0;
}
public class WSUpdate : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        // Get team color
        Color leftColor = GameStat.LeftColor;
        Color rightColor = GameStat.RightColor;

        // Init variable
        int left = 0;
        int right = 0;

        // e.Data is the received data
        // Parse it
        // 0 param: command/value name
        // 1st param: real value for red
        // 2nd param: real value for blue
        string[] param = e.Data.Split(",");

        switch (param[0])
        {
            case "status":
                // Send current values to WS client
                // The format will be "left_color,right_color,red_wins,blue_wins,red_score,blue_score,red_hatch,blue_hatch,red_fuel,blue_fuel,red_park,blue_park,has_match_started"
                Send(string.Join(",", Program.InMatchScoreForm.GetCurrentValues()));
                break;
            case "wins":
                // Set the wins number for red and blue team
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetWins(left, right);
                Send("done");
                break;
            case "score":
                // Set both team's score
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetScore(left, right);
                Send("done");
                break;
            case "penalty":
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetPenalty(left, right);
                Send("done");
                break;
            case "hatch":
                // Hatch score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetHatch(left == 1, right == 1);
                Send("done");
                break;
            case "fuel":
                // Fuel score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetFuel(left, right);
                Send("done");
                break;
            case "park":
                // Park score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                Program.InMatchScoreForm.SetPark(left, right);
                Send("done");
                break;
            case "changecolor":
                // Change team color
                Program.InMatchScoreForm.SetTeamColor(rightColor, leftColor);
                Send("done");
                break;
            case "timer":
                // Set timer
                Program.InMatchScoreForm.SetTime(int.Parse(param[1]));
                Send("done");
                break;
            case "start":
                Program.InMatchScoreForm.StartTimer();
                Send("done");
                break;
            case "stop":
                Program.InMatchScoreForm.TimerRunning = false;
                Send("done");
                break;
            case "reset":
                Program.InMatchScoreForm.ResetMatch();
                Send("done");
                break;
            case "publish":
                Program.SwitchForm(Program.FormEnum.PostMatchScore);
                Send("done");
                break;
            case "goback":
                Program.SwitchForm(Program.FormEnum.InMatchScore);
                Send("done");
                break;
            default:
                // No way
                Send("unimplemented");
                break;
        }

        // Send back the confirmation message
        //Send("received");
    }
}

public static class Program
{
    // Forms
    public static InMatchScore InMatchScoreForm = new();
    public static PostMatchScore PostMatchScoreForm = new();

    public enum FormEnum
    {
        InMatchScore,
        PostMatchScore
    }

    public static void SwitchForm(FormEnum target)
    {
        Form to, from;
        if (target == FormEnum.InMatchScore)
        {
            to = InMatchScoreForm;
            from = PostMatchScoreForm;
        }
        else
        {
            to = PostMatchScoreForm;
            from = InMatchScoreForm;
        }

        from.Activate();
        to.Show();
        from.Activate();
        var fadeTimer = new System.Windows.Forms.Timer();
        fadeTimer.Interval = 10;
        from.Opacity = 1;
        fadeTimer.Tick += (_, _) =>
        {
            from.Opacity -= 0.05;
            if (from.Opacity > 0) return;
            to.Activate();
            from.Opacity = 1;
            fadeTimer.Stop();
        };
        fadeTimer.Start();
    }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        InMatchScoreForm.SetTeamColor(Color.Red, Color.DodgerBlue);
        InMatchScoreForm.SetWins(0, 0);
        InMatchScoreForm.SetTime(180);
        InMatchScoreForm.SetScore(0, 0);
        InMatchScoreForm.SetPenalty(0, 0);
        InMatchScoreForm.SetHatch(false, false);
        InMatchScoreForm.SetFuel(0, 0);
        InMatchScoreForm.SetPark(0, 0);

        // Create WebSocket server
        var wssv = new WebSocketServer("ws://0.0.0.0:8000");

        wssv.AddWebSocketService<WSUpdate>("/wsupdate");
        wssv.Start();
        Application.Run(InMatchScoreForm);
        
    }
}