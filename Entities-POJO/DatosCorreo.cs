﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class DatosAuxiliares : BaseEntity
    {
        public string Correo { get; set; }
        public string NombreEmpresa { get; set; }

        public DatosAuxiliares()
        {

        }

    }
}
