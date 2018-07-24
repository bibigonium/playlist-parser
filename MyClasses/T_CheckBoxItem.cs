using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistParser.MyClasses
{
    [Serializable]
    public class CheckBoxItem
    {
        public string Name { get; set; }
        public bool Checked { get; set; }

        public CheckBoxItem()
        {
            Name = "";
            Checked = false;
        }
        
        public CheckBoxItem(string name, bool ischecked)
        {
            this.Name = name;
            this.Checked = ischecked;
        }
    }
}
