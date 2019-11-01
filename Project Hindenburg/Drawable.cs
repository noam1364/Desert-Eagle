using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Project_Hindenburg;

public class Drawable
{
    #region data
    public Texture2D texture;
    public Rectangle? source;
    public float rotation;
    private Vector2 position;
    public SpriteEffects effects;
    Color color;
    #endregion

    #region ctor

    public Drawable(Texture2D texture, Vector2 position, Rectangle? source = null)
    {
        this.position = position;
        this.texture = texture;
        if (source == null)
            this.source = new Rectangle(0, 0, texture.Width, texture.Height);
        else
            this.source = source;
        color = Color.White;
        this.rotation = 0;
        this.effects = SpriteEffects.None;
    }

    public Drawable(ref Texture2D texture,Vector2 position,Rectangle? source=null)
    {
        this.texture = texture;
        this.position = position;
        if (source == null)
            this.source = new Rectangle(0, 0, texture.Width, texture.Height);
        else
            this.source = source;
        color = Color.White;
        this.rotation = 0;
        this.effects = SpriteEffects.None;
    }

    #endregion

    #region public methods

    public virtual void draw()
    {
        Global.sb.Draw(texture,position,source,color,rotation, new Vector2(0, 0), new Vector2(1),effects,0);
    }

    public void addPosX(int n)
    {
        position.X += n;
    }

    public void addPosY(int n)
    {
        position.Y += n;
    }

    #region set methods
    public void setPosTop(int n)
    {
        position.Y = n;
    }

    public void setPosButtom(int n)
    {
        position.Y = n - texture.Height;
    }

    public void setPosRight(int n)
    {
        position.X = n - texture.Width;
    }

    public void setPosLeft(int n)
    {
        position.X = n;
    }

    public void setPosition(Vector2 pos)
    {
        position = pos;
    }

    public void setColor(Color c)
    {
        this.color = c;
    }
    #endregion set methods

    #region get methods

    public int X()
    {
        return (int)position.X;
    }

    public int XRight()
    {
        return (int)position.X + texture.Width;
    }
    public int XCenter()
    {
        return (X() + XRight()) / 2;
    }
    public int YButtom(Texture2D t = null)
    {
        return (int)position.Y + texture.Height;
    }

    public int Y()
    {
        return (int)position.Y;
    }
    public int YCenter()
    {
        return (Y() + YButtom()) / 2;
    }
    public virtual Rectangle GetRect()  //return a rectangle with cords of drawable and its relative dimentions
    {
        return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    #endregion get methods

    #endregion
}
