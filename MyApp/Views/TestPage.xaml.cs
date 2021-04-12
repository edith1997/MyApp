using MyApp.ViewModels;
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
    public partial class TestPage : ContentPage
    {

        public TestPage()
        {
            InitializeComponent();
           // mensaje = "hola";
          // BindingContext = new TestPageViewModel();
        }

       // private void Button_Clicked(object sender, EventArgs e)
       // {
         //   count++;
           // Mensaje = $"Haz Clickeado {count} veces(s)";

         

            
      //  }
    }
}