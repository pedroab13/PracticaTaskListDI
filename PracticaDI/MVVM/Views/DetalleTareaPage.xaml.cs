using PracticaDI.MVVM.Models;
using PracticaDI.MVVM.ViewModels;

namespace PracticaDI.MVVM.Views;

public partial class DetalleTareaPage : ContentPage
{
    public DetalleTareaPage(Tarea tarea)
    {
        InitializeComponent();
        var viewModel = new DataViewModel();
        viewModel.TareaSeleccionada = tarea;
        BindingContext = viewModel;
    }
}