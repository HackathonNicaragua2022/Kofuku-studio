using Descubre_Nica.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descubre_Nica.Services
{
    public class FirebaseMunicipios
    {
        public async Task<List<MMunicipios>> GetAllMMunicipios( string id)
        {
            return (await firebase
                .Child("Departamentos")
                .OnceAsync<MMunicipios>()).Select(item => new MMunicipios
                {
                    MunId = item.Object.MunId,
                    Nombre = item.Object.Nombre,
                    IdDepto= item.Object.IdDepto
                }).ToList();
        }

        FirebaseClient firebase;

        public FirebaseMunicipios()
        {
            firebase = new FirebaseClient("https://descubre-nica-190d7-default-rtdb.firebaseio.com/");
        }
    }
}
