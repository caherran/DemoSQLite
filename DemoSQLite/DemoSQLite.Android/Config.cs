using DemoSQLite.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DemoSQLite.Droid.Config))]

namespace DemoSQLite.Droid
{
    public class Config: IConfig
    {
        private string _directorioDB;
        //private ISQLitePlatform _plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_directorioDB))
                {
                    var directorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    _directorioDB = directorio;
                }
                return _directorioDB;
            }
        }

        //public ISQLitePlatform Plataforma
        //{
        //    get
        //    {
        //        if (_plataforma == null)
        //        {
        //            _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //        }
        //        return _plataforma;
        //    }
        //}
    }
}