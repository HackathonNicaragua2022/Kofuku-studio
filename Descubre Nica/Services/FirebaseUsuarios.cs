using Descubre_Nica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Auth;

namespace Descubre_Nica.Services
{
    public class FirebaseUsuarios
    {
        //select
        public async Task<List<MUsers>> GetAllMUsers()
        {
            return (await firebase
                .Child("Usuarios")
                .OnceAsync<MUsers>()).Select(item=> new MUsers
                {
                    UserID = item.Object.UserID,
                    NUser = item.Object.NUser,
                    Edad = item.Object.Edad,
                    Sexo = item.Object.Sexo,
                    Correo = item.Object.Correo,
                    Clave = item.Object.Clave
                }).ToList();
        }

        //Add
        public async Task AddUser(MUsers _mUsers)
        {
            await firebase
                .Child("Usuarios")
                .PostAsync(new MUsers()
                {
                    UserID = Guid.NewGuid(),
                    NUser = _mUsers.NUser,
                    Edad = _mUsers.Edad,
                    Sexo = _mUsers.Sexo,
                    Correo = _mUsers.Correo,
                    Clave = _mUsers.Clave
                });
        }

        public async Task UpdateUser(MUsers _mUsers)
        {
            var toUpdateUser = (await firebase
                .Child("Usuarios")
                .OnceAsync<MUsers>()).Where(a => a.Object.UserID == _mUsers.UserID).FirstOrDefault();

            await firebase
               .Child("Usuarios")
               .Child(toUpdateUser.Key)
               .PutAsync(new MUsers() {
                   UserID = _mUsers.UserID, 
                   NUser = _mUsers.NUser, 
                   Edad = _mUsers.Edad, 
                   Sexo = _mUsers.Sexo, 
                   Correo = _mUsers.Correo, 
                   Clave = _mUsers.Clave});
        }

        public async Task DeleteUser(Guid userid)
        {
            var toDeletePerson = (await firebase
                .Child("Usuarios")
                .OnceAsync<MUsers>()).Where(a=> a.Object.UserID == userid).FirstOrDefault();

            await firebase.Child("Usuarios").Child(toDeletePerson.Key).DeleteAsync();
        }

        FirebaseClient firebase;

        public FirebaseUsuarios()
        {
            firebase = new FirebaseClient("https://descubre-nica-190d7-default-rtdb.firebaseio.com/");
        }
    }
}
