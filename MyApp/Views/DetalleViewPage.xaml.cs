using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    
    [QueryProperty (nameof(IdCharacter),nameof(IdCharacter))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleViewPage : ContentPage
    {
        private string IdCharacter;
        public DetalleViewPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //pasa al presentarse la pantalla
            int Id;
            int.TryParse(IdCharacter, out Id);
            var character = await CharacterServices.GetCharacter(Id);
            BindingContext = character;
        }
    }
}