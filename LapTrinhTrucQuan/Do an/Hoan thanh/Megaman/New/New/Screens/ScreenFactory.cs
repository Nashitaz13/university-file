using System;

namespace New
{
    //Interface tạo ra menu
    public class ScreenFactory : IScreenFactory
    {
        public GameScreen CreateScreen(Type screenType)
        {
            //tạo menu = Activator
            return Activator.CreateInstance(screenType) as GameScreen;

        }
    }
}
