using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_Hindenburg;
using static Global;

public class Bird : Drawable
{
    #region data
   
    public int vy;     ///vy is the "real" velocity on the screen | negetive for up and positive for down
    int v0y;
    int g;

    #endregion data

    #region ctor

    public Bird() :base(cm.Load<Texture2D>("Textures/player"), new Vector2(300, 500))
    {
        g = 4;
        v0y = -35;
        vy = 0;
    }

    #endregion ctor

    #region private methods

    private Rectangle[] GetBirdRects()
    {
        Rectangle bird = base.GetRect();

        Rectangle tail = new Rectangle(bird.X + 9, bird.Y + 47, 57, 56);

        Rectangle bodyButtom = new Rectangle(bird.X + 75, bird.Y + 101, 79, 12);
        Rectangle bodyButtom2 = new Rectangle(bird.X + 82, bird.Y + 113, 60, 6);
        Rectangle bodyButtom3 = new Rectangle(bird.X + 92, bird.Y + 119, 40, 3);

        Rectangle body = new Rectangle(bird.X + 62, bird.Y + 43, 109, 59);
        Rectangle bodyTop = new Rectangle(bird.X + 72, bird.Y + 32, 92, 12);

        Rectangle finLeft = new Rectangle(bird.X + 72, bird.Y + 13, 17, 18);
        Rectangle finRight = new Rectangle(bird.X + 115, bird.Y + 6, 8, 26);
        Rectangle finRight2 = new Rectangle(bird.X + 123, bird.Y + 21, 29, 11);

        Rectangle beak = new Rectangle(bird.X + 168, bird.Y + 50, 51, 41);
        return new Rectangle[] { tail, bodyButtom3, bodyButtom2, bodyButtom, body,
            bodyTop, finLeft, finRight, finRight2, beak };
    }

    #endregion private methods

    #region public methods

    public void movmentManager()
    {
        addPosY(vy);
        vy += g;
        if (YButtom() > Global.winHeight)
            setPosButtom(Global.winHeight);
        else
        {
            if (Y() < 0)
                setPosTop(0);
        }
    }

    public void jump()
    {
        vy = v0y;
    }

    public bool crashed(Obsticle rock)
    {
        Rectangle[] bird = GetBirdRects();
        Rectangle[] obst = rock.GetObsticleRects();
        for (int i = 0; i < bird.Length; i++)
        {
            if (bird[i].Intersects(obst[0]) || bird[i].Intersects(obst[1]))
             return true;
        }
        return false;
    }

    #endregion public methods
}
