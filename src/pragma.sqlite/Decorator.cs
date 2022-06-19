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
            //comboBox1.ForeColor = Color.White;
            //comboBox1.Size = new Size(136, 81);
        }

        internal void Decorate(MenuStrip menuStrip1)
        {
            // https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-set-the-toolstrip-renderer-at-run-time/
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
        }
    }
}
