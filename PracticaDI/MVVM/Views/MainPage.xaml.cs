using PracticaDI.MVVM.Models;
using PracticaDI.MVVM.ViewModels;

namespace PracticaDI.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new DataViewModel();
    }

    private void OnTareaTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null)
        {
            var tarea = (Tarea)e.Item;
            var viewModel = (DataViewModel)BindingContext;
            viewModel.AgregarTareaCommand.Execute(tarea);
        }
    }
}