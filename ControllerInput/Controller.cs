using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInput
{
  internal class Controller
  {
    GamePadState OCS { get; set; }
    GamePadState CS { get; set; }
    PlayerIndex PlayerNum { get; set; }
    public Controller(PlayerIndex playerIndex = PlayerIndex.One)
    {
      PlayerNum = playerIndex;
    }

    public void UpdateState()
    {
      OCS = CS;
      CS = GamePad.GetState(PlayerNum);
    }

    public bool IsButtonPressed(Buttons button)
    {
      return OCS.IsButtonUp(button) && CS.IsButtonDown(button);
    }

    public bool IsButtonReleased(Buttons button)
    {
      return OCS.IsButtonDown(button) && CS.IsButtonUp(button);
    }

    public bool IsButtonHeld(Buttons button)
    {
      return OCS.IsButtonDown(button) && CS.IsButtonDown(button);
    }

    public Direction GetDirection(ThumbStick side)
    {
      Vector2 thumbStick = new();
      if (side == ThumbStick.Left) {
        thumbStick = CS.ThumbSticks.Left;
      }
      else if (side == ThumbStick.Right) {
        thumbStick = CS.ThumbSticks.Right;
      }
      Direction direction = Direction.None;
      double xValue = thumbStick.X;
      double yValue = thumbStick.Y;
      if (xValue > 0.25) {
        if (yValue > 0.25)
          direction = Direction.UpRight;
        else if (yValue < -0.25)
          direction = Direction.DownRight;
        else
          direction = Direction.Right;
      }
      else if (xValue < -0.25) {
        if (yValue > 0.25)
          direction = Direction.UpLeft;
        else if (yValue < -0.25)
          direction = Direction.DownLeft;
        else
          direction = Direction.Left;
      }
      else {
        if (yValue > 0.25)
          direction = Direction.Up;
        else if (yValue < -0.25)
          direction = Direction.Down;
      }
      return direction;

    }
  }
}
