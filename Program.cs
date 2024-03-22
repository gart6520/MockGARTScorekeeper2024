using System;
using System.Runtime.CompilerServices;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MockGARTScore
{
    public class UpdateScore : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            // e.Data is the received data
            // Parse it
            // First parameter: team color
            // Second param: value name
            // Third param: real value (score,...)
            string[] param = e.Data.Split(",");

            switch(param[1])
            {
                case "hatch":
                    // Hatch score display
                    int hatchscore = int.Parse(param[2]);
                    break;
                case "fuel":
                    // Fuel score display
                    break;
                case "park":
                    // Park score display
                    break;
                default:
                    // No way
                    break;
            }

            // Send back the confirmation message
            Send("received");
        }
    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create WebSocket server
            var wssv = new WebSocketServer("ws://0.0.0.0");

            wssv.AddWebSocketService<UpdateScore>("/updatescore");
            wssv.Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new InMatchScore());
        }
    }
}