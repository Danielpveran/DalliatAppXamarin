using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace DBSQlite.Models
{

    public class Estudiante
    {

[PrimaryKey, AutoIncrement]

public int EstudianteId { get; set; }
[MaxLength(50)]

public string Apellido { get; set; }
[MaxLength(50)]

public string Nombre { get; set; }
[MaxLength(20)]

public string Genero { get; set; }
[MaxLength(100)]

public string Email { get; set; }

public int Edad { get; set; }
    }
}
