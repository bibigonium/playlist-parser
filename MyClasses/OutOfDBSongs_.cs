using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using PlaylistParser;

namespace PlaylistParser.MyClasses
{
    class OutOfDBSongs : MainForm
    {
        private DataGridView _outOfDBGridView;
        private SettingManager _currentSettings;
        //private OleDbConnection _msindxDbConnection;

        public DataTable SongsTable;

        
        public OutOfDBSongs()
        {
            InitSongsTable();
            InitDataGridView();
            //_msindxDbConnection = new OledbConnection............
        }

        public OutOfDBSongs(DataGridView outOfDBGridView, SettingManager _Settings)
        {
            _outOfDBGridView = outOfDBGridView;
            _currentSettings = _Settings;
            InitSongsTable();
            InitDataGridView();
            //_msindxDbConnection = new OledbConnection............
        }

        public void OutOfDbSongsDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                ((DataGridView) sender).Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            else if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "ChooseFile")
            {
                var SelectSongDlg = new OpenFileDialog();
                SelectSongDlg.InitialDirectory = _currentSettings.Settings.AliasPath;
                SelectSongDlg.Filter = "Sound Files (*.mp3, *.wav)|*.mp3;*.wav|All Files|*.*";
                SelectSongDlg.FilterIndex = 1;
                if ( SelectSongDlg.ShowDialog() == DialogResult.OK)
                {
// ReSharper disable PossibleNullReferenceException
                    if(SelectSongDlg.FileName.Contains(_currentSettings.Settings.AliasPathPart))
                    {
                        ((DataGridView)sender).CurrentRow.Cells["Path"].Value = SelectSongDlg.FileName.Replace(_currentSettings.Settings.AliasPathPart, _currentSettings.Settings.AliasName);
                        
                    }
                    
// ReSharper restore PossibleNullReferenceException
                }

            }
            else if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "TryToFind")
            {
                MessageBox.Show("Возможность автоматического поиска песен в эфирной базе данных Дигитон будет обязательно добавлена позднее. ;-)",
                    "Функция в разработке", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

            }
        }

        public void AddUniqueRow(string z_code, string ArtistName, string SongName)
        {
            
            if(!SongsTable.Rows.Contains(z_code))
            {
                var newRow = SongsTable.NewRow();
                newRow["z_code"] = z_code;
                newRow["ArtistName"] = ArtistName;
                newRow["SongName"] = SongName;

                SongsTable.Rows.Add(newRow);
                
            }
            
        }

        private void InitDataGridView()
        {
            for (int i = 0; i < _outOfDBGridView.Rows.Count; i++ )
            {
                _outOfDBGridView.Rows.RemoveAt(i);
            }
            _outOfDBGridView.Columns.Clear();
            var zNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            zNameColumn.Name = "z_code";
            zNameColumn.HeaderText = "Z-code";
            zNameColumn.DisplayIndex = 0;
            zNameColumn.ReadOnly = true;
            zNameColumn.MinimumWidth = 60;
            zNameColumn.DataPropertyName = "z_code";

            var artistColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            artistColumn.Name = "ArtistName";
            artistColumn.HeaderText = "Исполнитель";
            artistColumn.DisplayIndex = 1;
            artistColumn.ReadOnly = true;
            artistColumn.MinimumWidth = 150;
            artistColumn.DataPropertyName = "ArtistName";

            var nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameColumn.Name = "SongName";
            nameColumn.HeaderText = "Песня";
            nameColumn.DisplayIndex = 2;
            nameColumn.ReadOnly = true;
            nameColumn.MinimumWidth = 220;
            nameColumn.DataPropertyName = "SongName";

            var chooseFileLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            chooseFileLinkColumn.Name = "ChooseFile";
            chooseFileLinkColumn.HeaderText="Выбрать файл";
            chooseFileLinkColumn.UseColumnTextForLinkValue = true;
            chooseFileLinkColumn.Text = "Выбрать Файл";
            chooseFileLinkColumn.DisplayIndex = 4;

            var tryToFindLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            tryToFindLinkColumn.Name = "TryToFind";
            tryToFindLinkColumn.HeaderText = "Поиск в БД эфира";
            tryToFindLinkColumn.UseColumnTextForLinkValue = true;
            tryToFindLinkColumn.Text = "Автомат. Поиск";
            tryToFindLinkColumn.DisplayIndex = 5;

            var pathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pathColumn.Name = "Path";
            pathColumn.HeaderText = "Путь к файлу";
            pathColumn.DisplayIndex = 3;

            _outOfDBGridView.Columns.Add(zNameColumn);
            _outOfDBGridView.Columns.Add(artistColumn);
            _outOfDBGridView.Columns.Add(nameColumn);
            _outOfDBGridView.Columns.Add(pathColumn);
            _outOfDBGridView.Columns.Add(chooseFileLinkColumn);
            _outOfDBGridView.Columns.Add(tryToFindLinkColumn);

            _outOfDBGridView.AutoGenerateColumns = false;
            _outOfDBGridView.AllowUserToAddRows = false;
            _outOfDBGridView.RowHeadersVisible = false;
            _outOfDBGridView.DataSource = SongsTable;
            _outOfDBGridView.CellContentClick += new DataGridViewCellEventHandler(OutOfDbSongsDataGridViewCellClick);

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
