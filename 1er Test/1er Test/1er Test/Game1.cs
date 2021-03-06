using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _1er_Test
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Virus test;
        Tower test2;
        Keypoint test3;
        Keypoint test4;
        Keypoint test5;
        Vector2 v = new Vector2(0, 0);
        Vector2 v2 = new Vector2(200, 100);
        List<Unite> virus = new List<Unite>();
        List<Unite> tower = new List<Unite>();
        List<Keypoint> keypoints = new List<Keypoint>();
        List<int> indexs = new List<int>();
        private Song song;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            MediaPlayer.IsRepeating = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            test = new Virus("b", 10, 10, 5, v, 1, Content, spriteBatch, Etat.Alive);
            test2 = new Tower("a", 10, 10, 5, v2, 100, Content, spriteBatch, Etat.Alive);
            test3 = new Keypoint(new Vector2(200, 0), false, false);
            test4 = new Keypoint(new Vector2(200, 400), true, false);
            test5 = new Keypoint(new Vector2(500, 400), true, true);
            virus.Add(test);
            tower.Add(test2);
            keypoints.Add(test3);
            keypoints.Add(test4);
            keypoints.Add(test5);
            song = Content.Load<Song>("Menu theme");
            MediaPlayer.Play(song);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            foreach (Virus v in virus)
            {
                v.NewPosition();
                v.Turn(keypoints, virus, ref indexs);
            }
            foreach (int i in indexs)
            {
                virus.RemoveAt(i);
            }
            indexs.Clear();
            // TODO: Add your update logic here
            foreach (Tower t in tower)
            {
                t.Stating(virus);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (Virus v in virus)
            {
                v.StateDraw();
            }
            foreach (Tower t in tower)
            {
                t.StateDraw();
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
