using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PracticaDI.MVVM.Models;

namespace PracticaDI.MVVM.ViewModels
{
    public class DataViewModel
    {
        public ObservableCollection<Tarea> Tareas { get; set; } = new();

        private Tarea _tareaSeleccionada;
        public Tarea TareaSeleccionada
        {
            get => _tareaSeleccionada;
            set
            {
                _tareaSeleccionada = value;
                OnPropertyChanged();
            }
        }

        public Command AgregarTareaCommand { get; }
        public Command EditarTareaCommand { get; }
        public Command EliminarTareaCommand { get; }

        public DataViewModel()
        {
            AgregarTareaCommand = new Command(AgregarTarea);
            EditarTareaCommand = new Command(EditarTarea);
            EliminarTareaCommand = new Command(EliminarTarea);
        }


        private void AgregarTarea()
        {
            Tareas.Add(new Tarea { Nombre = "Nueva tarea", Completada = false });
        }
        private async void EditarTarea()
        {
            if (TareaSeleccionada == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, selecciona una tarea para editar.", "OK");
                return;
            }

            string nuevoNombre = await Application.Current.MainPage.DisplayPromptAsync(
                "Editar Tarea",
                "Ingresa el nuevo nombre de la tarea:",
                initialValue: TareaSeleccionada.Nombre);

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                TareaSeleccionada.Nombre = nuevoNombre;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre de la tarea no puede estar vacío.", "OK");
            }
        }


        private async void EliminarTarea()
        {
            if (TareaSeleccionada != null)
                Tareas.Remove(TareaSeleccionada);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
