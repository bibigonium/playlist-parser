using System;
using System.Collections.Generic;

namespace PlaylistParser.MyClasses
{
    public class Clock
    {
        private int _time;
        private string _strTime;
        public List<String> Songs;
        public int CurrentSong;
        public int CountSongs;
        public bool Empty;

        public string StrTime { get => _strTime; set => _strTime = value; }
        public int Time { get => _time; set => _time = value; }

        public Clock (string cl)
        {
            StrTime = cl;
            Time = Convert.ToInt32(StrTime.Substring(0, 2));
            Songs = new List<string>();
            CurrentSong = 0;
            CountSongs = 0;
            Empty = false;
        }

        public Clock()
        {
            StrTime = "";
            Time = 0;
            Songs = new List<string>();
            CurrentSong = 0;
            CountSongs = 0;
            Empty = false;
        }

        public void MakeTimeFromString(string cl)
        {
            StrTime = cl;
            Time = Convert.ToInt32(StrTime.Substring(0, 2));

        }

        public void AddString(string newSong)
        {
            Songs.Add(newSong);
            CountSongs++;

        }

        public void RemoveCurrentString()
        {
            Songs.RemoveAt(CurrentSong - 1);
            CurrentSong--;
        }

        public string GetString()
        {
            if ((CurrentSong >= 0) && (CurrentSong < Songs.Count))
            {
                if ((CurrentSong + 1) == Songs.Count) {Empty = true;} 

                return Songs[CurrentSong++];
            }
            
            return null;
        }


        public void Reset()
        {
            Empty = false;
            CurrentSong = 0;
            CountSongs = Songs.Count;
        }
    }
}
