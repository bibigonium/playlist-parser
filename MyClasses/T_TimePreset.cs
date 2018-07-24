using System;
using System.Collections;
using System.Collections.Generic;

namespace PlaylistParser.MyClasses
{
    [Serializable]
    public class TimePreset
    {

        //public properities

        public ArrayList Preset;

        public string PresetName { get; set; }
        public string PresetDescription { get; set; }

        //-------------------------------------------------------------
        //Constructors
        
        public TimePreset()
        {
            Preset = new ArrayList();
            PresetName = "NewPreset";
            PresetDescription = "Standart Preset";
        }

        public TimePreset(string name)
        {
            
            Preset = new ArrayList();
            PresetName = name;
        }

        public TimePreset(string name, int from, int to)
        {

            Preset = new ArrayList();
            PresetName = name;
            if ((from < 0) || (from > 23) || (to > 23) || (to < 0) || (from >= to)) return;
            for (var i = @from; i <= to; i++)
            {
                Preset.Add(i);
            }
        }

        public TimePreset(string name, IEnumerable<int> hours)
        {

            Preset = new ArrayList();
            PresetName = name;
            foreach(var i in hours)
            {
                Preset.Add(i);
            }
        }
            
        
        //-------------------------------------------------------------------------------
        //Methods

        public void Add(int item)
        {
            if((item<24) && (item >= 0))
            {
                Preset.Add(item);
            }
        }


        public string GetStringHours()
        {
            string result = "";
            foreach (var i in Preset)
            {
                result += i + ", ";

            }
            return result;

        }
    }
}
