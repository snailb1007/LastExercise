using System.Windows.Input;
using Xamarin.Forms;

namespace LastExercise.ViewModels
{
    public class FillNhanVienViewModel : BaseViewModel
    {
        private static string _img;
        public string IMG {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }
        public ICommand AddClickCommand { get; private set; }
        public ICommand LoadIMGCommand { get; private set; }
        //===============================================================
        public FillNhanVienViewModel()
        {
            AddClickCommand = new Command(OnAddClicked);
            LoadIMGCommand = new Command(OnLoadIMGClicked);
        }
        private void OnAddClicked()
        {

        }
        private void OnLoadIMGClicked()
        {

        }
    }
}
