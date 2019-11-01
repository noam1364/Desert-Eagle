using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using static Service;
using static Global;

namespace Project_Hindenburg
{       ///naming convention: void methods with a lower case first letter,functions with upper case first letter,
        ///methods of class Game1 always with an upper case first letter
    public class DesertEagle : Game
    {
        #region data
        bool isGeneticActive = true;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ///assets:
        Drawable bg;
        Drawable gameOverMenu;
        ///game objects:
        Score score;
        int spaceBetweenPillers;
        public static gameFlow flow;
        #endregion data
        #region ctor
        public DesertEagle()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #endregion ctor
        #region monogame methods

        protected override void Initialize()
        {
            base.Initialize();
            flow = gameFlow.startMenu;
            graphics.PreferredBackBufferWidth = Global.winWidth;
            graphics.PreferredBackBufferHeight = Global.winHeight;
            graphics.ApplyChanges();
            Window.Title = "Desert Eagle";
            InputHandler.update();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.cm = Content;
            Global.sb = spriteBatch;
            Global.winHeight = 1080;
            Global.winWidth = 1920;

            Texture2D obstTex = Content.Load<Texture2D>("Textures/pillerSample");
            Texture2D bgTex = Content.Load<Texture2D>("Textures/background2");
            Texture2D gameOverTex = Content.Load<Texture2D>("Textures/gameOver");
            Obsticle.initStaticMembers(bgTex, obstTex);
            rock = new Obsticle[2];

            int gameOverMenuXpos = winWidth / 2 - gameOverTex.Width/2;
            spaceBetweenPillers = winWidth / rock.Length;

            //jumpSound = Content.Load<SoundEffect>("Audio/wma/jumpSound");

            gameOverMenu = new Drawable(gameOverTex, new Vector2(gameOverMenuXpos, 200));
            bg = new Drawable(bgTex, new Vector2(0, 0));
            score = new Score(Content.Load<Texture2D>("Textures/digits"), gameOverTex);
            bird = new Bird();

            
            for (int i=0;i < rock.Length;i++)
                rock[i] = new Obsticle(new Vector2(1920 + spaceBetweenPillers * i,0));

            ///needs to be called with the rest of the game initialized
            GeneticAlgorithm.Initiate();
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (gameOn())
                {
                    bird.movmentManager();
                    for (int i = 0; i < rock.Length; i++)
                        rock[i].movmentManager();
                    CheckCollitions();
                }   
                ReciveUserInput();
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            
            bg.draw();
            for (int i = 0; i < rock.Length; i++)
                rock[i].draw();
            bird.draw();

            if (gameOver())
                gameOverMenu.draw();

            score.draw(flow);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        #endregion monogame methods
        #region my methods
        private void ReciveUserInput()
        {
            if (InputHandler.KeyStroke(Keys.Escape))
                this.Exit();
            if(gameOn())
            {
                if (InputHandler.KeyStroke(Keys.Space)|| InputHandler.KeyStroke(Keys.Up))
                {
                    bird.jump();
                }
            }
            else
            {
                if (InputHandler.KeyStroke(Keys.Enter)&&!startMenu())
                    Restart();
                else if (startMenu() && (InputHandler.KeyStroke(Keys.Space) || InputHandler.KeyStroke(Keys.Up)))
                {
                    setGame(gameFlow.gameOn);
                    bird.jump();
                    //jumpSound.Play();
                }
            }
            InputHandler.update();
        }
        private void CheckCollitions()
        {
            for(int i=0; i<rock.Length;i++)
            {
                if (bird.crashed(rock[i]))
                    GameOver();
                else
                {
                    if (bird.XRight() > rock[i].X() && rock[i].added == false)
                    {
                        score.add();
                        rock[i].added = true;
                    }
                }
            }
        }
        private void GameOver()
        {
            setGame(gameFlow.gameOver);
            score.save();
        }
        private void Restart()
        {
            for (int i = 0; i < rock.Length; i++)
                rock[i] = new Obsticle(new Vector2(1920 + spaceBetweenPillers * i, 0));
            bird.setPosition(new Vector2(300, 500));
            setGame(gameFlow.startMenu);
            score.reset();
        }
        #endregion my methods

    }
}
