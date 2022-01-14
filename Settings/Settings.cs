using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST_Busline.Settings
{
    // SettingsRoot myDeserializedClass = JsonConvert.DeserializeObject<SettingsRoot>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Hotkeys
    {
        public int nextstop { get; set; }
        public int previousstop { get; set; }
        public int resetline { get; set; }
        public int switchline { get; set; }
        public int switchmode { get; set; }
    }

    public class Style
    {
        public int led_on_color { get; set; }
        public int led_off_color { get; set; }        
        public float led_size_coefficient { get; set; }
    }

    public class Settings
    {
        public Hotkeys hotkeys { get; set; }
        public Style style { get; set; }
    }

    public class Stop
    {
        public string name { get; set; }
        public List<int> leavetimes_hourly { get; set; }
    }

    public class Line
    {
        public string name { get; set; }
        public List<Stop> stops { get; set; }
    }

    public class Mode
    {
        public string name { get; set; }
        public List<Line> lines { get; set; }
    }

    public class SettingsRoot
    {
        public Settings settings { get; set; }
        public List<Mode> modes { get; set; }
    }


}
