using LastExercise.Models;
using LastExercise.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LastExercise.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNhanVienPage : ContentPage
    {
        public DetailNhanVienPage(NhanVien x)
        {
            InitializeComponent();
            ViewModel = new DetailNhanVienViewModel(x);
            this.BindingContext = ViewModel;
        }
        private DetailNhanVienViewModel ViewModel;

    }
}