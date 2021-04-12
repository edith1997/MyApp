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
using Xamarin.Essentials;

namespace MyApp.ViewModels
{
    public class CollectionViewViewModel:ViewModelBase
    {
        #region Propiedades
        public ObservableRangeCollection<Character> Character { get; set; }

     
        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set
            {
                SetProperty(ref selectedCharacter, value);
               
            }
        }
        #endregion

        #region Comandos
        public AsyncCommand CmdRefresh { get; }
        public AsyncCommand<Character> CmdFavorite { get; }
        public AsyncCommand<object> CmdSelected { get; }
        public Command CmdClear { get; }
        public Command CmdDelayLoadMore { get; }
        public Command CmdLoadMore { get; }
        #endregion

        #region Privadas
        private Character previoslySelected;
        #endregion
        public CollectionViewViewModel()
        {
            Character = new ObservableRangeCollection<Character>();
            //Comandos
            CmdRefresh = new AsyncCommand(RefreshAsync);
            CmdFavorite = new AsyncCommand<Character>(Favorite);
            CmdSelected = new AsyncCommand<object>(Selected);
            CmdClear = new Command(Clear);
            CmdDelayLoadMore = new Command(DelayMore);
            CmdLoadMore = new Command(LoadMore);
        }

        private void DelayMore()
        {
           if (Character.Count>=15 && Character.Count <= 35)
            {
                LoadMore();
            }
        }

        private void Clear()
        {
            Character.Clear();
        }

        private async Task Favorite(Character character)
        {
            if (character == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Añadido a Favorito", character.Name, "ok");
            Vibration.Vibrate();
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;
            await Task.Delay(3000);
            LoadMore();
            IsBusy = false;
        }

        private async Task Selected(object arg)
        {
            Character character = arg as Character;
            if (character == null)
                return;
            previoslySelected = SelectedCharacter;
            SelectedCharacter = null;
            await Application.Current.MainPage.DisplayAlert("Personaje seleccionado", character.Name, "OK");
        }
        private void LoadMore()
        {
            string urlImage = "https://mario.wiki.gallery/images/thumb/7/7d/MSOGT_Bowser.png/450px-MSOGT_Bowser.png"; ;
          
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Kirby", Name = "Bowser", Image = urlImage });

        }
    }
}
