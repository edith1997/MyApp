using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyApp.Models;

namespace MyApp.ViewModels
{
    public class ListViewViewModel:ViewModelBase
    {
        #region Propiedades
        public ObservableRangeCollection<Character> Character { get; set; }
        public ObservableRangeCollection<Grouping<string, Character>>  CharacterGroups { get; set; }
        public AsyncCommand CmdRefresh { get; }
        #endregion
        public ListViewViewModel()
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
            CharacterGroups.Add(new Grouping<string, Character>("Mario Bross",Character.Where(c => c.Game == "Mario Bross")));
            CharacterGroups.Add(new Grouping<string, Character>("Zelda", Character.Where(c => c.Game == "Zelda")));
            CharacterGroups.Add(new Grouping<string, Character>("Kirby ", Character.Where(c => c.Game == "Kirby")));
            CharacterGroups.Add(new Grouping<string, Character>("Donkey Kong", Character.Where(c => c.Game == "Donkey Kong")));
            CharacterGroups.Add(new Grouping<string, Character>("Ofive", Character.Where(c => c.Game == "Ofive")));

            //Comandos
            CmdRefresh = new AsyncCommand(RefreshAsync);
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
        }

    }


   
}
