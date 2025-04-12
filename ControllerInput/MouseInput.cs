using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ControllerInput
{
  public class MouseInput
  {
    MouseState MS { get; set; }
    MouseState OMS { get; set; }
    Vector2 Scale;

    public void UpdateState()
    {
      OMS = MS;
      MS = Mouse.GetState();
    }

    public Point MousePosition()
    {
      return new Vector2(MS.Position.X/Scale.X, MS.Position.Y / Scale.Y).ToPoint();
    }

    public bool IsButtonPressed(MouseButton button)
    {
      return IsButtonUp(button, OMS) && IsButtonDown(button, MS);
    }

    public bool IsButtonReleased(MouseButton button)
    {
      return IsButtonDown(button, OMS) && IsButtonUp(button, MS);
    }

    public bool IsButtonHeld(MouseButton button)
    {
      return IsButtonDown(button, OMS) && IsButtonDown(button, MS);
    }

    public bool IsButtonDown(MouseButton button)
    {
      return IsButtonDown(button, MS);
    }

    static bool IsButtonUp(MouseButton button, MouseState state)
    {
      bool result = false;
      switch (button) {
        case MouseButton.Left:
          result = state.LeftButton == ButtonState.Released;
          break;
        case MouseButton.Middle:
          result = state.MiddleButton == ButtonState.Released;
          break;
        case MouseButton.Right:
          result = state.RightButton == ButtonState.Released;
          break;
        case MouseButton.XButton1:
          result = state.XButton1 == ButtonState.Released;
          break;
        case MouseButton.XButton2:
          result = state.XButton2 == ButtonState.Released;
          break;
      }
      return result;
    }

    static bool IsButtonDown(MouseButton button, MouseState state)
    {
      bool result = false;
      switch (button) {
        case MouseButton.Left:
          result = state.LeftButton == ButtonState.Pressed;
          break;
        case MouseButton.Middle:
          result = state.MiddleButton == ButtonState.Pressed;
          break;
        case MouseButton.Right:
          result = state.RightButton == ButtonState.Pressed;
          break;
        case MouseButton.XButton1:
          result = state.XButton1 == ButtonState.Pressed;
          break;
        case MouseButton.XButton2:
          result = state.XButton2 == ButtonState.Pressed;
          break;
      }
      return result;
    }

    internal void SetScale(Vector2 backbuffer, Vector2 renderTarget)
    {
      Scale = backbuffer / renderTarget;
    }
  }
}
