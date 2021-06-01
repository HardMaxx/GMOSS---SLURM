using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    public class ColorType
    {
        public Color allocated = ColorTranslator.FromHtml("#bc80bd");//8073ac  5e4fa2
        public Color idle = ColorTranslator.FromHtml("#b3de69");
        public Color mixed = ColorTranslator.FromHtml("#ccebc5");

        public Color drained = ColorTranslator.FromHtml("#fdb462");
        public Color reserved = ColorTranslator.FromHtml("#bebada");//
        public Color error_fail = ColorTranslator.FromHtml("#fccde5");
        public Color maint = ColorTranslator.FromHtml("#d9d9d9");
        public Color power_down = ColorTranslator.FromHtml("#fb8072");// roz

        public Color reboot = ColorTranslator.FromHtml("#ffffb3");
        public Color completing = ColorTranslator.FromHtml("#80b1d3");
        public Color power_up = ColorTranslator.FromHtml("#8dd3c7");

    }
}

