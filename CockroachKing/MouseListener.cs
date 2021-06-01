using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CockroachKing
{
    class MouseListener
    {
        private MouseState lastMouseState;
        private MouseState currentMouseState;

        public MouseListener()
        {
            currentMouseState = Mouse.GetState();
            lastMouseState = currentMouseState;
        }

        public void Update()
        {
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool LeftClick()
        {
            return lastMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released;
        }
        public bool RightClick()
        {
            return lastMouseState.RightButton == ButtonState.Pressed && currentMouseState.RightButton == ButtonState.Released;
        }
        public bool LeftPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed;
        }
        public bool RightPressed()
        {
            return currentMouseState.RightButton == ButtonState.Pressed;
        }
        public Point MousePosition()
        {
            return currentMouseState.Position;
        }
        public int WheelValue()
        {
            return currentMouseState.ScrollWheelValue;
        }
    }
}
