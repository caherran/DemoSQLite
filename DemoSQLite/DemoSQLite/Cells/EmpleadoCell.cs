using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoSQLite.Cells
{
    public class EmpleadoCell: ViewCell
    {
        public EmpleadoCell()
        {
            var idEmpleadoLabel = new Label
            {
                //Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                //TextColor = Color.White,
                HorizontalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.End
            };
            idEmpleadoLabel.SetBinding(Label.TextProperty, new Binding("IDEmpleado"));

            var nombresLabel = new Label
            {
                //Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                //TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 16,
                TextColor = Color.Navy
            };
            nombresLabel.SetBinding(Label.TextProperty, new Binding("Nombres"));

            var apellidosLabel = new Label
            {
                //Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                //TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 16,
                TextColor = Color.Navy
            };
            apellidosLabel.SetBinding(Label.TextProperty, new Binding("Apellidos"));

            var fechaContratoLabel = new Label
            {
                //Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                //TextColor = Color.White,
                HorizontalOptions = LayoutOptions.End
            };
            fechaContratoLabel.SetBinding(Label.TextProperty, new Binding("FechaContrato"));

            var salarioLabel = new Label
            {
                //Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                //TextColor = Color.White,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                HorizontalTextAlignment = TextAlignment.End
            };
            salarioLabel.SetBinding(Label.TextProperty, new Binding("SalarioEditado"));

            var activoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Start,
                IsEnabled = false
            };
            activoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var line1 = new StackLayout
            {
                Children = {idEmpleadoLabel, nombresLabel, apellidosLabel},
                Orientation = StackOrientation.Horizontal
            };

            var line2 = new StackLayout
            {
                Children = { fechaContratoLabel, salarioLabel, activoSwitch },
                Orientation = StackOrientation.Horizontal
            };

            View = new StackLayout
            {
                Children = { line1, line2 },
                Orientation = StackOrientation.Vertical
            };
        }
    }
}
