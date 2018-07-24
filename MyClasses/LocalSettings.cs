using System;
using System.Collections.Generic;

namespace PlaylistParser.MyClasses
{
    [Serializable]
    public class LocalSettings
    {
        //Свойства для Московского плейлиста
        public string MskPlaylistPath;
        //public string MskBeginHourString;
        //public string MskTimeMarker;
        //public string MskSongBeginString;

        public string MskHourStringPattern;
        public string MskHourTimePattern;
        public string MskSongStringPattern;
        public string MskSongZcodePattern;
        public string MskArtistPattern;
        public string MskTitlePattern;

        //Свойства для Молдавского плейлиста
        public string MdHourBeginString;
        public string MdRusPlaylistPath;
        public string MdRumPlaylistPath;

        //Alias Music
        public string AliasPath;
        public string AliasName;
        public string AliasPathPart;

        //Пресеты времени
        public List<TimePreset> TimePresetCollection;
        public int ActivePresetIndex;

        //Пресет для PlaylistUnite
        public List<PlaylistTemplateItem> UnitePlaylistTemplate;

        //Состояние Чек-боксов
        public List<CheckBoxItem> CheckBoxesValues; 
        
        //--------------------------------------------------------------------------------------------
        //Constructor
        public LocalSettings()
        {
            MskPlaylistPath = "";
            MskHourStringPattern = "";
            MskHourTimePattern = "";
            MskSongStringPattern = "";
            MskSongZcodePattern = "";
            MskArtistPattern = "";
            MskTitlePattern = "";
            
            MdHourBeginString = "";
            MdRusPlaylistPath = "";
            MdRumPlaylistPath = "";

            AliasName = "";
            AliasPath = "";
            AliasPathPart = "";
            
            TimePresetCollection = new List<TimePreset>();
            ActivePresetIndex = -1;

            UnitePlaylistTemplate = new List<PlaylistTemplateItem>();
            CheckBoxesValues = new List<CheckBoxItem>();

        }




    }
}
