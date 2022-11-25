using Descubre_Nica.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descubre_Nica.Services
{
    public class FirebaseSitios
    {
        public async Task<List<MSitioTuristico>> GetAllMSitios()
        {
            return (await firebase
                .Child("Departamentos")
                .OnceAsync<MSitioTuristico>()).Select(item => new MSitioTuristico
                {
                    SitioId = item.Object.SitioId,
                    Nombre = item.Object.Nombre,
                    Descripcion= item.Object.Descripcion,
                    IdMunicipio= item.Object.IdMunicipio,
                    IdTipo=item.Object.IdTipo
                }).ToList();
        }

        FirebaseClient firebase;

        public FirebaseSitios()
        {
            firebase = new FirebaseClient("https://descubre-nica-190d7-default-rtdb.firebaseio.com/");
        }
    }
}
