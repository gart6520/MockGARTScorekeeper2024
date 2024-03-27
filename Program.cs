using WebSocketSharp;
using WebSocketSharp.Server;
using Timer = System.Timers.Timer;

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
    public class GameEventArgs<T>(T left, T right) : EventArgs
    {
        public readonly T Left = left, Right = right;
    }

    public class SetTimerEventArgs(int time) : EventArgs
    {
        public readonly int Time = time;
    }

    public static event EventHandler<GameEventArgs<int>> SetFuel = null!;
    public static event EventHandler<GameEventArgs<int>> SetPark = null!;
    public static event EventHandler<GameEventArgs<int>> SetPenalty = null!;
    public static event EventHandler<GameEventArgs<int>> SetScore = null!;
    public static event EventHandler<GameEventArgs<int>> SetWins = null!;
    public static event EventHandler<GameEventArgs<bool>> SetHatch = null!;
    public static event EventHandler<GameEventArgs<Color>> SetTeamColor = null!;
    public static event EventHandler StartTimer = null!;
    public static event EventHandler AbortMatch = null!;
    public static event EventHandler<SetTimerEventArgs> SetTimer = null!;
    public static event EventHandler ResetMatch = null!;
    public static event EventHandler Publish = null!;
    public static event EventHandler GoBack = null!;

    protected override void OnMessage(MessageEventArgs e)
    {
        // Get team color
        var leftColor = GameStat.LeftColor;
        var rightColor = GameStat.RightColor;

        // Init variable
        int left;
        int right;

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
                SetWins.Invoke(this, new(left, right));
                Send("done");
                break;
            case "score":
                // Set both team's score
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                SetScore.Invoke(this, new(left, right));
                Send("done");
                break;
            case "penalty":
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                SetPenalty.Invoke(this, new(left, right));
                Send("done");
                break;
            case "hatch":
                // Hatch score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                SetHatch.Invoke(this, new(left == 1, right == 1));
                Send("done");
                break;
            case "fuel":
                // Fuel score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                SetFuel.Invoke(this, new(left, right));
                Send("done");
                break;
            case "park":
                // Park score display
                left = int.Parse(leftColor == Color.Red ? param[1] : param[2]);
                right = int.Parse(rightColor == Color.DodgerBlue ? param[2] : param[1]);
                SetPark.Invoke(this, new(left, right));
                Send("done");
                break;
            case "changecolor":
                // Change team color
                SetTeamColor.Invoke(this, new(rightColor, leftColor));
                Send("done");
                break;
            case "timer":
                // Set timer
                SetTimer.Invoke(this, new(int.Parse(param[1])));
                Send("done");
                break;
            case "start":
                StartTimer.Invoke(this, EventArgs.Empty);
                Send("done");
                break;
            case "abort":
                // Program.InMatchScoreForm.TimerRunning = false;
                AbortMatch.Invoke(this, EventArgs.Empty);
                Send("done");
                break;
            case "reset":
                ResetMatch.Invoke(this, EventArgs.Empty);
                Send("done");
                break;
            case "publish":
                Publish.Invoke(this, EventArgs.Empty);
                Send("done");
                break;
            case "goback":
                GoBack.Invoke(this, EventArgs.Empty);
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
    public static readonly InMatchScore InMatchScoreForm = new();
    public static readonly PostMatchScore PostMatchScoreForm = new();

    private enum FormEnum
    {
        InMatchScore,
        PostMatchScore
    }

    private static void SwitchForm(FormEnum target)
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

        from.Invoke(() => from.Activate());
        to.Invoke(() =>
        {
            to.Opacity = 0;
            to.Show();
            to.Activate();
        });
        from.Invoke(() => from.Activate());
        to.Invoke(() => to.Opacity = 1);
        var fadeTimer = new Timer(10);
        fadeTimer.Interval = 10;
        from.Invoke(() => from.Opacity = 1);
        fadeTimer.Elapsed += (_, _) =>
        {
            from.Invoke(() => from.Opacity -= 0.05);
            if (from.Opacity > 0) return;
            to.Invoke(() => to.Activate());
            from.Invoke(() => from.Opacity = 1);
            fadeTimer.Stop();
            fadeTimer.Dispose();
        };
        fadeTimer.Start();
    }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();


        // Create WebSocket server
        var webSocketServer = new WebSocketServer("ws://0.0.0.0:8000");

        webSocketServer.AddWebSocketService<WSUpdate>("/wsupdate");
        webSocketServer.Start();

        WSUpdate.Publish += (_, _) => SwitchForm(FormEnum.PostMatchScore);
        WSUpdate.GoBack += (_, _) => SwitchForm(FormEnum.InMatchScore);
        InMatchScoreForm.Publish += (_, _) => SwitchForm(FormEnum.PostMatchScore);
        PostMatchScoreForm.GoBack += (_, _) => SwitchForm(FormEnum.InMatchScore);


        Application.Run(InMatchScoreForm);
    }
}