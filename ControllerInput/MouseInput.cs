using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInput
{
  internal class MouseInput
  {
    MouseState OMS { get; set; }
    MouseState MS { get; set; }
    
    public void UpdateState()
    {
      OMS = MS;
      MS = Mouse.GetState();
    }

    public bool IsButtonPressed(MouseButtons button)
    {
      Type theType = MS.GetType();
      MethodInfo theMethod = theType.GetMethod(button.ToString());
      bool result = (bool)theMethod.Invoke(this, null);
      return OMS.IsButtonUp(button) && MS.IsButtonDown(button);
    }

    public bool IsButtonReleased(Buttons button)
    {
      return OCS.IsButtonDown(button) && CS.IsButtonUp(button);
    }

    public bool IsButtonHeld(Buttons button)
    {
      return OCS.IsButtonDown(button) && CS.IsButtonDown(button);
    }

  }
}
