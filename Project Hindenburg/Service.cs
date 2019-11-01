using static Global;
using Project_Hindenburg;

public static class Service
{
    #region public methods

    public static bool gameOn()
    {
        return DesertEagle.flow == gameFlow.gameOn;
    }

    public static bool gameOver()
    {
        return DesertEagle.flow == gameFlow.gameOver;
    }

    public static bool startMenu()
    {
        return DesertEagle.flow == gameFlow.startMenu;
    }

    public static void setGame(gameFlow f)
    {
        DesertEagle.flow = f;
    }

    #endregion public methods
}
