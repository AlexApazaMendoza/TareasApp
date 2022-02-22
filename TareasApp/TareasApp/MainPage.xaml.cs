using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasApp.Models;
using TareasApp.ViewModels;
using Xamarin.Forms;

namespace TareasApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);

            LvTareas.ItemSelected += LvTareas_ItemSelected;
        }

        private async void LvTareas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Tarea tarea = (Tarea)e.SelectedItem;
                TituloEntry.Text = tarea.Titulo.ToString();
                FechaHoraEntry.Text = tarea.FechaHora.ToString();
                Prioridad.Text = tarea.Prioridad.ToString();
                IdEntry.Text = tarea.Id.ToString();
            }
            await Task.Delay(500);
            LvTareas.SelectedItem = null;
        }
    }
}
