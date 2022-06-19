using pragma.sqlite;
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

        internal void decorate(MenuStrip menuStrip1)
        {
            // https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-set-the-toolstrip-renderer-at-run-time/
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
        }
    }
}
