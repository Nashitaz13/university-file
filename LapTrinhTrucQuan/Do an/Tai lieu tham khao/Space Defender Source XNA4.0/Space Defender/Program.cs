using System;

namespace Space_Defender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceDefender game = new SpaceDefender())
            {
                game.Run();
            }
        }
    }
}

