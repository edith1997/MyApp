
using Xamarin.Forms;
using MyApp.Views;

namespace MyApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AltaPersonajesViewPage), typeof(AltaPersonajesViewPage));
            Routing.RegisterRoute(nameof(DetalleViewPage), typeof(DetalleViewPage));


        }


    }
}
