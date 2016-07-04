using System;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
#if WINDOWS || LINUX || XBOX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Game1 Game;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {          // Because of loose coupling, weve made it so, that the sql local server location is only filled in once

            using (var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=mamma5;Database=Project3"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    using (var game = new Game1(cmd))
                    {
                        Game = game;
                        game.Run();
                    }
                }
            }
        }
    }
#endif
}
