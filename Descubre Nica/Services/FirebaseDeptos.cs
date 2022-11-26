using Descubre_Nica.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    Nombre = item.Object.Nombre
                }).ToList();
        }

        public async Task<ObservableCollection<MDepartamentos>> MostrarDepartamentos()
        {
            var data = await Task.Run(() => firebase
                .Child("Departamentos")
                .AsObservable<MDepartamentos>()
                .AsObservableCollection()
                );
            return data;

        }

        public async Task Adddpto(MDepartamentos _mDeptos)
        {
            await firebase
                .Child("Departamentos")
                .PostAsync(new MDepartamentos()
                {
                    DeptoId = Guid.NewGuid(),
                    Nombre= _mDeptos.Nombre,
                });
        }

        FirebaseClient firebase;

        public FirebaseDeptos()
        {
            firebase = new FirebaseClient("https://descubre-nica-190d7-default-rtdb.firebaseio.com/");
        }
    }
}
