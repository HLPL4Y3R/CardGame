using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CardGame.Interface;
using CardGame.Control;
using CardGame;
using System.Collections.Generic;

namespace CardGame
{
    public class InterfaceManager
    {
        MainMenu MainMenuScreen = new MainMenu();
        Host HostScreen = new Host();

        Game GameInstance;

        byte GameScreen = ScreenID.MainMenu;

        public InterfaceManager(Input input)
        {
            input.OnClickReleaseLeft += FindOnClickRelease;
        }

        public void Update(Viewport viewport, Input input, GameTime gameTime)
        {
            switch (GameScreen)
            {
                case ScreenID.MainMenu: MainMenuScreen.Update(viewport, input, gameTime); break;
                case ScreenID.Host: HostScreen.Update(viewport, input, gameTime); break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            switch (GameScreen)
            {
                case ScreenID.MainMenu: MainMenuScreen.Draw(spriteBatch, viewport); break;
                case ScreenID.Host: HostScreen.Draw(spriteBatch, viewport); break;
            }
        }

        public void FindOnClickRelease(object sender, ClickInputEventArgs args)
        {
            switch (GameScreen)
            {
                case ScreenID.MainMenu: 
                    foreach (Button button in MainMenuScreen.InterfaceButtons)
                    {
                        ValidadeClickCall(button, args);
                    }
                    break;
            }
        }

        public void ValidadeClickCall(Button button, ClickInputEventArgs args)
        {
            if (button.Position.Contains(args.ClickPositionX, args.ClickPositionY) && button.Position.Contains(args.ReleasePositionX, args.ReleasePositionY))
                button.Click();
        }
    }
}



namespace CardGame.Interface
{
    public class MainMenu
    {
        public Button ButtonTest1;
        public Button ButtonTest2;
        public Button ButtonTest3;

        public int TestCounter1 = 0;
        public int TestCounter2 = 0;
        public int TestCounter3 = 0;

        public List<Button> InterfaceButtons = new List<Button>();

        public MainMenu()
        {
            ButtonTest1 = new Button(new Rectangle(100, 100, 64, 64), ScreenID.MainMenu, Media.debug_Box, "Teste1!");
            ButtonTest2 = new Button(new Rectangle(200, 100, 64, 64), ScreenID.MainMenu, Media.debug_Box, "Teste2!");
            ButtonTest3 = new Button(new Rectangle(300, 100, 64, 64), ScreenID.MainMenu, Media.debug_Box, "Teste3!");
            ButtonTest1.ClickEvent += ActionButtonTest1;
            ButtonTest2.ClickEvent += ActionButtonTest2;
            ButtonTest3.ClickEvent += ActionButtonTest3;

            InterfaceButtons.Add(ButtonTest1);
            InterfaceButtons.Add(ButtonTest2);
            InterfaceButtons.Add(ButtonTest3);
        }

        public void Update(Viewport viewport, Input input, GameTime gameTime)
        {
           foreach (Button button in InterfaceButtons)
            {
                button.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            foreach (Button button in InterfaceButtons)
            {
                button.Draw(spriteBatch, viewport);
            }

            spriteBatch.DrawString(Media.font_Monkey24, TestCounter1.ToString(), new Vector2(100, 70), Color.White);
            spriteBatch.DrawString(Media.font_Monkey24, TestCounter2.ToString(), new Vector2(200, 70), Color.White);
            spriteBatch.DrawString(Media.font_Monkey24, TestCounter3.ToString(), new Vector2(300, 70), Color.White);
        }

        public void ActionButtonTest1(object sender, EventArgs e)
        {
            TestCounter1++;
        }

        public void ActionButtonTest2(object sender, EventArgs e)
        {
            TestCounter2++;
        }

        public void ActionButtonTest3(object sender, EventArgs e)
        {
            TestCounter3++;
        }
    }

    public class Host
    {
        public void Update(Viewport viewport, Input input, GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {

        }
    }
}



namespace CardGame.Control
{
    /// <summary>
    /// Interactive buttons 
    /// </summary>
    public class Button
    {
        public bool Enabled = true;
        public byte ScreenID;
        public string Text;
        public Rectangle Position;
        public Texture2D BackgroundImage;
        public event EventHandler ClickEvent;

        public Button(Rectangle position, byte screenID, Texture2D backgroundImage, string text = "")
        {
            ScreenID = screenID;
            Position = position;
            BackgroundImage = backgroundImage;
            Text = text;
        }

        public void Click()
        {
            ClickEvent.Invoke(this, EventArgs.Empty);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Viewport viewport)
        {
            spriteBatch.Draw(Media.debug_Box, new Vector2(Position.X, Position.Y), Color.White);
            if (Text != "")
                spriteBatch.DrawString(Media.font_Monkey12, Text, new Vector2(Position.X + 10, Position.Y + 10), Color.White);
        }
    }

    //public class Textbox
    //{
    //    public Rectangle Position;
    //    public string Text;
    //    public Texture2D BackgroundImage;
    //    //public Button TextButton;

    //    /// <summary>
    //    /// Defines horizontal centering, 0: Left, 1: Center, 2: Right.
    //    /// </summary>
    //    public byte HorizontalCentering = 0;

    //    /// <summary>
    //    /// Defines vertical centering, 0: Top, 1: Center, 2: Bottom.
    //    /// </summary>
    //    public byte VerticalCentering = 0;

    //    Textbox(int positionX, int positionY, string text, byte horizontalCentering, byte verticalCentering)
    //    {
    //        Position = new Rectangle(positionX, positionY, (int)Media.font_Monkey32.MeasureString(text).X, (int)Media.font_Monkey32.MeasureString(text).Y);


    //    }
    //}
}
