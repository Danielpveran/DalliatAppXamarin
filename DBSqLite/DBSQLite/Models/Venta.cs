using System;
using SQLite;

namespace DBSQlite.Models
{
    public class Venta
    {
        [PrimaryKey, AutoIncrement]
        public int VentaId { get; set; }

        [MaxLength(50)]
        public string ApellidoVendedor { get; set; }

        [MaxLength(50)]
        public string NombreVendedor { get; set; }

        [MaxLength(100)]
        public string ProductoVendido { get; set; }

        public int CantidadVendida { get; set; }

        public DateTime FechaVenta { get; set; }
    }
}
