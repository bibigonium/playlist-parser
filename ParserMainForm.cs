using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using PlaylistParser.MyClasses;


namespace PlaylistParser
{
    //CREATE TABLE jingles (id int not null , name nvarchar(20), path nvarchar(100))

    public partial class ParserMainForm : Form
    {
        private SettingManager _currentSettings;
        public bool UpdateComboBox = true;

        //public delegate void PopulizeSettings();

        public ParserMainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //проверка соединения с БД
            using (OleDbConnection dbConnection = GetConnection())
                try
                {
                    dbConnection.Open();
                }
                catch (OleDbException)
                {
                    //сообщение об ошибке
                    ErrorMessage("Не могу подключиться к базе данных! Проверить наличие файла Muzz.mdb в папке Data.");
                    goBtn.Enabled = false;
                }

            //Проверка Свойств

            _currentSettings = new SettingManager();
            if (!_currentSettings.Read())
            {
                var result =
                    MessageBox.Show(
                        "Не могу прочитать настройки из файла" + _currentSettings.SettingsFilename +
                        "\tЗагрузить установки по умолчанию?", "Ошибка чтения настроек", MessageBoxButtons.OKCancel);
                switch (result)
                {
                    case DialogResult.OK:
                        _currentSettings.LoadDefaults();
                        _currentSettings.UpdateSettings();
                        break;
                    case DialogResult.Cancel:
                        tabPage3.Show();
                        break;
                }
            }

            PopulizeSettings();


            //устанавливаем формат календаря и формируем имя выходного файла
            pane1DTPicker.Format = DateTimePickerFormat.Custom;
            UnPlDateTimePicker.Format = DateTimePickerFormat.Custom;
            pane1DTPicker.CustomFormat = "yyyy-MM-dd";
            UnPlDateTimePicker.CustomFormat = "yyyy-MM-dd";
            pane1DTPicker.Value = DateTime.Today.AddDays(1);
            UnPlDateTimePicker.Value = DateTime.Today.AddDays(1);
            pane1DTPicker.Text = GetFormattedStringFromDate(pane1DTPicker.Value);
            UnPlDateTimePicker.Text = GetFormattedStringFromDate(UnPlDateTimePicker.Value);
            SetOutputFileName();

            //Установка свойств вкладки объединения плейлистов
            FillUnPlSourceListBox();
            FillUnPlTemplateListBox();
            UnPlRusOkLabel.Visible = false;
            UnPlMoldOkLabel.Visible = false;
            UnPlInfo.Visible = false;

            //openFileDialog1.InitialDirectory = _currentSettings.Settings.MskPlaylistPath;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetOutputFileName();
            //изменяем имя выходного файла с учктом выбранной даты 2008-08-08
        }


        private bool EnableProcess() //проверка наличия выходного файла с запросом перезаписи
        {
            // если !DontCreatePLcheckBox.Checked то запись в файл плейлиста производиться не будет и никчему проверки и подтверждения
            //а функция должна вернуть true для работы впринципе

            if (File.Exists(mdPlylistPathTextBox.Text) && !DontCreatePLcheckBox.Checked)
            {
                DialogResult result =
                    MessageBox.Show("Файл " + mdPlylistPathTextBox.Text + "уже существует. ПЕРЕЗАПИСАТЬ?", "Внимание!",
                        MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return false;
            }

            return true;
        }

        private bool IsIn(int num) //проверяем если пропарсеный час есть в текущей сетке часов
        {
            if (_currentSettings.Settings.TimePresetCollection[_currentSettings.Settings.ActivePresetIndex].Preset
                    .Contains(num) || DontCreatePLcheckBox.Checked)
            {
                return true;
            }

            return false;
        }


        public static OleDbConnection GetConnection() //соединяемся с БД
        {
            OleDbConnection connection = new OleDbConnection
            {
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                                   + Application.StartupPath + "\\Data\\Muzz.mdb"
            };
            //connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Мои документы\\Visual Studio 2008\\Projects\\PlaylistParser\\Data\\Muzz.mdb";

            return connection;
        }

        public void PopulizeSettings()
        {
            /*
			Controls to Bind:
			Main Tab ---------------------------
			mdPlylistPathTextBox +
			moscowPlaylistPathTextBox+
			PresetsComboBox
			PresetDescriptionLabel
			Settings Tab------------------------
			MskHourStringPattern;
			MskHourTimePattern;
			MskSongStringPattern;
			MskSongZcodePattern;
			MdHourSymbolTextBox+
			
			 * Presets Controls
			 * 
			*/

            //__________________________________________________________________________
            //mdPlylistPathTextBox
            //Выполняется в SetOutputFilename
            Set_MdRusPlaylistPathTextBox.Text = _currentSettings.Settings.MdRusPlaylistPath;
            Set_MdRumPlaylistPathTextBox.Text = _currentSettings.Settings.MdRumPlaylistPath;


            //____________________________________________________________________________
            Set_MskHourStringPatternTextBox.Text = _currentSettings.Settings.MskHourStringPattern;
            Set_MskHourTimePatternTextBox.Text = _currentSettings.Settings.MskHourTimePattern;
            Set_MskSongStringPatternTextBox.Text = _currentSettings.Settings.MskSongStringPattern;
            Set_MskSongZcodePatternTextBox.Text = _currentSettings.Settings.MskSongZcodePattern;

            Set_MdHourBeginStringTextBox.Text = _currentSettings.Settings.MdHourBeginString;


            //___________________________________________________________________________
            mskPlaylistPathTextBox.Text = _currentSettings.Settings.MskPlaylistPath;
            Set_MskPlaylistPathTextBox.Text = _currentSettings.Settings.MskPlaylistPath;

            //Alias______________________________________________________________________
            aliasNameTextBox.Text = _currentSettings.Settings.AliasName;
            aliasPathTextBox.Text = _currentSettings.Settings.AliasPath;
            aliasPathPartTextBox.Text = _currentSettings.Settings.AliasPathPart;

            //___________________________________________________________________________
            //Presets

            //ComboBox
            if (UpdateComboBox)
            {
                presetsComboBox.Items.Clear();
                foreach (TimePreset t in _currentSettings.Settings.TimePresetCollection)
                {
                    presetsComboBox.Items.Add(t.PresetName);
                }

                presetsComboBox.SelectedIndex = _currentSettings.Settings.ActivePresetIndex;
            }


            //Groupbox
            PresetsGroupBox.Controls.Clear();
            PresetsGroupBox.Height = 0;

            PresetControl presetItem;
            for (int i = 0; i < _currentSettings.Settings.TimePresetCollection.Count; i++)
            {
                presetItem = new PresetControl(i, _currentSettings.Settings.TimePresetCollection[i],
                    (_currentSettings.Settings.ActivePresetIndex != i))
                {
                    Top = i * 80
                };
                if (i == 0)
                {
                    presetItem.Top += 18;
                }

                presetItem.Left = 6;
                PresetsGroupBox.Height += presetItem.Height + 7;
                PresetsGroupBox.Controls.Add(presetItem);
            }

            PresetsGroupBox.Height += 30;
            AddPresetBtn.Location = new System.Drawing.Point(656, (PresetsGroupBox.Height - 28));
            PresetsGroupBox.Controls.Add(AddPresetBtn);


            PresetDescriptionLabel.Text = _currentSettings.Settings
                .TimePresetCollection[_currentSettings.Settings.ActivePresetIndex].PresetDescription;


            //___________________________________________________________________________


            //___________________________________________________________________________
            //CheckBoxes
            foreach (var item in _currentSettings.Settings.CheckBoxesValues)
            {
                var checkBox = this.Controls.Find(item.Name, true)[0] as CheckBox;
                if (checkBox != null)
                    checkBox.Checked = item.Checked;
            }

            //___________________________________________________________________________
        }


        public void SyncSettings()
        {
            _currentSettings.Settings.MdHourBeginString = Set_MdHourBeginStringTextBox.Text;
            _currentSettings.Settings.MdRusPlaylistPath = Set_MdRusPlaylistPathTextBox.Text;
            _currentSettings.Settings.MdRumPlaylistPath = Set_MdRumPlaylistPathTextBox.Text;
            _currentSettings.Settings.MskPlaylistPath = Set_MskPlaylistPathTextBox.Text;
            _currentSettings.Settings.MskHourStringPattern = Set_MskHourStringPatternTextBox.Text;
            _currentSettings.Settings.MskHourTimePattern = Set_MskHourTimePatternTextBox.Text;
            _currentSettings.Settings.MskSongStringPattern = Set_MskSongStringPatternTextBox.Text;
            _currentSettings.Settings.MskSongZcodePattern = Set_MskSongZcodePatternTextBox.Text;

            //Alias_______________________________________________________________
            _currentSettings.Settings.AliasName = aliasNameTextBox.Text;
            _currentSettings.Settings.AliasPath = aliasPathTextBox.Text;
            _currentSettings.Settings.AliasPathPart = aliasPathPartTextBox.Text;

            //CheckBoxes__________________________________________________________

            var checkBoxes = GetAllCheckBoxesRecursively(this, typeof(CheckBox));
            _currentSettings.Settings.CheckBoxesValues.Clear();

            foreach (CheckBox item in checkBoxes)
            {
                _currentSettings.Settings.CheckBoxesValues.Add(new CheckBoxItem(item.Name,
                    item.Checked));
            }
        }


        private IEnumerable<Control> GetAllCheckBoxesRecursively(Control container, Type controlType)
        {
            var listOfCheckBoxes = new List<Control>();

            if (container.Controls.Count > 0)
            {
                foreach (Control item in container.Controls)
                {
                    listOfCheckBoxes.AddRange(GetAllCheckBoxesRecursively(item, controlType));
                }
            }
            else if (container.GetType() == controlType)
            {
                listOfCheckBoxes.Add(container);
            }

            return listOfCheckBoxes;
        }


        private void SetOutputFileName() //формируем имя выходного файла
        {
            mdPlylistPathTextBox.Text = _currentSettings.Settings.MdRusPlaylistPath +
                                        GetFormattedStringFromDate(pane1DTPicker.Value) + "_rus.txt";
        }


        public void ErrorMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                ErrorLabel.Visible = false;
            }
            else
            {
                ErrorLabel.Text = message;
                ErrorLabel.Visible = true;
            }
        }

        public void RemovePresetFromPresetCollection(int presetIndex)
        {
            _currentSettings.RemovePreset(presetIndex);
            UpdateComboBox = true;
        }

        public void AddPresetToPresetCollection(TimePreset preset, int presetIndex)
        {
            _currentSettings.AddPreset(preset, presetIndex);
        }


        #region EVENTS

        //---EVENTS---

        private void OpenPlsFileBtnClick(object sender, EventArgs e)
        {
            //далог открытия московского плейлиста
            openFileDialog1.InitialDirectory = _currentSettings.Settings.MskPlaylistPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mskPlaylistPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void GoBtnClick(object sender, EventArgs e)
        {
            //процесс пошел!

            var lostSongs = new OutOfDbSongs(outOfDbSongsDataGridView, _currentSettings);


            goBtn.Enabled = false;
            int hour = 0,
                recognized = 0,
                unrecognized = 0;

            using (OleDbConnection dbConnection = GetConnection())
            {
                try
                {
                    //Соединяемся с базой данных

                    var getName = new OleDbCommand();
                    dbConnection.Open();
                    getName.Connection = dbConnection;


                    ////////////////////////////////////////
                    //СУКА КОДИРОВКА!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    var enc = Encoding.GetEncoding(1251);

                    //СУКА КОДИРОВКА!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    ////////////////////////////////////////

                    using (var sr = new StreamReader(mskPlaylistPathTextBox.Text, enc))
                        // открываем текстовый файл для чтения

                    {
                        if (EnableProcess()) //проверяем если уже есть выходной файл
                        {
                            //и разрешена-ли его перезапись
                            using (StreamWriter swErr =
                                new StreamWriter(mskPlaylistPathTextBox.Text + "_err", false, enc))
                            {
                                // открываем файл для лога ошибок

                                StreamWriter sw = null;
                                //создаем пустой поток для записи
                                if (!DontCreatePLcheckBox.Checked)
                                {
                                    //если нормальный режим, то собственно открываем файл
                                    sw = new StreamWriter(mdPlylistPathTextBox.Text, false, enc);
                                }

                                String line;
                                // построчно читаем из файла
                                while ((line = sr.ReadLine()) != null)
                                {
                                    //Строка с именами файлов
                                    if (Regex.IsMatch(line, _currentSettings.Settings.MskSongStringPattern) &&
                                        IsIn(hour))
                                    {
                                        var zCode = Regex.Match(line, _currentSettings.Settings.MskSongZcodePattern)
                                            .Value;
                                        // ARTIST NAME REGEXP____________________________________________________________
                                        var artistName = Regex.Match(line, _currentSettings.Settings.MskArtistPattern)
                                            .Value;
                                        artistName.Trim();

                                        // SONG NAME REGEXP____________________________________________________________
                                        var songName = Regex.Match(line, _currentSettings.Settings.MskTitlePattern)
                                            .Value;
                                        songName.Trim();
                                        getName.CommandText =
                                            "SELECT Filename FROM Znames WHERE (Zname ='" + zCode + "')";
                                        if (getName.ExecuteScalar() != null)
                                        {
                                            if (!DontCreatePLcheckBox.Checked)
                                            {
                                                var song = getName.ExecuteScalar().ToString();

                                                if (sw != null)
                                                    sw.WriteLine(hour.ToString("D2") + ":00:00" + "\t" + song);
                                            }

                                            recognized++;
                                        }
                                        else
                                        {
                                            lostSongs.AddUniqueRow(zCode, artistName, songName);
                                            swErr.WriteLine(line);
                                            unrecognized++;
                                        }
                                    }
                                    //сторока с RR и временем
                                    else if (Regex.IsMatch(line, _currentSettings.Settings.MskHourStringPattern) &&
                                             !DontCreatePLcheckBox.Checked)
                                    {
                                        //парсим время
                                        hour = Convert.ToInt32(Regex.Match(line,
                                            _currentSettings.Settings.MskHourTimePattern).Value);
                                        if (CorrectTimeCheckBox.Checked) //если нужно корректировать московское время
                                            hour = hour - 1; //корректируем
                                        if (IsIn(hour)) //проверяем если этот час есть в сетке
                                            if (sw != null)
                                                sw.WriteLine("|"); //сука хитрый символ"|" типа начало часа!
                                    }
                                }

                                if (sw != null)
                                {
                                    sw.Close();
                                    sw.Dispose();
                                }
                            }
                        }
                    }

                    ErrorMessage("Зашибись! Файл " + mdPlylistPathTextBox.Text + " успешно создан! \r\n"
                                 + "Распознано " + recognized + " песен. Нераспознано " + unrecognized + ".\r\n"
                                 + "Создан файл ошибок " + mskPlaylistPathTextBox.Text + "_err");
                }
                catch (Exception)
                {
                    // Let the user know what went wrong.
                    ErrorMessage("Говнецо... Какая-то лажа... Типа не могу прочитать " + mskPlaylistPathTextBox.Text
                                                                                       + "\r\nИли записать " +
                                                                                       mdPlylistPathTextBox.Text);
                }
            }


            goBtn.Enabled = true;
            tabPage2.Show();
            outOfDbSongsDataGridView.Refresh();
        }

        private void AddPresetBtnClick(object sender, EventArgs e)
        {
            var addForm = new AddPresetForm();
            addForm.Show();
        }

        private void DontCreatePLcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DontCreatePLcheckBox.Checked)
            {
                CorrectTimeCheckBox.Checked = false;
                CorrectTimeCheckBox.Enabled = false;

                pane1DTPicker.Enabled = false;

                mdPlylistPathTextBox.Enabled = false;
                ErrorMessage(
                    "В папке Московского Плейлиста будет создан файл .txt_err\r\n со списком отсутствующих в Базе песен");
            }
            else
            {
                CorrectTimeCheckBox.Checked = true;
                CorrectTimeCheckBox.Enabled = true;

                pane1DTPicker.Enabled = true;

                mdPlylistPathTextBox.Enabled = true;
                ErrorMessage(null);
            }
        }

        private void PresetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentSettings.Settings.ActivePresetIndex = presetsComboBox.SelectedIndex;


            UpdateComboBox = false;
            _currentSettings.UpdateSettings();
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Сохранить новые установки программы?", "Сохранение установок",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                SyncSettings();
                _currentSettings.UpdateSettings();
            }
        }

        private void SaveMissedSongsBtn_Click(object sender, EventArgs e)
        {
            if (outOfDbSongsDataGridView.Rows.Count > 0)
            {
                //пройтись по строкам.
                //интересуют столбцы z_code и Path
                //если Path не пустойто проверить есть-ли z_code уже в базе


                //Comands
                //SELECT Filename FROM  Znames WHERE Zname = 'Z....'
                //UPDATE Znames SET Filename = 'Filename' WHERE Zname = 'Z...'
                //INSERT INTO Znames (Zname, Filename) VALUES ('Z...', 'Filename')

                using (OleDbConnection connection = GetConnection())
                    try
                    {
                        connection.Open();
                        var command = new OleDbCommand
                        {
                            Connection = connection
                        };


                        foreach (DataGridViewRow row in outOfDbSongsDataGridView.Rows)
                        {
                            if (row.Cells["Path"].Value == null) continue;
                            command.CommandText = "INSERT INTO Znames (Zname, Filename) VALUES ('" +
                                                  row.Cells["z_code"].Value +
                                                  "', '" +
                                                  row.Cells["Path"].Value +
                                                  "')";
                            if (!(row.Cells["Path"].Value.ToString().Contains(_currentSettings.Settings.AliasName) ||
                                  DisableWarningsCheckBox.Checked))
                            {
                                if (MessageBox.Show("В строке " +
                                                    row.Cells["ArtistName"] + row.Cells["SongName"] +
                                                    " не обнаружено правильного Алиаса. Если сохранить этот путь в базе данных, в будущем могут быть проблемы при загрузке плейлиста на эфире. \nПРодолжить? ",
                                        "Ошибка Алиаса.",
                                        MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    break;
                                }
                            }

                            if (command.ExecuteScalar() != null)
                            {
                                row.DataGridView.Rows.RemoveAt(row.Index);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
            }
        }

        private void UniteBtnClick(object sender, EventArgs e)
        {
            UnitePlaylist();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SyncSettings();
            _currentSettings.UpdateSettings();
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (((TabControl) sender).SelectedIndex == 2)
            {
                UnPlValidatePlaylists();
            }
        }

        #endregion

        private string GetFormattedStringFromDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}