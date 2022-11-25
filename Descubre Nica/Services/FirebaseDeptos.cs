using Descubre_Nica.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Descubre_Nica.Services
{
    public class FirebaseDeptos
    {
        public async Task<List<MDepartamentos>> GetAllMDepartamentos()
        {
            return (await firebase
                .Child("Departamentos")
                .OnceAsync<MDepartamentos>()).Select(item => new MDepartamentos
                {
                    DeptoId = item.Object.DeptoId,
                    Nombre = item.Object.Nombre
                }).ToList();
        }

        FirebaseClient firebase;

        public FirebaseDeptos()
        {
            firebase = new FirebaseClient("https://descubre-nica-190d7-default-rtdb.firebaseio.com/");
        }
    }
}
