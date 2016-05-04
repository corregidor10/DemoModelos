﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoModelos.Alumnos
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class Alumno
    {
       
        public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
