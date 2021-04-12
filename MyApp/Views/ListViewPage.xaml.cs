using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
        }

       

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //evita el fondo naranja
            ((ListView)sender).SelectedItem = null;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //para ver cual se sellecciono
            Character character = ((ListView)sender).SelectedItem as Character;
            if (character == null)
                return;
            await DisplayAlert("Personaje Seleccionado", character.Name, "OK");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            Character character = ((MenuItem)sender).BindingContext as Character;
            if (character == null)
                return;
            await DisplayAlert("Añadido a Favorito", character.Name, "Ok");
        }
    }
}