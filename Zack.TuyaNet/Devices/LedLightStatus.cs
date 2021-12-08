using System.Drawing;

namespace Zack.TuyaNet.Devices;
public class LedLightStatus
{
    public bool SwitchLed { get; set; }
    public string WorkMode { get; set; }
    public short Brightness { get; set; }
    public short Temperature { get; set; }
    public HSV Color { get; set; }
}