
using LastExercise.Data;
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
            var x = new SQLiteNhanVienStore(DependencyService.Get<ISQLite>());
            ViewModel = new FillNhanVienViewModel(x);
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}