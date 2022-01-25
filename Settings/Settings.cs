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
        public int nextstop { get; set; } = 57;
        public int previousstop { get; set; } = 56;
        public int resetline { get; set; } = 55;
        public int switchline { get; set; } = 54;
        public int switchmode { get; set; } = 53;
    }

    public class Style
    {
        public int led_on_color { get; set; } = -256;
        public int led_off_color { get; set; } = -12566464;
        public double led_size_coefficient { get; set; } = 0.8;
        public int lines { get; set; } = 17;
        public int rows { get; set; } = 200;
        public int ledtype { get; set; } = 0;
        public int windowposition_x { get; set; } = -1;
        public int windowposition_y { get; set; } = -1;
        public int windowheight { get; set; } = 545;
        public int windowwidth { get; set; } = 1274;      
        public bool logoinverted { get; set; } = false;
    }

    public class Settings
    {
        public int lineabortwindow { get; set; } = 5;

        public bool autosuggeststoponlinechange { get; set; } = false;
        public bool autoforwardlineafterfirst { get; set; } = false;
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
        public bool isInformationOnly { get; set; } = false;
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
