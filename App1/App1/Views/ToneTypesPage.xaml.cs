using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToneTypesPage : ContentPage, INotifyPropertyChanged
    {
        IToneService _toneService;
        private ObservableCollection<string> _toneTypes;
        private int durationiNMs = 5000;

        public ObservableCollection<string> ToneTypes
        {
            get { return _toneTypes; }
            set
            {
                if (_toneTypes != value)
                {
                    _toneTypes = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToneTypes)));
                }
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
        public ToneTypesPage()
        {
            InitializeComponent();
            _toneService = DependencyService.Get<IToneService>();
            var toneTypes = _toneService.GetToneTypes();
            ToneTypes = new ObservableCollection<string>(toneTypes);
            lst_ToneTypes.ItemsSource = ToneTypes;
            lst_ToneTypes.ItemSelected += Lst_ToneTypes_ItemSelected;
        }
        private void Lst_ToneTypes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _toneService.StartTone(e.SelectedItem.ToString());
        }

        private void StartTone_Clicked(object sender, EventArgs e)
        {
            //int.TryParse(entryDuration.Text, out durationiNMs);
            _toneService.StartTone(durationiNMs);
        }

        private void StopTone_Clicked(object sender, EventArgs e)
        {
            _toneService.StopTone();
        }
    }
}