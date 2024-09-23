using System;

namespace FlappyBirdDemo
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FlappyBirdGame game = new FlappyBirdGame())
            {
                game.Run();
            }
        }
    }
#endif
}

