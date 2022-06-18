using System.Drawing;
using System.Windows.Forms;

namespace pragma
{
    class decorator
    {
        public void decorate(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.ControlBox = true;
            f.MinimizeBox = false;
            f.MaximizeBox = false;
            f.BackColor = Color.White;
        }
    }
}
