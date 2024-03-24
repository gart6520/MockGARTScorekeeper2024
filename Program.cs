using MockGARTScore;
using System;
using System.Runtime.CompilerServices;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MockGARTScore
{
    public class WSUpdate : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            // Get team color
            Color leftColor = Program.inMatchScoreForm.leftColor;
            Color rightColor = Program.inMatchScoreForm.rightColor;

            // Init variable
            int left = 0;
            int right = 0;

            // e.Data is the received data
            // Parse it
            // 0 param: command/value name
            // 1st param: real value for red
            // 2nd param: real value for blue
            string[] param = e.Data.Split(",");

            switch(param[0])
            {
                case "status":
                    // Send current values to WS client
                    // The format will be "left_color,right_color,red_wins,blue_wins,red_score,blue_score,red_hatch,blue_hatch,red_fuel,blue_fuel,red_park,blue_park"
                    Send(string.Join(",", Program.inMatchScoreForm.getCurrentValues()));
                    break;
                case "wins":
                    // Set the wins number for red and blue team
                    left = int.Parse((leftColor == Color.Red) ? param[1] : param[2]);
                    right = int.Parse((rightColor == Color.DodgerBlue) ? param[2] : param[1]);
                    Program.inMatchScoreForm.setWins(left, right);
                    Send("done");
                    break;
                case "score":
                    // Set both team's score
                    left = int.Parse((leftColor == Color.Red) ? param[1] : param[2]);
                    right = int.Parse((rightColor == Color.DodgerBlue) ? param[2] : param[1]);
                    Program.inMatchScoreForm.setScore(left, right);
                    Send("done");
                    break;
                case "hatch":
                    // Hatch score display
                    left = int.Parse((leftColor == Color.Red) ? param[1] : param[2]);
                    right = int.Parse((rightColor == Color.DodgerBlue) ? param[2] : param[1]);
                    Program.inMatchScoreForm.setHatch(left == 1 ? true : false, right == 1 ? true : false);
                    Send("done");
                    break;
                case "fuel":
                    // Fuel score display
                    left = int.Parse((leftColor == Color.Red) ? param[1] : param[2]);
                    right = int.Parse((rightColor == Color.DodgerBlue) ? param[2] : param[1]);
                    Program.inMatchScoreForm.setFuel(left, right);
                    Send("done");
                    break;
                case "park":
                    // Park score display
                    left = int.Parse((leftColor == Color.Red) ? param[1] : param[2]);
                    right = int.Parse((rightColor == Color.DodgerBlue) ? param[2] : param[1]);
                    Program.inMatchScoreForm.setPark(left, right);
                    Send("done");
                    break;
                case "changecolor":
                    // Change team color
                    Color curr_left = leftColor;
                    Color curr_right = rightColor;
                    Program.inMatchScoreForm.setTeamColor(curr_right, curr_left);
                    Send("done");
                    break;
                case "timer":
                    // Set timer
                    Program.inMatchScoreForm.setTime(int.Parse(param[1]));
                    Send("done");
                    break;
                case "start":
                    Program.inMatchScoreForm.startTimer();
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
        public static InMatchScore inMatchScoreForm = new InMatchScore();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create WebSocket server
            var wssv = new WebSocketServer("ws://0.0.0.0:8000");

            wssv.AddWebSocketService<WSUpdate>("/wsupdate");
            wssv.Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            inMatchScoreForm.setTeamColor(Color.Red, Color.DodgerBlue);
            inMatchScoreForm.setWins(0, 0);
            inMatchScoreForm.setTime(180);
            inMatchScoreForm.setScore(0, 0);
            inMatchScoreForm.setHatch(false, false);
            inMatchScoreForm.setFuel(0, 0);
            inMatchScoreForm.setPark(0, 0);

            Application.Run(inMatchScoreForm);
        }
    }
}