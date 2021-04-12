using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command; //Cambiar para que no de error con la otra libreria

namespace MyApp.ViewModels
{
    public class TestPageViewModel: ViewModelBase  //heredar de inotify
    {
        #region Propiedades
        private string mensaje;
        public string Mensaje { get => mensaje; set => SetProperty(ref mensaje, value); }

        private ICommand cmdIncrementar;

        public ICommand CmdIncrementar
        {
            get
            {
                if (cmdIncrementar == null)
                {
                    cmdIncrementar = new Command(PerformCmdIncrementar);
                }

                return cmdIncrementar;
            }
        }
        private ICommand cmdActivityIndicatorOn;

        public ICommand CmdActivityIndicatorOn
        {
            get
            {
                if (cmdActivityIndicatorOn == null)
                {
                    cmdActivityIndicatorOn = new Command(PerformCmdActivityIndicatorOn);
                }

                return cmdActivityIndicatorOn;
            }
        }
        private ICommand cmdActivityIndicatorOff;

        public ICommand CmdActivityIndicatorOff
        {
            get
            {
                if (cmdActivityIndicatorOff == null)
                {
                    cmdActivityIndicatorOff = new Command(PerformCmdActivityIndicatorOff);
                }

                return cmdActivityIndicatorOff;
            }
        }
        private ICommand cmdMostrarMensaje;

        public ICommand CmdMostrarMensaje
        {
            get
            {
                if (cmdMostrarMensaje == null)
                {
                    cmdMostrarMensaje = new AsyncCommand(PerformCmdMostrarMensajeAsync);//libreria para los asincronos
                }

                return cmdMostrarMensaje;
            }
        }

        #endregion
        //public string Mensaje { get; set; }
        //public ICommand CmdIncrementar { get; set; }
        // private ICommand cmdIncrementar;
        //public ICommand CmdIncrementar
        //{
        //  get { return cmdIncrementar; }
        //set { cmdIncrementar = value;
        //  OnPropertyChanged();
        //}
        //}

        //private string mensaje;
        //public string Mensaje
        //{
        //  get { return mensaje; }
        //  set
        //    {
        //        if (value == mensaje)
        //            return;
        // mensaje = value;
        //  OnPropertyChanged();
        //}
        // }
        //heredar de inotify
        // private void OnPropertyChanged([CallerMemberName] string propertyName=null)
        //{
        //   if (PropertyChanged != null)
        //      {
        //      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //   }
        // }

        private int count = 0;
        //heredar de inotify
        //public event PropertyChangedEventHandler PropertyChanged;

        public TestPageViewModel()
        {
           // mensaje = "Hola";
            Mensaje = "Hola";
            // CmdIncrementar = new Command(() =>
            //  {
            //    count++;
            //  Mensaje = $"Haz Clickeado {count} veces(s)";
            // });
            //es lo mismo que el de abajo
            //CmdIncrementar = new Command(OnIncrementar);
        }

       // private void OnIncrementar()
        //{
          //  count++;
            //Mensaje = $"Haz Clickeado {count} veces(s)";
        //}

        private void PerformCmdIncrementar()
        {
            count++;
            Mensaje = $"Haz Clickeado {count} veces(s)";
        }

       
        private void PerformCmdActivityIndicatorOn()
        {
            IsBusy = true;
        }

    

        private void PerformCmdActivityIndicatorOff()
        {
            IsBusy = false;
        }



        private async Task PerformCmdMostrarMensajeAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Hola","Mensaje de prueba","OK"); //hilos para esperar a el sigueinte mensaje y no se interpongan
            await Application.Current.MainPage.DisplayAlert("Hola 2", "Mensaje de prueba 2", "OK");
        }
    }
}
