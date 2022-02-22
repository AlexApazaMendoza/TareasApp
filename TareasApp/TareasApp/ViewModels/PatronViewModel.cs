using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TareasApp.ViewModels
{
    public class PatronViewModel : BaseViewModel
    {

        #region Variable
        private string _Texto;

        #endregion

        #region Constructor
        public PatronViewModel(INavigation navigation)
        {
            Navigation = navigation;    //comportamiento de Navigation
        }
        #endregion

        #region Objetos
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region Procesos
        public async Task ProcesoAsincrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region Comandos
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsincrono());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        #endregion

    }
}
