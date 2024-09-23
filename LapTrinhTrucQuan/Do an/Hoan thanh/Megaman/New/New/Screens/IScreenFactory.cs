using System;

namespace New
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
