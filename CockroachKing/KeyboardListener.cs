using Microsoft.Xna.Framework.Input;

namespace CockroachKing
{
    class KeyboardListener
    {
        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;
        public string input { get; private set; }


        public KeyboardListener()
        {
            currentKeyboardState = Keyboard.GetState();
            lastKeyboardState = currentKeyboardState;
        }

        public void Update()
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            if (lastKeyboardState.GetPressedKeys().Length > 0)
            {
                UpdateInput();
            }
        }

        private void UpdateInput()
        {
            Keys key = lastKeyboardState.GetPressedKeys()[0];
            if (lastKeyboardState.GetPressedKeys().Length > 1 && (key == Keys.LeftShift || key == Keys.RightShift))
                key = lastKeyboardState.GetPressedKeys()[1];
            string inputKey = "";

            if (KeyTyped(key) && !(KeyPressed(Keys.RightShift) || KeyPressed(Keys.LeftShift)))
            {
                inputKey = key.ToString();
                if ((inputKey.Length == 2 && inputKey[0] == 'D') || (inputKey.Length == 7 && inputKey[0] == 'N'))
                    inputKey = inputKey[inputKey.Length - 1].ToString();
                inputKey = inputKey.ToLower();
            }
            if ((KeyPressed(Keys.RightShift) || KeyPressed(Keys.LeftShift)) && KeyTyped(key))
            {
                inputKey = key.ToString();
                if ((inputKey.Length == 2 && inputKey[0] == 'D') || (inputKey.Length == 7 && inputKey[0] == 'N'))
                    inputKey = inputKey[inputKey.Length - 1].ToString();
            }
            if (inputKey.Length == 1)
                input = input + inputKey;
            else if (key == Keys.Space && KeyTyped(key))
                input = input + " ";
            else if (key == Keys.OemComma && KeyTyped(key))
                input = input + ",";
            else if (key == Keys.OemPeriod && KeyTyped(key) && !(KeyPressed(Keys.LeftShift) || KeyPressed(Keys.RightShift)))
                input = input + ".";
            else if ((key == Keys.OemMinus || key == Keys.Subtract) && KeyTyped(key) && !(KeyPressed(Keys.LeftShift) || KeyPressed(Keys.RightShift)))
                input = input + "-";
            else if ((key == Keys.OemMinus && KeyTyped(key)) && (KeyPressed(Keys.LeftShift) || KeyPressed(Keys.RightShift)))
                input = input + "_";
            else if ((key == Keys.OemPeriod && KeyTyped(key)) && (KeyPressed(Keys.LeftShift) || KeyPressed(Keys.RightShift)))
                input = input + ":";
            else if (key == Keys.Back && KeyTyped(key))
                input = truncate(input, input.Length - 1);

        }

        public void ClearInput()
        {
            input = string.Empty;
        }

        private string truncate(string s, int x)
        {
            string newString = "";
            for (int i = 0; i < x; i++)
            {
                newString = newString + s[i].ToString();
            }
            return newString;
        }

        public bool KeyTyped(Keys key)
        {
            return lastKeyboardState.IsKeyDown(key) && currentKeyboardState.IsKeyUp(key);
        }

        public bool KeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }
    }
}
