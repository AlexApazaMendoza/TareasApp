using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TareasApp.Models;
using Xamarin.Forms;

namespace TareasApp.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        #region Variable
        private string _Id;
        private string _Titulo;
        private string _FechaHora;
        private DateTime _Fecha;
        private string _Prioridad;
        private string _FechaActual;

        private TimeSpan _Hora;

        private List<Tarea> _Tareas;


        #endregion

        #region Constructor
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;    //comportamiento de Navigation
            FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            MostrarTareas();
        }
        #endregion

        #region Objetos
        public string Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { SetValue(ref _Titulo, value); }
        }
        public string FechaHora
        {
            get { return _FechaHora; }
            set { SetValue(ref _FechaHora, value); }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value;
                OnpropertyChanged(Fecha.ToString());
                FechaHora = Fecha.ToString("dd/MM/yyyy") + " " + Hora.ToString();
            }
        }

        public TimeSpan Hora
        {
            get { return _Hora; }
            set
            {
                _Hora = value;
                OnpropertyChanged(Hora.ToString());
                FechaHora = Fecha.ToString("dd/MM/yyyy") + " " + Hora.ToString();
            }
        }

        public string FechaActual
        {
            get { return _FechaActual; }
            set { SetValue(ref _FechaActual, value); }
        }
        public string Prioridad
        {
            get { return _Prioridad; }
            set { SetValue(ref _Prioridad, value); }
        }
        public List<Tarea> Tareas
        {
            get { return _Tareas; }
            set { SetValue(ref _Tareas, value); }
        }
        #endregion

        #region Procesos
        public async Task InsertarTarea()
        {
            if ( (Prioridad == "" || (Prioridad == null)) || (FechaHora == "" || (FechaHora == null)) || ((Titulo == "") || (Titulo==null)) )
            {
                await DisplayAlert("Advertencia", "Complete todos los datos", "Ok");
            }
            else
            {
                Tarea tarea = new Tarea
                {
                    Titulo = Titulo,
                    FechaHora = FechaHora,
                    Prioridad = Prioridad
                };
                Titulo = "";
                FechaHora = "";
                Prioridad = "";
                await App.SQLiteDB.SaveTarea(tarea);
                await MostrarTareas();
            }

        }
        public async Task MostrarTareas()
        {
            //var tareas = await App.SQLiteDB.GetTareas();
            var tareas = await App.SQLiteDB.GetTareasOrdered();
            if (tareas != null)
            {
                Tareas = tareas;
            }
        }

        public async Task EliminarTarea()
        {
            Tarea tarea = new Tarea
            {
                Id = Convert.ToInt32(Id),
                Titulo = Titulo,
                FechaHora = FechaHora,
                Prioridad = Prioridad
            };
            Id = "";
            Titulo = "";
            FechaHora = "";
            Prioridad = "";
            if (tarea.Id != 0)
            {
                await App.SQLiteDB.DeleteTarea(tarea);
                await DisplayAlert("Advertencia", "Se eliminó la tarea correctamente", "Ok");
                await MostrarTareas();
            }
            else
            {
                await DisplayAlert("Advertencia", "Debe seleccionar la tarea a eliminar.", "Ok");
            }
        }

        public async Task ActualizarTarea()
        {
            Tarea tarea = new Tarea
            {
                Id = Convert.ToInt32(Id),
                Titulo = Titulo,
                FechaHora = FechaHora,
                Prioridad = Prioridad
            };
            Id = "";
            Titulo = "";
            FechaHora = "";
            Prioridad = "";
            if (tarea.Id != 0)
            {
                await App.SQLiteDB.UpdateTarea(tarea);
                await DisplayAlert("Advertencia", "Se actualizó la tarea correctamente", "Ok");
                await MostrarTareas();
            }
            else
            {
                await DisplayAlert("Advertencia", "Debe seleccionar la tarea a actualizar.", "Ok");
            }
        }
        public void Limpiar()
        {
            Id = "";
            Titulo = "";
            FechaHora = "";
            Prioridad = "";
        }
        #endregion

        #region Comandos
        public ICommand InsertarTareaAsyncCommand => new Command(async () => await InsertarTarea());
        public ICommand EliminarTareaAsyncCommand => new Command(async () => await EliminarTarea());
        public ICommand ActualizarTareaAsyncCommand => new Command(async () => await ActualizarTarea());
        public ICommand LimpiarCommand => new Command(Limpiar);
        #endregion
    }
}
