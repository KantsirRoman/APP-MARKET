using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public interface IUploadPhoto
    {
        //void SetUploadApp(string AddressPhoto, string fileName, string fileCompany, string fileAbout);
        void SetUploadApp(AppModel app);
        List<AppModel> GetApp();
    }
}
