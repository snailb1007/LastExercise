using LastExercise.Data;
using LastExercise.Models;
using LastExercise.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LastExercise.ViewModels
{
    public class ListNhanVienViewModel : BaseViewModel
    {
        private INhanVienStore _nhanVienStore;
        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddNaviCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ObservableCollection<NhanVien> temp { get; private set; } = new ObservableCollection<NhanVien>();
        public ObservableCollection<NhanVien> _nhanViens;
        public ObservableCollection<NhanVien> NhanViens
        {
            get { return _nhanViens; }
            set { SetProperty(ref _nhanViens, value) ; }
        }
        //==========================================================
        public ListNhanVienViewModel(INhanVienStore nhanVienStore)
        {
            _nhanViens = new ObservableCollection<NhanVien>();
            _nhanVienStore = nhanVienStore; //khai mo connect vs SQLite.
            //Command
            LoadDataCommand = new Command(async() => await LoadData());
            DeleteCommand = new Command(async x => await DeleteClicked(x));
            AddNaviCommand = new Command(async ()=> await AddNaviClicked());
        }
        private async Task LoadData()
        {        
            var nhanViens = await _nhanVienStore.GetNhanViensAsync();
            temp=DSKhoiTao;
            foreach (var x in nhanViens)
            { temp.Add(x); }
            NhanViens = temp;
        }
        private async Task DeleteClicked(object obj)
        {
            PageService page = new PageService();
            if (await page.DisplayAlert("Accept Delete", "Are you sure?", "OK", "Cancel"))
            {
                var x = obj as NhanVien;
                await _nhanVienStore.DeleteNhanVien(x);
                temp.Remove(x);
            }
            NhanViens = temp;
        }
        private async Task AddNaviClicked()
        {
            PageService page = new PageService();
            await page.PushAsync(new Views.FillNhanVienPage());
        }
        public async Task ItemSelected(NhanVien x)
        {
            PageService page = new PageService();
            await page.PushAsync(new Views.DetailNhanVienPage(x));
        }
        private ObservableCollection<Models.NhanVien> DSKhoiTao = new ObservableCollection<Models.NhanVien>
        {
            new Models.NhanVien { ID = 1, Date = "01/01/1997", Name = "Jenny Dalby",
                IMG="https://images.unsplash.com/photo-1595399874399-10f2444c4eb2?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=475&q=80",
                Desc = "Nửa đời sầu nửa đời âu"},
            new Models.NhanVien { ID = 2, Date = "01/01/1997", Name = "Jonv",
                Desc = "Gập ghềnh mưa gió Nửa đời người",
                IMG="https://images.unsplash.com/photo-1569466896818-335b1bedfcce?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80"},
            new Models.NhanVien { ID = 3, Date = "01/01/1997", Name = "RachelMartin",
                Desc = "Chợt nhận ra tuyết rơi bên khung cửa sổ",
                IMG="https://images.unsplash.com/photo-1612041720569-7e67f4061729?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=480&q=80"},
            new Models.NhanVien { ID = 4, Date = "01/01/1997", Name = "Nivan Jay",
                Desc = "lệ ta rơi lòng ta đau",
                IMG="https://images.unsplash.com/photo-1610216705422-caa3fcb6d158?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80"},
            new Models.NhanVien { ID = 5, Date = "01/01/1997", Name = "SanazZ",
                Desc = "thừa cô đơn quá dư u sầu",
                IMG="https://images.unsplash.com/photo-1612417783135-89e4571fe8e0?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=493&q=80"},
            new Models.NhanVien { ID = 6, Date = "01/01/1997", Name = "NextLab",
                Desc = "Tìm men say chỉ mong sẽ yên lòng hơn",
                IMG="https://images.unsplash.com/photo-1607283455867-3c1dc4166f26?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=548&q=80"},
            new Models.NhanVien { ID = 7, Date = "01/01/1997", Name = "AlexB",
                Desc = "mình tôi lê bước lạc vào giấc mơ hão huyền",
                IMG="https://images.unsplash.com/photo-1593692667732-d53fdaec0b60?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80"},
            new Models.NhanVien { ID = 8, Date = "01/01/1997", Name = "Tara Chang",
                Desc = "mà đâu biết em phũ phàng",
                IMG="https://images.unsplash.com/photo-1551712702-4b7335dd8706?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80" },
            new Models.NhanVien { ID = 9, Date = "01/01/1997", Name = "Tom K",
                Desc = "Thiên Sơn đất trời ngàn bình rượu đựng nào vơi tổn thương bấy lâu",
                IMG="https://images.unsplash.com/photo-1597223557154-721c1cecc4b0?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80" },
        };
    }
}
