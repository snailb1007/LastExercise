using LastExercise.Models;

namespace LastExercise.ViewModels
{
    public class DetailNhanVienViewModel : BaseViewModel
    {
        private static NhanVien _nhanVien;
        public NhanVien NhanVien
        {
            get { return _nhanVien; }
            set { SetProperty(ref _nhanVien, value); }
        }
        public DetailNhanVienViewModel(NhanVien x)
        {
            LoadData(x);
        }
        private NhanVien LoadData(NhanVien x)
        {
            NhanVien = x;
            return NhanVien;
        }
    }
}
