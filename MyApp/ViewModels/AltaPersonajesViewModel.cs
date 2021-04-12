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
    public class AltaPersonajesViewModel:ViewModelBase
    {
        #region Propiedades

        #endregion
        private string game, name;
        #region Comandos
     


        #endregion
        public AltaPersonajesViewModel()
        {
           
        }

        private async Task Add()
        {
         //   await CharacterServices.AddCharacter(Game, Name);
            await Shell.Current.GoToAsync("..");
        }

      


    }
}
