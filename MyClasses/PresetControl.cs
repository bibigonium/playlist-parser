using System.Windows.Forms;

namespace PlaylistParser.MyClasses
{
    public partial class PresetControl : UserControl
    {

        private TimePreset _preset;
        private int PresetIndex { get; set; }
 
        //Constructors
        //____________________________________________________________

        public PresetControl()
        {
            _preset = new TimePreset();
            PresetIndex = -1;
            InitializeComponent();
            RefreshControl();

        }

        public PresetControl(int index, TimePreset preset, bool enableDelete)
        {
            _preset = preset;
            PresetIndex = index;
            InitializeComponent();

            DeletePresetLinkLabel.Enabled = enableDelete;

            RefreshControl();
        }

        public PresetControl(int index, TimePreset preset)
        {
            _preset = preset;
            PresetIndex = index;
            InitializeComponent();
            
            RefreshControl();
        }
        //Methods
        //_________________________________________________________________

        private void RefreshControl()
        {
            PresetName.Text = _preset.PresetName;
            PresetHours.Text = _preset.GetStringHours();
            Refresh();
        }

        private void OnRemovePresetLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить этот пресет?", "Удаление пресета",
                                MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            Program.Parser.RemovePresetFromPresetCollection(PresetIndex);
        }

        private void OnEditPresetLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var editPresetForm = new AddPresetForm(_preset, PresetIndex);
            editPresetForm.Show();
            RefreshControl();
        }


    }
}
