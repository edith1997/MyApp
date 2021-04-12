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

namespace MyApp.ViewModels
{
    public class ListViewVMViewModel:ViewModelBase
    {
        #region Propiedades
        public ObservableRangeCollection<Character> Character { get; set; }
    
        public ObservableRangeCollection<Grouping<string, Character>> CharacterGroups { get; set; }
        public AsyncCommand CmdRefresh { get; }

        private Character selectedCharacter;
        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set 
            {
                SetProperty(ref selectedCharacter, value);
                // if (value != null)
                //{
                //Logica para realizar una accion
                //Application.Current.MainPage.DisplayAlert("Personaje Seleccionado",value.Name,"OK");
                // previoslySelected = value;
                // value = null;// para quitar la seleccion
                //}

                //  selectedCharacter = value;
                //  OnPropertyChanged();
            }
        }

        public AsyncCommand<Character> CmdFavorite { get; }
        public AsyncCommand<Character> CmdBorrar { get; }

        private ICommand cmdCargar;

        public ICommand CmdCargar
        {
            get
            {
                if (cmdCargar == null)
                {
                    cmdCargar = new Command(PerformCmdCargar);
                }

                return cmdCargar;
            }
        }
        public AsyncCommand<object> CmdSelected { get; }

       
        #endregion

        #region Privadas
        private Character previoslySelected;
        #endregion

        public ListViewVMViewModel()
        {
            string urlImage = "https://mario.wiki.gallery/images/thumb/7/7d/MSOGT_Bowser.png/450px-MSOGT_Bowser.png"; ;
            Character = new ObservableRangeCollection<Character>();
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Kirby", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Donkey Kong", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Ofive", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Ofive", Name = "Bowser", Image = urlImage });

            CharacterGroups = new ObservableRangeCollection<Grouping<string, Character>>();
            CharacterGroups.Add(new Grouping<string, Character>("Mario Bross", Character.Where(c => c.Game == "Mario Bross")));
            CharacterGroups.Add(new Grouping<string, Character>("Zelda", Character.Where(c => c.Game == "Zelda")));
            CharacterGroups.Add(new Grouping<string, Character>("Kirby ", Character.Where(c => c.Game == "Kirby")));
            CharacterGroups.Add(new Grouping<string, Character>("Donkey Kong", Character.Where(c => c.Game == "Donkey Kong")));
            CharacterGroups.Add(new Grouping<string, Character>("Ofive", Character.Where(c => c.Game == "Ofive")));

            //Comandos
            CmdRefresh = new AsyncCommand(RefreshAsync);
            CmdFavorite = new AsyncCommand<Character>(Favorite);
            CmdBorrar = new AsyncCommand<Character>(Delete);
            CmdSelected = new AsyncCommand<object>(Selected);
            
        }

        private async Task Selected(object arg)
        {
            Character character = arg as Character;
            if (character == null)
                return;
            previoslySelected = SelectedCharacter;
            SelectedCharacter = null;
            await Application.Current.MainPage.DisplayAlert("Personaje seleccionado", character.Name, "ok");
        }

        // private async Task Selecteds(Character arg)
        // {
        //    if (arg == null)
        //       return;
        // SelectedCharacter = null;
        // await Application.Current.MainPage.DisplayAlert("Personaje seleccionado", arg.Name, "ok");
        //}
        //
        private async Task Delete(Character character)
        {

            if (character == null)
                return;
            Character.Remove(character);
            await Application.Current.MainPage.DisplayAlert("Eliminado", character.Name, "ok");
        }

        private async Task Favorite(Character character)
        {
            if (character == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Añadido a Favorito", character.Name, "ok");
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
        }

      
        private void PerformCmdCargar()
        {
            string urlImage = "https://mario.wiki.gallery/images/thumb/7/7d/MSOGT_Bowser.png/450px-MSOGT_Bowser.png"; 
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Mario Bross", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Zelda", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Kirby", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Donkey Kong", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Ofive", Name = "Bowser", Image = urlImage });
            Character.Add(new Character { Game = "Ofive", Name = "Bowser", Image = urlImage });
           
        }

      
       
    }
}
