using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    
   // [QueryProperty (nameof(),nameof()]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleViewPage : ContentPage
    {
        public DetalleViewPage()
        {
            InitializeComponent();
        }
    }
}