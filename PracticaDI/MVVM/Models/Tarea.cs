using System.ComponentModel;

namespace PracticaDI.MVVM.Models
{
    public class Tarea : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para ejecutar el evento cuando una propiedad cambia
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _nombre; 

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value) // Solo actualiza si el valor realmente cambia
                {
                    _nombre = value; // Asigna el nuevo valor a _nombre
                    OnPropertyChanged(nameof(Nombre)); // Notifica que el valor cambió
                }
            }
        }
            public bool Completada { get; set; }
        }

    }
