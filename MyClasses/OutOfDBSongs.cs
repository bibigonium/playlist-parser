using System.Data;
using System.Windows.Forms;

namespace PlaylistParser.MyClasses
{
    class OutOfDbSongs 
    {
        private DataGridView _outOfDbGridView;
        private SettingManager _currentSettings;
        //private OleDbConnection _msindxDbConnection;

        public DataTable SongsTable;


        public OutOfDbSongs()
        {
            InitSongsTable();
            InitDataGridView();
            //_msindxDbConnection = new OledbConnection............
        }

        public OutOfDbSongs(DataGridView outOfDbGridView, SettingManager settings)
        {
            _outOfDbGridView = outOfDbGridView;
            _currentSettings = settings;
            InitSongsTable();
            InitDataGridView();
            //_msindxDbConnection = new OledbConnection............
        }

        public void OutOfDbSongsDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                ((DataGridView)sender).Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else switch (((DataGridView)sender).Columns[e.ColumnIndex].Name)
            {
                case "ChooseFile":
                    {
                        var selectSongDlg = new OpenFileDialog
                                                {
                                                    InitialDirectory = _currentSettings.Settings.AliasPath,
                                                    Filter = "Sound Files (*.mp3, *.wav)|*.mp3;*.wav|All Files|*.*",
                                                    FilterIndex = 1
                                                };
                        if (selectSongDlg.ShowDialog() == DialogResult.OK)
                        {
                            // ReSharper disable PossibleNullReferenceException
                            if (selectSongDlg.FileName.Contains(_currentSettings.Settings.AliasPathPart))
                            {
                                ((DataGridView)sender).CurrentRow.Cells["Path"].Value = selectSongDlg.FileName.Replace(_currentSettings.Settings.AliasPathPart, _currentSettings.Settings.AliasName);

                            }
                            else
                            {
                                ((DataGridView)sender).CurrentRow.Cells["Path"].Value = selectSongDlg.FileName;
                            }

                            // ReSharper restore PossibleNullReferenceException
                        }

                    }
                    break;
                case "TryToFind":
                    MessageBox.Show("Возможность автоматического поиска песен в эфирной базе данных Дигитон будет обязательно добавлена позднее. ;-)",
                                    "Функция в разработке",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
        }

        public void AddUniqueRow(string zCode, string artistName, string songName)
        {

            if (!SongsTable.Rows.Contains(zCode))
            {
                var newRow = SongsTable.NewRow();
                newRow["z_code"] = zCode;
                newRow["ArtistName"] = artistName;
                newRow["SongName"] = songName;

                SongsTable.Rows.Add(newRow);

            }

        }

        private void InitDataGridView()
        {
            for (int i = 0; i < _outOfDbGridView.Rows.Count; i++)
            {
                _outOfDbGridView.Rows.RemoveAt(i);
            }
            _outOfDbGridView.Columns.Clear();
            var zNameColumn = new DataGridViewTextBoxColumn
                                  {
                                      Name = "z_code",
                                      HeaderText = "Z-code",
                                      DisplayIndex = 0,
                                      ReadOnly = true,
                                      MinimumWidth = 35,
                                      DataPropertyName = "z_code"
                                  };

            var artistColumn = new DataGridViewTextBoxColumn
                                   {
                                       Name = "ArtistName",
                                       HeaderText = "Исполнитель",
                                       DisplayIndex = 1,
                                       ReadOnly = true,
                                       MinimumWidth = 130,
                                       DataPropertyName = "ArtistName"
                                   };

            var nameColumn = new DataGridViewTextBoxColumn
                                 {
                                     Name = "SongName",
                                     HeaderText = "Песня",
                                     DisplayIndex = 2,
                                     ReadOnly = true,
                                     MinimumWidth = 150,
                                     DataPropertyName = "SongName"
                                 };

            var chooseFileLinkColumn = new DataGridViewLinkColumn
                                           {
                                               Name = "ChooseFile",
                                               HeaderText = "Выбрать файл",
                                               UseColumnTextForLinkValue = true,
                                               Text = "Выбрать Файл",
                                               DisplayIndex = 4
                                           };

            var tryToFindLinkColumn = new DataGridViewLinkColumn
                                          {
                                              Name = "TryToFind",
                                              HeaderText = "Поиск в БД эфира",
                                              UseColumnTextForLinkValue = true,
                                              Text = "Автомат. Поиск",
                                              DisplayIndex = 5
                                          };

            var pathColumn = new DataGridViewTextBoxColumn
                                 {
                                     Name = "Path",
                                     HeaderText = "Путь к файлу",
                                     MinimumWidth = 160,
                                     DisplayIndex = 3
                                 };

            _outOfDbGridView.Columns.Add(zNameColumn);
            _outOfDbGridView.Columns.Add(artistColumn);
            _outOfDbGridView.Columns.Add(nameColumn);
            _outOfDbGridView.Columns.Add(pathColumn);
            _outOfDbGridView.Columns.Add(chooseFileLinkColumn);
            _outOfDbGridView.Columns.Add(tryToFindLinkColumn);

            _outOfDbGridView.AutoGenerateColumns = false;
            _outOfDbGridView.AllowUserToAddRows = false;
            _outOfDbGridView.RowHeadersVisible = false;
            _outOfDbGridView.DataSource = SongsTable;
            _outOfDbGridView.CellContentClick += new DataGridViewCellEventHandler(OutOfDbSongsDataGridViewCellClick);

        }

        private void InitSongsTable()
        {
            SongsTable = new DataTable("Songs Out of Database");
            SongsTable.Columns.Add(new DataColumn("z_code"));
            SongsTable.Columns.Add(new DataColumn("ArtistName"));
            SongsTable.Columns.Add(new DataColumn("SongName"));
            var key = new DataColumn[1];
            key[0] = SongsTable.Columns["z_code"];
            SongsTable.PrimaryKey = key;
        }

        //public void ClearDataSource()
        //{
        //    SongsTable.Rows.Clear();
        //    _outOfDBGridView.Rows.Clear();
        //}

    }
}
