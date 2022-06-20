using System.Drawing;
using System.Windows.Forms;

namespace pragma.sqlite
{
    public class TestColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Red; }
        }

        public override Color MenuBorder  //Change color according your Need
        {
            get { return Color.Green; }
        }

    }
}
