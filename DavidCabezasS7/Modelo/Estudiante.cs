using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DavidCabezasS7.Modelo
{
    public class Estudiante
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usurio { get; set; }

        [MaxLength(50)]
        public string Contrasenia { get; set; }

    }
}
