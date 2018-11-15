using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IDEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaContrato { get; set; }
        public string FechaContratoEditado { get { return FechaContrato.ToShortDateString(); } }
        public decimal Salario { get; set; }
        public string SalarioEditado { get { return string.Format("{0:C}", Salario); }  }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", IDEmpleado, Nombres, Apellidos, FechaContrato, Salario, Activo);
        }
    }
}
