﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Producto
    {
        public Producto()
        {
            IsActive = true;
            IsPublic = true;
        }
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; private set; }

    }
}

