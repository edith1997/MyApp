using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyApp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;
using MyApp.Services;


namespace MyApp.ViewModels
{
    //[QueryProperty(nameof(Name), nameof(Name)]
    public class AltaPersonajesViewModel : ViewModelBase
    {
        #region Propiedades
        public String Game { get { return game; } set { SetProperty(ref game, value); } }
        public String Name { get { return name; } set { SetProperty(ref name, value); } }
        #endregion
        private string game, name;
        #region Comandos
        public AsyncCommand CmdGuardar { get; }


        #endregion
        public AltaPersonajesViewModel()
        {
            Title = "Alta";
            CmdGuardar = new AsyncCommand(SaveCharacter);
        }


        private async Task SaveCharacter()
        {
            if (string.IsNullOrEmpty(Game))
            {
                await Application.Current.MainPage.DisplayAlert("Dato invalido", "Ingrese el nombre del juego", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Name)){
                await Application.Current.MainPage.DisplayAlert("Dato invalido", "Ingrese el nombre del juego", "Ok");
            return;
             }
            await CharacterServices.AddCharacter(Game, Name);
            await Shell.Current.GoToAsync("..");
        }




    }
}
