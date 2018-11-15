using DemoSQLite.Cells;
using DemoSQLite.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(3, 20, 3, 3);
                    break;
                case Device.Android:
                    Padding = new Thickness(3, 10, 3, 3);
                    break;
                case Device.WPF:
                    Padding = new Thickness(3, 10, 3, 3);
                    break;
                default:
                    Padding = new Thickness(3, 10, 3, 3);
                    break;
            }

            listaListView.ItemTemplate = new DataTemplate(typeof(EmpleadoCell));
            listaListView.ItemTapped += listaListView_ItemTapped;
            agregarButton.Clicked += agregarButton_Clicked;

            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetEmpleados();
            }
        }

        private async void listaListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new EditPage(e.Item as Empleado));
        }

        private async void agregarButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
                //DisplayAlert("Error", "Debe ingresar nombres", "Aceptar").Wait(); //Esta Instruccion es mejor para Windows Phone
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salaryEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar salario", "Aceptar");
                salaryEntry.Focus();
                return;
            }

            Empleado empleado = new Empleado
            {
                Nombres = nombresEntry.Text,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Salario = decimal.Parse(salaryEntry.Text),
                Activo = activoSwitch.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.InsertEmpleado(empleado);
                listaListView.ItemsSource = datos.GetEmpleados();
            }

            nombresEntry.Text = string.Empty;
            apellidosEntry.Text = string.Empty;
            salaryEntry.Text = string.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            activoSwitch.IsToggled = true;

            await DisplayAlert("Confirmación", "Empleado Agredado", "Aceptar");
        }
    }
}