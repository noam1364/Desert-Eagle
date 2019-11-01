using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Project_Hindenburg;





public static class Global
{
    public static ContentManager cm;
    public static SpriteBatch sb;
    public static int winWidth, winHeight;
    
    public static Bird bird;
    public static BirdBot[] birds;
    public static Obsticle[] rock;

    public static String leaderboardFile = "C:/workspaces/C# workspace/Project Hindenburg/Project Hindenburg" +
               "/Content/bin/Windows/Leaderboard.txt";
    public enum gameFlow
    {
        startMenu, gameOn, gameOver
    };
}



       