using System;

namespace PlaylistParser.MyClasses
{
    [Serializable]
    public class PlaylistTemplateItem
    {

        public string Title { get; set; }
        public int Type { get; set; }


        public PlaylistTemplateItem()
        {
            Title = "";
            Type = 0;
        }

        public PlaylistTemplateItem(string title, int type)
        {
            Type = type;
            Title = title;
        }


        public override string ToString()
        {
            return Title;
        }
    }
}
