using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Project_Hindenburg;



public class Obsticle : Drawable
{
    #region data

    public bool added;
    int vx;
    public int hatchY;
    int hatchSize;
    Drawable hatch;
    ///static members:
    static Texture2D obstTex;
    static Texture2D bgTex;
    
    #endregion data

    #region ctor

    public Obsticle(Vector2 position) : base(ref obstTex,position)
    {
        ///variabels initialization:
        added = false;
        vx = -15;   ///actual speed on the screen-->obsticle moves backwards
        hatchSize = 400;
        hatchY = GetRandomY();
        ///objects initialization:
        hatch = new Drawable(ref bgTex,new Vector2(X(), hatchY), new Rectangle(X(), hatchY, obstTex.Width, hatchSize));
    }

    #endregion ctor

    #region private methods

    private int GetRandomY()
    {
        Random r = new Random();
        int ran = (r.Next(0, 680) / 50) * 50;
        return ran;
    }

    #endregion private methods

    #region public methods

    public void movmentManager()
    {
        addPosX(vx);
        hatch.addPosX(vx);
        hatch.source = new Rectangle(X(), hatchY, obstTex.Width, hatchSize);
        if (XRight() < 0)
        {
            setPosLeft(Global.winWidth);
            hatch.setPosLeft(Global.winWidth);
            hatchY = GetRandomY();
            hatch.setPosTop(hatchY);
            added = false;

        }
    }

    public override void draw()
    {
        base.draw();
        hatch.draw();
    }

    public Rectangle[] GetObsticleRects()
    {
        Rectangle top = new Rectangle(X(), 0, texture.Width, hatchY);
        Rectangle buttom = new Rectangle(X(), HatchButtom(), texture.Width, Global.winHeight - HatchButtom());
        return new Rectangle[] { buttom, top };
    }

    public int HatchButtom()
    {
        return hatchY + hatchSize;
    }

    public static void initStaticMembers(Texture2D bg,Texture2D obst)
    {
        bgTex = bg;
        obstTex = obst;
    }

    #endregion public methods
}








                
           
