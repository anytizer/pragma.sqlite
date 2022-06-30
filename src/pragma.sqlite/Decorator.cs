using System.Drawing;
using System.Windows.Forms;

namespace pragma.sqlite
{
    class Decorator
    {
        public void Decorate(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.ControlBox = true;
            f.MinimizeBox = false;
            f.MaximizeBox = false;
            f.BackColor = Color.White;
        }

        internal void Decorate(ComboBox comboBox1)
        {
            comboBox1.Items.Clear();
            comboBox1.MaxDropDownItems = 10;
            comboBox1.BackColor = Color.Cornsilk;
        }

        internal void Decorate(MenuStrip menuStrip1)
        {
        }
    }
}
