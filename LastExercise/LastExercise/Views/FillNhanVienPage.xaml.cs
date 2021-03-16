
using LastExercise.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LastExercise.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FillNhanVienPage : ContentPage
    {
        private FillNhanVienViewModel ViewModel;
        public FillNhanVienPage()
        {
            ViewModel = new FillNhanVienViewModel();
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}