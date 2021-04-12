using MyApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyApp.Services
{
    public static class CharacterServices
    {
        private static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            //Cuando la base no este creada
            if (db != null)
                return;
            //Obtener Ruta para la BD
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            //Crear la conexion a ala BD
            db = new SQLiteAsyncConnection(databasePath);
            //Crear la tabla con await
            await db.CreateTableAsync<Character>();
        }

        //Crear objeto
        public static async Task AddCharacter(string game,string name)
        {  
            //Revisar si existe la bd
            await Init();
            string urlImage = "https://mario.wiki.gallery/images/thumb/7/7d/MSOGT_Bowser.png/450px-MSOGT_Bowser.png";
            Character newCharacter = new Character
            {
                Game = game,
                Name=name,
                Image=urlImage
            };
            //Guardar en BD
            int id=await db.InsertAsync(newCharacter);
        }

        public static async Task RemoveCharacter(int id)
        {
            //Revisar si existe la bd
            await Init();
            await db.DeleteAsync<Character>(id);
        }
        public static async Task<List<Character>> GetCharacter()
        {
            //Revisar si existe la bd
            await Init();

            var allCharacters = await db.Table<Character>().ToListAsync();
            return allCharacters;
        }

        public static async Task<Character> GetCharacter(int id)
        {
            await Init();

        }

    }
}
