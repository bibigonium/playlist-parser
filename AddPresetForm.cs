using System;
using System.Windows.Forms;
using PlaylistParser.MyClasses;


namespace PlaylistParser
{

    public partial class AddPresetForm : Form
    {
        //private SettingManager _settings;
        private int PresetIndex { get; set; }
        private TimePreset _preset;

        public AddPresetForm()
        {
            //_settings = settings;
            PresetIndex = -1;
            InitializeComponent();
            addBtn.Text = "Добавить";
            _preset = new TimePreset();

        }

        public AddPresetForm(TimePreset preset, int presetIndex )
        {
            //_settings = settings;
            PresetIndex = presetIndex;
            _preset = preset;
            InitializeComponent();
            //PopulateCheckBoxes(null,null);
            addBtn.Text = "Сохранить";
            presetNameTextBox.Text = _preset.PresetName;
            DescriptionTextBox.Text = _preset.PresetDescription;
        }


        private void InitializeListBoxes()
        {
            for(int i= 0; i < 24 ;i++)
            {
                fromComboBox.Items.Add(i);
                toComboBox.Items.Add(i);
            }
            fromComboBox.SelectedIndex = 6;
            toComboBox.SelectedIndex = 20;
            PopulateCheckBoxes(null, null);
            //throw new NotImplementedException();
        }

        private void AddPresetForm_Load(object sender, EventArgs e)
        {
          InitializeListBoxes();

        }

        private void PopulateCheckBoxes(object sender, EventArgs e)
        {
            if(PresetIndex !=-1)
            {
                foreach (CheckBox i in hoursGroupBox.Controls)
                {
                    i.Checked = _preset.Preset.Contains(Convert.ToInt32(i.Text));
                }
                
            }
            else
            {
                foreach (CheckBox i in hoursGroupBox.Controls)
                {
                    i.Checked = Convert.ToInt32(i.Text) >= fromComboBox.SelectedIndex &&
                                Convert.ToInt32(i.Text) <= toComboBox.SelectedIndex;
                }

            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            if((((Button)sender).Tag.ToString() == "Add") && (((Button)sender).Name == "addBtn"))
            {
                //--------------------------------------------------------------------------------
                //Update actual preset
                _preset.PresetName = presetNameTextBox.Text;
                _preset.PresetDescription = DescriptionTextBox.Text;
                foreach (CheckBox i in hoursGroupBox.Controls)
                    {
                        if (i.Checked)
                        {
                            _preset.Preset.Add(Convert.ToInt32(i.Text));
                        }
                    }
                //---------------------------------------------------------------------------------

                Program.Parser.AddPresetToPresetCollection(_preset, PresetIndex);
                
            }
            

            this.Dispose();
            this.Close();
        }

        

    }


}
