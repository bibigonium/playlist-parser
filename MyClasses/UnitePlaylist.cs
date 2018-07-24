using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PlaylistParser.MyClasses;
using System.Collections.Generic;


namespace PlaylistParser
{
    //CREATE TABLE jingles (id int not null , name nvarchar(20), path nvarchar(100))

    public partial class ParserMainForm
    {

        private void FillUnPlSourceListBox()
        {
            var rusSongItem = new PlaylistTemplateItem("Русская Песня", 0);
            var moldItem = new PlaylistTemplateItem("Молдавская Песня", 1);
            var jingle = new PlaylistTemplateItem("Молдавский Джингл", 2);

            UnPlSourceListBox.SelectionMode = SelectionMode.One;
            UnPlSourceListBox.DisplayMember = "Title";


            UnPlSourceListBox.Items.Add(rusSongItem);
            UnPlSourceListBox.Items.Add(moldItem);
            UnPlSourceListBox.Items.Add(jingle);

            //UnPlSourceListBox.Items.Insert(0, "Russian Song");
            //UnPlSourceListBox.Items.Insert(1, "Mold Song");
            //UnPlSourceListBox.Items.Insert(2, "Jingle");
 
 
        
        }

        private void FillUnPlTemplateListBox()
        {
            UnPlTemplateListBox.SelectionMode = SelectionMode.One;
            UnPlTemplateListBox.DisplayMember = "Title";


            if (_currentSettings.Settings.UnitePlaylistTemplate != null)
            {
                foreach (PlaylistTemplateItem item in _currentSettings.Settings.UnitePlaylistTemplate)
                {
                    UnPlTemplateListBox.Items.Add(item);
                }
            }
        }

//_________________________________________________________________________________________________________________________________________________________


        private void AddItemToUnitePlTemplateBtn_Click(object sender, EventArgs e)
            {
                UnPlTemplateListBox.BeginUpdate();
                UnPlTemplateListBox.Items.Add(UnPlSourceListBox.SelectedItem);
                UnPlTemplateListBox.EndUpdate();
                UnPlTemplateListBox.Refresh();


            }


//_________________________________________________________________________________________________________________________________________________________


        private void RemItemToUnitePlTemplateBtn_Click(object sender, EventArgs e)
            {
                UnPlTemplateListBox.BeginUpdate();

                UnPlTemplateListBox.Items.RemoveAt(UnPlTemplateListBox.SelectedIndex);
                if (UnPlTemplateListBox.Items.Count != 0)
                {
                    UnPlTemplateListBox.SelectedIndex = 0;
                }
                else
                {
                    RemItemToUnitePlTemplateBtn.Enabled = false;
                }
                UnPlTemplateListBox.EndUpdate();
                UnPlTemplateListBox.Refresh();
                

            }



//_________________________________________________________________________________________________________________________________________________________



        private void SaveUnitePlTemplateBtn_Click(object sender, EventArgs e)
            {
                if (UnPlTemplateListBox.Items.Count > 0)
                {
                    _currentSettings.Settings.UnitePlaylistTemplate.Clear();
                    foreach (var item in UnPlTemplateListBox.Items)
                    {
                        _currentSettings.Settings.UnitePlaylistTemplate.Add((PlaylistTemplateItem)item);
                    }
                    _currentSettings.UpdateSettings();
                }

            }

//_________________________________________________________________________________________________________________________________________________________

        private void UnPlSourceListBox_SelectedIndexChanged(object sender, EventArgs e)
            {

                if (UnPlSourceListBox.SelectedIndex != -1)
                {

                    AddItemToUnitePlTemplateBtn.Enabled = true;
                }


            }


//_________________________________________________________________________________________________________________________________________________________


        private void UnPlTemplateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnPlTemplateListBox.SelectedIndex != -1)
            {
                RemItemToUnitePlTemplateBtn.Enabled = true;

            }


        }

//_________________________________________________________________________________________________________________________________________________________

        public bool UnPlValidatePlaylists()
        {
            bool moldPlOk = File.Exists(UnPlMoldTextBox.Text);
            bool rusPlOk = File.Exists(UnPlRusTextBox.Text);

                       
            if(rusPlOk)
            {
                UnPlRusOkLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                UnPlRusOkLabel.ForeColor = System.Drawing.Color.Red;
            }

            if (moldPlOk)
            {
                UnPlMoldOkLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                UnPlMoldOkLabel.ForeColor = System.Drawing.Color.Red;
            }

            UnPlMoldOkLabel.Visible = true;
            UnPlRusOkLabel.Visible = true;



            if (moldPlOk && rusPlOk)
            {
                return true;
            }
            return false;
        }


//_________________________________________________________________________________________________________________________________________________________


        private void UnPlDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var dateStr = GetFormattedStringFromDate(UnPlDateTimePicker.Value);
            UnPlRusTextBox.Text = _currentSettings.Settings.MdRusPlaylistPath + dateStr + "_rus.txt";
            UnPlMoldTextBox.Text = _currentSettings.Settings.MdRumPlaylistPath + dateStr + ".txt";
            UnPlFullTextBox.Text = _currentSettings.Settings.MdRusPlaylistPath + dateStr + "_Full.txt"; 
            UnPlValidatePlaylists();

        }


//_________________________________________________________________________________________________________________________________________________________


        private void UnPlChoosePl_Click(object sender, EventArgs e)
        {
            TextBox target = null;
            if (((Button)sender).Name == "UnPlChoosePlRus")
            {
                openFileDialog1.InitialDirectory = _currentSettings.Settings.MdRusPlaylistPath;
                target = UnPlRusTextBox;
            }
            else if (((Button)sender).Name == "UnPlChoosePlMold")
            {
                openFileDialog1.InitialDirectory = _currentSettings.Settings.MdRumPlaylistPath;
                target = UnPlMoldTextBox;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                target.Text = openFileDialog1.FileName;
                UnPlValidatePlaylists();
            }




        }

//_________________________________________________________________________________________________________________________________________________________


        private void UnitePlaylist()
        {
            List<Clock> rusPlaylist;
            List<Clock> moldPlaylist;
            var fullPlaylist = new List<Clock>();

            Clock currentRus;
            Clock currentMold;
            Clock currentJingle;
            Clock currentFull;

            string temp;

            if (UnPlValidatePlaylists())
            {
                rusPlaylist = ReadFile(UnPlRusTextBox.Text);
                moldPlaylist = ReadFile(UnPlMoldTextBox.Text);

                currentFull = null;


                for (int time = 0; time < 24; time++  )
                {

                    currentRus = GetClock(time, rusPlaylist);
                    currentMold = GetClock(time, moldPlaylist);

                    //Если оба часа существуют и их надо совмещать

                    if ((currentRus != null) && (currentMold != null))
                    {

                        currentFull = new Clock(currentRus.StrTime);
                        //____________________________
                        //разбираемся с Джинглами. Находим в их в молд клоке и перемещаем во временный currentJingle
                        
                        currentJingle = new Clock(currentRus.StrTime);


                        do
                        {
                            temp = currentMold.GetString();
                            if (temp.Contains("Джинглы*PoliDisc"))
                            {
                                currentJingle.AddString(temp);
                                currentMold.RemoveCurrentString();
                            }
                        } while (!currentMold.Empty);

                        currentMold.Reset();
                        currentJingle.Reset();
/*
                        temp = "";
*/



                        //____________________________


                        //_________________________________________________________________________________________________________________________________________________________
                        bool stop, lastWasJingle = false;
                        int i = 0;

                        do
                        {
                            
                            int j = ((PlaylistTemplateItem)UnPlTemplateListBox.Items[i]).Type;
                            switch (j)
                            {
                                case 0:   //Russian Song
                                    if (!currentRus.Empty)
                                    {
                                        currentFull.AddString(currentRus.GetString());
                                        lastWasJingle = false;
                                    }
                                    break;
                                case 1:   //Mold Song
                                    if (!currentMold.Empty)
                                    {
                                        currentFull.AddString(currentMold.GetString());
                                        lastWasJingle = false;
                                    }
                                    break;
                                case 2:   //Jingle
                                    if (!currentJingle.Empty && !lastWasJingle)
                                    {
                                        currentFull.AddString(currentJingle.GetString());
                                        lastWasJingle = true;
                                    }
                                    break;

                            }



                            stop = currentRus.Empty && currentMold.Empty;


                            if (i < (UnPlTemplateListBox.Items.Count - 1))
                            { i++; }
                            else
                            { i = 0; }

                        } while (!stop);
                        //_________________________________________________________________________________________________________________________________________________________

                        } else 
                        //Если есть русский час и нет молдавского , то копируем русский  в итоговый
                        if ((currentRus != null))
                        {
                            currentFull = currentRus;
                        } else
                            //Если есть молдавский час и нет русского , то копируем молдавский  в итоговый
                            if ((currentMold  != null))
                            {
                                currentFull = currentMold;
                            }


                    if (currentFull != null)
                    {
                        fullPlaylist.Add(currentFull);
                        //currentFull = null;
                        //currentRus = null;
                        //currentMold = null;
                        //currentJingle = null;
                    }


                    currentFull = null;
                    //currentRus = null;
                    //currentMold = null;
                    //currentJingle = null;;
                }

                //Записать плейлист в файл если не нулевой
                if (fullPlaylist.Count != 0)
                {
                    if (WriteFile(fullPlaylist, UnPlFullTextBox.Text))
                    {
                        UnPlInfo.Text = "ОК. Файл общего плейлиста успешно создан. \n" + UnPlFullTextBox.Text;
                        if (RemoveSourcePlaylistafterUnite.Checked)
                        {
                            if (MessageBox.Show("Удалить безвозвратно файл русского плейлиста \n" + UnPlRusTextBox.Text + " ?", "Удаление файла плейлиста", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                File.Delete(UnPlRusTextBox.Text);

                            }
                        }
  
                    }
                    else
                    {
                        UnPlInfo.Text = "ОШИБКА! Не смог записать файл \n" + UnPlFullTextBox.Text;
                    }
                    UnPlInfo.Visible = true;
                }

            }


            

        }


//_________________________________________________________________________________________________________________________________________________________


        public Clock GetClock(int time, List<Clock> list)
        {
            foreach (Clock item in list)
            {
                if (item.Time == time) { return item; }
            }
            return null;
        }

//_________________________________________________________________________________________________________________________________________________________


        public List<Clock> ReadFile(string filename)
        {
            var result = new List<Clock>();
            string currline;
            var currclock = new Clock();
            bool firstClock;


            Encoding enc = Encoding.GetEncoding(1251);


            using (var sr = new StreamReader(filename, enc))
            {
                firstClock = true;
                do
                {
                    currline = sr.ReadLine();

                    if (currline != null)
                    {

                        if (currline.StartsWith("|"))
                        {
                            if (firstClock)
                            {
                                currclock = new Clock();
                                firstClock = false;
                            }
                            else
                            {
                                result.Add(currclock);
                                currclock = new Clock();
                            }
                        }

                        else if (currline.Contains(":00:00"))
                        {
                            if (currclock.Time == 0) { currclock.MakeTimeFromString(currline.Substring(0, 8)); }
                            currclock.AddString(currline);

                        }
                    } else
                    { result.Add(currclock); }
                } while (currline != null);
            }
            return result;

        }

//_________________________________________________________________________________________________________________________________________________________


        public bool WriteFile(List<Clock> playlist, string filename = "")
        {
            Encoding enc = Encoding.GetEncoding(1251);
            
            if (filename == "")
            {
                filename = _currentSettings.Settings.MdRusPlaylistPath + GetFormattedStringFromDate(UnPlDateTimePicker.Value) + "_full.txt";
            }
            
            if(File.Exists(filename))
            {
                if(MessageBox.Show("Файл \n" + filename +"\n уже существует! \n ПЕРЕЗАПИСАТЬ?", "Перезаписать файл?", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filename, false, enc);
                foreach (Clock clock in playlist)
                {
                    sw.WriteLine(_currentSettings.Settings.MdHourBeginString);
                    foreach(string str in clock.Songs)
                    {
                        sw.WriteLine(str);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
            finally 
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
             

        }

    }
}
