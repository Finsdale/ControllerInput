using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInput
{
  public class InputButton
  {
    public bool Pressed { get; set; }
    public bool Held { get; set; }
    public bool Released { get; set; }

    public InputButton()
    {
      Pressed = false;
      Held = false;
      Released = false;
    }

    public override string ToString()
    {
      return (Pressed || Held) ? "true" : "false";
    }
  }

  static public class NewInputButton
  {

  } 
}
