using Microsoft.Xna.Framework.Input;



public static class InputHandler
{
    private static KeyboardState previous;

    public static bool KeyStroke(Keys key)
    {
        return Keyboard.GetState().IsKeyDown(key) && !previous.IsKeyDown(key);
    }

    public static void update()
    {
        previous = Keyboard.GetState();
    }
}
