namespace LastExercise.ViewModels
{
    public class NhanVienViewMode : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _date;
        private string _img;
        private string _desc;
        public NhanVienViewMode() { }
        public NhanVienViewMode(int id, string name, string date, string img, string desc)
        {
            _id = id;
            _name = name;
            _date = date;
            _img = img;
            _desc = desc;
        }

        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
        public string IMG
        {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }
        public string Desc
        {
            get { return _desc; }
            set { SetProperty(ref _desc, value); }
        }
    }
}
