using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace CardGame
{
    public class Input
    {
        public GameWindow GameWindowInstance;
        public MouseState MouseCurrentState;
        public KeyboardState KeyboardCurrentState;

        public Point ClickPressedPosition = Point.Zero;
        public Point ClickReleasedPosition = Point.Zero;

        private bool ClickLeftIsPressed = false;
        private bool ClickLeftWasPressed = false;

        private bool ClickRightIsPressed = false;
        private bool ClickRightWasPressed = false;


        public Input(GameWindow gameWindow)
        {
            GameWindowInstance = gameWindow;
            GameWindowInstance.TextInput += TextInputHandler;
        }

        /// <summary>
        /// Gets input states from Mouse and Keyboard
        /// </summary>
        public void Update()
        {
            MouseCurrentState = Mouse.GetState();
            KeyboardCurrentState = Keyboard.GetState();

            // Logic to control clicks
            ClickLeftIsPressed = false;
            ClickRightIsPressed = false;

            ClickLeftIsPressed = MouseCurrentState.LeftButton == ButtonState.Pressed;
            if (ClickLeftIsPressed && !ClickLeftWasPressed)
                MouseClick(0);
            else if (!ClickLeftIsPressed && ClickLeftWasPressed)
                MouseClick(1);

            ClickRightIsPressed = MouseCurrentState.RightButton == ButtonState.Pressed;
            if (ClickRightIsPressed && !ClickRightWasPressed)
                MouseClick(2);
            else if (!ClickRightIsPressed && ClickRightWasPressed)
                MouseClick(3);

            ClickLeftWasPressed = ClickLeftIsPressed;
            ClickRightWasPressed = ClickRightIsPressed;
        }

        public event EventHandler<ClickInputEventArgs> OnClickLeft;
        public event EventHandler<ClickInputEventArgs> OnClickReleaseLeft;
        public event EventHandler<ClickInputEventArgs> OnClickRight;
        public event EventHandler<ClickInputEventArgs> OnClickReleaseRight;

        public void MouseClick(byte clickState)
        {
            
            switch (clickState)
            {
                case 0:
                    ClickPressedPosition = MouseCurrentState.Position;
                    OnClickLeft?.Invoke(this, new ClickInputEventArgs
                    {
                        ReleasePositionX = ClickReleasedPosition.X,
                        ReleasePositionY = ClickReleasedPosition.Y,
                        ClickPositionX = ClickPressedPosition.X,
                        ClickPositionY = ClickPressedPosition.Y,
                    });
                    break;

                case 1:
                    ClickReleasedPosition = MouseCurrentState.Position;
                    OnClickReleaseLeft?.Invoke(this, new ClickInputEventArgs
                    {
                        ReleasePositionX = ClickReleasedPosition.X,
                        ReleasePositionY = ClickReleasedPosition.Y,
                        ClickPositionX = ClickPressedPosition.X,
                        ClickPositionY = ClickPressedPosition.Y,
                    });
                    break;

                case 2:
                    ClickPressedPosition = MouseCurrentState.Position;
                    OnClickRight?.Invoke(this, new ClickInputEventArgs
                    {
                        ReleasePositionX = ClickReleasedPosition.X,
                        ReleasePositionY = ClickReleasedPosition.Y,
                        ClickPositionX = ClickPressedPosition.X,
                        ClickPositionY = ClickPressedPosition.Y,
                    });
                    break;

                case 3:
                    ClickReleasedPosition = MouseCurrentState.Position;
                    OnClickReleaseRight?.Invoke(this, new ClickInputEventArgs
                    {
                        ReleasePositionX = ClickReleasedPosition.X,
                        ReleasePositionY = ClickReleasedPosition.Y,
                        ClickPositionX = ClickPressedPosition.X,
                        ClickPositionY = ClickPressedPosition.Y,
                    });
                    break;
            }
        }

        public string TextOutput = "";
        public bool TextGetInput = false;

        /// <summary>
        /// Controls keyboard presses for text input
        /// </summary>
        void TextInputHandler(object sender, TextInputEventArgs args)
        {
            if (TextGetInput)
            {
                if (args.Key == Keys.Back && TextOutput.Length > 0)
                {
                    TextOutput = TextOutput.Remove(TextOutput.Length - 1);
                    return;
                }
                if (!Media.font_Monkey12.Characters.Contains(args.Character))
                {
                    return;
                }
                TextOutput += args.Character;
            }
        }
    }

    public struct ClickInputEventArgs
    {
        public float ClickPositionX;
        public float ClickPositionY;
        public float ReleasePositionX;
        public float ReleasePositionY;

        ClickInputEventArgs(float positionX, float positionY, float releasePositionX, float releasePositionY)
        {
            ClickPositionX = positionX;
            ClickPositionY = positionY;
            ReleasePositionX = releasePositionX;
            ReleasePositionY = releasePositionY;
        }
    }
}
