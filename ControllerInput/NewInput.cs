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
    public KeyboardInput? KBInput;
    public MouseInput? MInput;
    bool KbActive, MActive;

    public NewInput(int numOfControllers, bool kbUsed = false, bool mouseUsed = false)
    {
      Controllers = new();
      for(int i = 1; i <= numOfControllers;  i++) {
        Controllers.Add(new Controller((PlayerIndex)i - 1));
      }
      if(kbUsed) {
        KbActive = true;
        KBInput = new();
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
        KBInput?.UpdateState();
      }
      if(MActive) {
        MInput?.UpdateState();
      }
    }

    public void SetMouseScale(Vector2 backbuffer, Vector2 renderTarget)
    {
      MInput?.SetScale(backbuffer, renderTarget);
    }
  }
}
