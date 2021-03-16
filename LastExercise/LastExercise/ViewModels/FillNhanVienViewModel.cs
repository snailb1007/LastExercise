using LastExercise.Data;
using LastExercise.Models;
using LastExercise.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastExercise.ViewModels
{
    public class FillNhanVienViewModel : BaseViewModel
    {
        private static string _img;
        private SQLiteNhanVienStore _nhanVienStore;
        public NhanVienViewMode NhanVien { get; set; } = new NhanVienViewMode();
        public string IMG {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }
        public SQLiteNhanVienStore NhanVienStore
        {
            get { return _nhanVienStore; }
            set { SetProperty(ref _nhanVienStore, value); }
        }
        public ICommand AddClickCommand { get; private set; }
        public ICommand LoadIMGCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        //===============================================================
        public FillNhanVienViewModel(SQLiteNhanVienStore nhanVienStore)
        {
            _nhanVienStore = nhanVienStore;
            AddClickCommand = new Command(OnAddClicked);
            LoadIMGCommand = new Command(OnLoadIMGClicked);
            ClearCommand = new Command(OnCLearClicked);
        }
        private async void OnAddClicked()
        {
            
            PageService page = new PageService();
            if (string.IsNullOrWhiteSpace(NhanVien.ID.ToString()) || string.IsNullOrWhiteSpace(NhanVien.IMG)
                || string.IsNullOrWhiteSpace(NhanVien.Name) || string.IsNullOrWhiteSpace(NhanVien.Date)
                || string.IsNullOrWhiteSpace(NhanVien.Desc))
            {
               await page.DisplayAlert("Failed!", "All box can not null.", "OK");
            }
            else
            {
                NhanVien x = new NhanVien();
                x.ID = NhanVien.ID;
                x.IMG=NhanVien.IMG;
                x.Date=NhanVien.Date;
                x.Desc = NhanVien.Desc;
                x.Name = NhanVien.Name;
                try
                {
                    await _nhanVienStore.AddNhanVien(x);
                    await page.PopAsync();
                }
                catch (System.Exception e)
                {

                    await page.DisplayAlert("Failed!", $"Add failed.\n {e.Message}", "OK");
                }
                
            }
        }
        private void OnLoadIMGClicked()
        {
             IMG = NhanVien.IMG;
        }
        private void OnCLearClicked()
        {
            NhanVien.ID = 0;
            NhanVien.IMG = "";
            NhanVien.Date = "";
            NhanVien.Desc = "";
            NhanVien.Name = "";
        }
    }
}
