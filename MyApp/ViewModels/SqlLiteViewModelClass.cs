using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;
using MyApp.Services;
using MyApp.Views;

namespace MyApp.ViewModels
{
    public class SqlLiteViewModelClass : ViewModelBase
    {
        #region Propiedades
        public ObservableRangeCollection<Character> Character { get; set; }
        public AsyncCommand CmdRefresh { get; }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetProperty(ref selectedCharacter, value); }
        }

        #endregion

        #region Comandos
        public AsyncCommand cmdRefresh { get; }
        public AsyncCommand<Character> CmdFavorite { get; }
        public AsyncCommand<object> CmdSelected { get; }
        public AsyncCommand<Character> CmdRemove { get; }
        public AsyncCommand CmdAdd { get; }

        #endregion

        #region Privadas
        private Character previoslySelected;
        #endregion
        public SqlLiteViewModelClass()
        {
            Character = new ObservableRangeCollection<Character>();
            CmdRefresh = new AsyncCommand(RefreshAsync);
            CmdFavorite = new AsyncCommand<Character>(Favorite);
            CmdSelected = new AsyncCommand<object>(Selected);
            CmdRemove = new AsyncCommand<Character>(Remove);
            CmdAdd = new AsyncCommand(Add);

        }

        private async Task RefreshAsync()
        {
            IsBusy = true;
            Character.Clear();
            var characterFromDB = await CharacterServices.GetCharacter();
            Character.AddRange(characterFromDB);
            await Task.Delay(1000);
            IsBusy = false;
        }
        private async Task Favorite(Character character)
        {
            if (character == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Añadido a Favorito", character.Name, "ok");
          
        }
        private async Task Selected(object arg)
        {
            Character character = arg as Character;
            if (character == null)
                return;
            previoslySelected = SelectedCharacter;
            SelectedCharacter = null;
            //await Application.Current.MainPage.DisplayAlert("Personaje seleccionado", character.Name, "ok");
            var page = nameof(DetalleViewPage).ToString();
            var IdCharacter = character.Id.ToString();
            var route = page + "?IdCharacter=" + IdCharacter;
            await Shell.Current.GoToAsync(route);
        }
        private async Task Add()
        {
            // string game = await Application.Current.MainPage.DisplayPromptAsync("Nuevo Personaje","Capture el nombre del juego","Ok" );
            // string name = await Application.Current.MainPage.DisplayPromptAsync("Nuevo Personaje", "Capture el nombre del personaje", "Ok");
            // await CharacterServices.AddCharacter(game, name);
            // await RefreshAsync();
            //var route = $"{nameof(AltaPersonajesViewPage)}";
            var route = nameof(AltaPersonajesViewPage).ToString();
            await Shell.Current.GoToAsync(route);
        }

        private async Task  Remove(Character character)
        {
            if (character != null)
            {
                await CharacterServices.RemoveCharacter(character.Id);
                await RefreshAsync();
            }
               
        }
    }
}
