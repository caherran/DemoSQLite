using DemoSQLite.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DemoSQLite.iOS.Config))]

namespace DemoSQLite.iOS
{
    public class Config : IConfig
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
                    _directorioDB = System.IO.Path.Combine(directorio, "..", "Library");
                }
                return _directorioDB;
            }
        }

        //public ISQLitePlatform Plataforma
        //{
        //    get
        //    {
        //        if(_plataforma == null)
        //        {
        //            _plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        //        }
        //        return _plataforma;
        //    }
        //}
    }
}