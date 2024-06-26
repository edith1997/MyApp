﻿using MvvmHelpers.Commands;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    [QueryProperty(nameof(IdCharacter), nameof(IdCharacter))]
    public class DetalleViewModel:ViewModelBase
    {
       
        private string game;
        public string Game { get => game; set => SetProperty(ref game, value) ; }
        private string image;
        public string Image { get => image; set => SetProperty(ref image, value); }
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public AsyncCommand CmdOk { get; }
   
        private string idCharacter;
        public string IdCharacter { get => idCharacter; set => SetProperty(ref idCharacter, value); }

        public Task Init { get; private set; }
        public DetalleViewModel()
        {
            CmdOk = new AsyncCommand(Ok);
            Init = Ok();
        }

        private async Task Ok()
        {
            int Idaux;
            int.TryParse(IdCharacter, out Idaux);
            var character = await CharacterServices.GetCharacter(Idaux);
            Name = character.Name;
            Game = character.Game;
            Image = character.Image;
            await AppShell.Current.GoToAsync("..");
        }
    }
}
