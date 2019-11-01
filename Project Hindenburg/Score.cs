using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Global;
using Project_Hindenburg;

[Serializable]
public class Score 
{
    #region data

    int score;
    [NonSerialized]
    int bestScore;
    [NonSerialized]
    Texture2D digits;
    [NonSerialized]
    int[] xPosScore;
    [NonSerialized]
    int[] xPosBest;
    [NonSerialized]
    int yPos;   ///yPos when to draw in when in gameover screen
    
    #endregion data

    #region ctor

    public Score(Texture2D digsTex,Texture2D gameOverTex)
    {
        score = 0;
        bestScore = DataHandler.ReadFromBinaryFile<int>(leaderboardFile);
        digits = digsTex;
        xPosScore = new int[5];
        xPosBest = new int[5];
       
        for (int i = 4; i > 0; i--) ///pos[0]-->location of the 5th digit | pos[5]-->location of 1st digit
            xPosScore[i] = 694 + (digits.Width / 10) * (i - 1);
        yPos = 706;

        for (int i = 4; i > 0; i--) ///pos[0]-->location of the 5th digit | pos[5]-->location of 1st digit
            xPosBest[i] = 1154+(digits.Width / 10) * (i - 1);
    }

    #endregion ctor

    #region private methods

    private int[] ToIntArr(int num)
    {
        char[] arr = num.ToString().ToCharArray();
        int[] digit = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            digit[i] = arr[i] - '0';
        return digit;
    }

    #endregion private methods
    
    #region public methods

    public void draw(gameFlow flow)
    {
        int[] scoreDigits = ToIntArr(score);
        int[] bestDigits = ToIntArr(bestScore);
        
        if(flow == gameFlow.gameOver)
        {
            for (int i = 0; i < scoreDigits.Length; i++)
                sb.Draw(digits, new Vector2(xPosScore[scoreDigits.Length - i], yPos), new Rectangle((digits.Width / 10) * scoreDigits[scoreDigits.Length - 1 - i], 0, digits.Width / 10, digits.Height), Color.White);

            for (int i = 0; i < bestDigits.Length; i++)
                sb.Draw(digits, new Vector2(xPosBest[bestDigits.Length - i], yPos), new Rectangle((digits.Width / 10) * bestDigits[bestDigits.Length - 1 - i], 0, digits.Width / 10, digits.Height), Color.White);
        }
        else
        {
            for (int i = 0; i < scoreDigits.Length; i++)
                sb.Draw(digits, new Vector2(xPosScore[scoreDigits.Length - i]-694,0), new Rectangle((digits.Width / 10) * scoreDigits[scoreDigits.Length - 1 - i], 0, digits.Width / 10, digits.Height), Color.White);

        }
    }

    public void add()
    {
        score++;
    }

    public void reset()
    {
        score = 0;
        bestScore = DataHandler.ReadFromBinaryFile<int>(leaderboardFile);
    }

    public void save()
    {
        if(score>bestScore)
        {
            DataHandler.WriteToBinaryFile<int>(leaderboardFile, this.score);
            bestScore = score;
        }
    }

    #endregion public methods
}
