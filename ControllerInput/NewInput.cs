using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInput
{
  public class NewInput
  {
    public List<Controller> Controllers;
    public KeyboardState KbState;
    public MouseInput? MInput;
    bool KbActive, MActive;

    NewInput(int numOfControllers, bool kbUsed = false, bool mouseUsed = false)
    {
      Controllers = new();
      for(int i = 1; i <= numOfControllers;  i++) {
        Controllers.Add(new Controller((PlayerIndex)i));
      }
      if(kbUsed) {
        KbActive = true;
        KbState = new();
      }
      if(mouseUsed) {
        MActive = true;
        MInput = new();
      }
    }

    public void Update()
    {
      foreach(Controller controller in Controllers) {
        controller.UpdateState();
      }
      if(KbActive) {
        KbState = Keyboard.GetState();
      }
      if(MActive) {
        MInput?.UpdateState();
      }
    }
  }
}
