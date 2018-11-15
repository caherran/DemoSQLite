using DemoSQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        private Empleado empleado;

		public EditPage (Empleado empleado)
		{
			InitializeComponent ();
            this.empleado = empleado;

            actualizarButton.Clicked += actualizarButton_Clicked;
            borrarButton.Clicked += borrarButton_Clicked;

            nombresEntry.Text = empleado.Nombres;
            apellidosEntry.Text = empleado.Apellidos;
            salaryEntry.Text = empleado.Salario.ToString();
            fechaContratoDatePicker.Date = empleado.FechaContrato;
            activoSwitch.IsToggled = empleado.Activo;
        }

        private async void borrarButton_Clicked(object sender, EventArgs e)
        {
            var respuesta = await DisplayAlert("Confirmación", "¿Desea borrar el empleado?", "Si", "No");
            if (!respuesta) return;

            using (var datos = new DataAccess())
            {
                datos.DeleteEmpleado(empleado);
            }
            await DisplayAlert("Confirmación", "Empleado borrado correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }

        private async void actualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
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

            empleado.Nombres = nombresEntry.Text;
            empleado.Apellidos = apellidosEntry.Text;
            empleado.Salario = decimal.Parse(salaryEntry.Text);
            empleado.FechaContrato = fechaContratoDatePicker.Date;
            empleado.Activo = activoSwitch.IsToggled;

            using (var datos = new DataAccess())
            {
                datos.UpdateEmpleado(empleado);
            }

            await DisplayAlert("Confirmación", "Empleado actualizado correctamente", "Aceptar");
            await Navigation.PushAsync(new HomePage());
        }
    }
}