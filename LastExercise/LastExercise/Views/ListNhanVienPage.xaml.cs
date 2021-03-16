
using LastExercise.Data;
using LastExercise.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LastExercise.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListNhanVienPage : ContentPage
    {
        public ListNhanVienPage()
        {
            var x = new SQLiteNhanVienStore(DependencyService.Get<ISQLite>());          
            this.BindingContext = new ListNhanVienViewModel(x);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        public ListNhanVienViewModel ViewModel
        {
            get { return BindingContext as ListNhanVienViewModel; }
            set { BindingContext = value; }
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await ViewModel.ItemSelected(e.SelectedItem as NhanVienViewMode);
        }
    }
}