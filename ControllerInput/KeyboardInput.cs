using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInput
{
  public class KeyboardInput
  {
    KeyboardState KBS;
    KeyboardState OKBS;
    public void UpdateState()
    {
      OKBS = KBS;
      KBS = Keyboard.GetState();
    }

    public bool IsButtonPressed(Keys key)
    {
      return KBS.IsKeyDown(key) && OKBS.IsKeyUp(key);
    }

    public bool IsButtonReleased(Keys key)
    {
      return KBS.IsKeyUp(key) && OKBS.IsKeyDown(key);
    }

    public bool IsButtonHeld(Keys key)
    {
      return KBS.IsKeyDown(key) && OKBS.IsKeyDown(key);
    }
  }
}
