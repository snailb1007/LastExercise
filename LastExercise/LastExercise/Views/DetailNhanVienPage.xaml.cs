using LastExercise.Data;
using LastExercise.Models;
using LastExercise.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LastExercise.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNhanVienPage : ContentPage
    {
        public DetailNhanVienPage(NhanVienViewMode x)
        {
            var dataAccess =new SQLiteNhanVienStore(DependencyService.Get<ISQLite>());
            var pageService = new Services.PageService();
            ViewModel = new DetailNhanVienViewModel(x,dataAccess, pageService);
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
        private DetailNhanVienViewModel ViewModel;

    }
}