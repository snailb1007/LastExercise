using LastExercise.Data;
using LastExercise.Models;
using LastExercise.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastExercise.ViewModels
{
    public class DetailNhanVienViewModel : BaseViewModel
    {
        private static NhanVienViewMode _nhanVien;
        public NhanVienViewMode NhanVien
        {
            get { return _nhanVien; }
            set { SetProperty(ref _nhanVien, value); }
        }
        private readonly INhanVienStore _nhanVienStore;
        private readonly IPageService _pageService;
        public ICommand UpdateCommand { get; set; }
        public DetailNhanVienViewModel(NhanVienViewMode x, INhanVienStore nhanVienStore, IPageService pageService)
        {
            _nhanVienStore = nhanVienStore;
            _pageService = pageService;
            LoadData(x);
            UpdateCommand = new Command(OnUpdateClicked);
        }
        private NhanVienViewMode LoadData(NhanVienViewMode x)
        {
            NhanVien = x;
            return NhanVien;
        }
        private async void OnUpdateClicked()
        {
            NhanVien nv = new NhanVien();
            nv.ID = NhanVien.ID;
            nv.Date = NhanVien.Date;
            nv.Desc = NhanVien.Desc;
            nv.Name = NhanVien.Name;
            nv.IMG = NhanVien.IMG;
            try
            {
                if (nv.ID >= 0)
                {
                    await _nhanVienStore.UpdateNhanVien(nv);
                    await _pageService.DisplayAlert("Success!", "Added.", "OK");
                }
                else
                {
                    await _pageService.DisplayAlert("Failed!", "ID is error!", "Ok");
                }
            }
            catch (System.Exception)
            {
                await _pageService.DisplayAlert("Failed!", "Added Failed when adding.", "OK");
            }
            await _pageService.PopAsync();
        }
    }
}
