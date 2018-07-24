using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PlaylistParser.MyClasses
{
    public class SettingManager
    {
        private XmlSerializer _settingsSerializer;
        private FileStream _settingsFile;
        public string SettingsFilename;
        public LocalSettings Settings;

        public SettingManager()
        {
            Settings = new LocalSettings();
            try
            {
                //_settingsSerializer = new XmlSerializer(typeof(LocalSettings),types);

                _settingsSerializer = new XmlSerializer(typeof(LocalSettings));

            }
            catch (Exception)
            {
                
                throw;
            }
            SettingsFilename = Environment.CurrentDirectory + "\\Data\\Settings.xml";

            if(File.Exists(SettingsFilename))
            {
                _settingsFile = new FileStream(SettingsFilename,FileMode.Open);
            }
            else
            {
                _settingsFile = new FileStream(SettingsFilename, FileMode.Create);

            }


            
        }

        public bool Read()
        {
            if (_settingsFile.CanRead)
            {
                try
                {
                    Settings = (LocalSettings)_settingsSerializer.Deserialize(_settingsFile);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private bool Write()
        {
            
            foreach (TimePreset item in Settings.TimePresetCollection)
            {
                item.Preset.Sort();
            }

            if(_settingsFile.CanWrite)
            {
                try
                {
                    _settingsSerializer.Serialize(_settingsFile, Settings);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public void RemovePreset (int index)
        {
            if (index < Settings.TimePresetCollection.Count)
            {
                Settings.TimePresetCollection.RemoveAt(index);
                UpdateSettings();
            }
            
        }

        public void AddPreset(TimePreset newPreset,int index)
        {
            if (index == -1)
            {
                Settings.TimePresetCollection.Add(newPreset);
            }
            else if (index >=0 && index < Settings.TimePresetCollection.Count)
            {
                Settings.TimePresetCollection[index] = newPreset;
            }
            
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            _settingsFile.SetLength(0);
            _settingsFile.Flush();
            if (!Write())
            {
                Program.Parser.ErrorMessage("Не могу записать установки в файл конфигурации. Ошибка записи!");
                return;
            }
            Program.Parser.PopulizeSettings();
        }

        public void LoadDefaults()
        {

            //Default Init
            Settings.MskPlaylistPath = "\\\\Onair\\Play-List";

            //______Old_Patterns_____________________________________________________________________________________________________________________________

            //Settings.MskHourStringPattern = "\\*{5,}\\s-\\s\\*{5,}"; //****** - ******
            //Settings.MskHourTimePattern = "^\\d{2}(?=(:\\d{2}){2})";//match ' 03:00:00 ' returns '03'
            //Settings.MskSongStringPattern = "(?<=[0-9,:,\\s])Z[A-Z,\\d]{3}-\\d{2}(?=\\.wav)";// match любые цифры и двоеточия до, Z+трибольшие буквы или цифры + тире + 2 цифры, .wav после returns Z + трибольшие буквы или цифры + тире + 2 цифры 
            //Settings.MskSongZcodePattern = "Z[A-Z,\\d]{3}-\\d{2}(?=\\.)";
            //Settings.MskArtistPattern = "(?<=Z[A-Z,\\d]{3}-\\d{2}\\.wav\\s).*(?=\\t)";
            //Settings.MskTitlePattern = "(?<=Z[A-Z,\\d]{3}-\\d{2}\\.wav\\s.*\\t).*";
            //_______________________________________________________________________________________________________________________________________________

            Settings.MskHourStringPattern = "RR\\s+\\d+:\\d+"; //RR   hh:mm 
            Settings.MskHourTimePattern = "(?<=RR\\s+)\\d{1,2}(?=:\\d{2}\\s+)";//match 'RR   03:00 ' returns '03'
            Settings.MskSongStringPattern = "Z[A-Z,\\d]{3}-\\d{2}(?=\\s)";// match Z+трибольшие буквы или цифры + тире + 2 цифры и пробел после, лreturns Z + трибольшие буквы или цифры + тире + 2 цифры 
            Settings.MskSongZcodePattern = "Z[A-Z,\\d]{3}-\\d{2}(?=\\s)";
            Settings.MskArtistPattern = "(?<=Z[A-Z,\\d]{3}-\\d{2}.{11}).{18}";//ищет Z-код + 11 любых символов, returns 18 символов  - это и есть имя исполнителя
            Settings.MskTitlePattern = "(?<=Z[A-Z,\\d]{3}-\\d{2}.{29}).{18}";//То-же самое, только следующие 18 символов - название песни

            //Свойства для Молдавского плейлиста
            Settings.MdHourBeginString = "|";
            Settings.MdRusPlaylistPath = "\\\\Onair\\MUZZ (D)\\Radio\\!Playlist\\Music\\";
            Settings.MdRumPlaylistPath = "\\\\Onair\\MUZZ (D)\\Radio\\!Playlist\\Music\\";


            //Alias Music
            Settings.AliasName = "Музыка*";
            //AliasPathPart = "\\D:\\Video&Torrents\\";
            //AliasPath = "\\D:\\Video&Torrents\\Дискография - Ляпис Трубецкой (1992 - 2009)\\";
            Settings.AliasPath = "\\\\Onair\\MUZZ (D)\\Radio\\!Playlist\\";
            Settings.AliasPathPart = "\\\\Onair\\MUZZ (D)\\Radio\\";

            //Пресеты времени
            //TimePresetCollection = new List<T_TimePreset>;
            Settings.TimePresetCollection.Add(new TimePreset("Work Days from 11 to 19", new int[] { 11, 12, 14, 15, 16, 17, 18, 19 }));
            Settings.TimePresetCollection.Add(new TimePreset("Saturday from 07 to 20", new int[] { 7, 8, 9, 10, 11, 12, 14, 15, 16, 17, 20 }));
            Settings.TimePresetCollection.Add(new TimePreset("Saturday from 07 to 20", new int[] { 7, 8, 9, 10, 14, 15, 16, 17, 20 }));

            Settings.ActivePresetIndex = 0;

            Settings.CheckBoxesValues.Add(new CheckBoxItem("DontCreatePLcheckBox", false));
            Settings.CheckBoxesValues.Add(new CheckBoxItem("CorrectTimeCheckBox", true));
            Settings.CheckBoxesValues.Add(new CheckBoxItem("DisableWarningsCheckBox", false));
            Settings.CheckBoxesValues.Add(new CheckBoxItem("RemoveSourcePlaylistafterUnite", false));


        }




        ~SettingManager()
        {
            
            //_settingsFile.Flush();
            _settingsFile.Close();
        }
    }
}
