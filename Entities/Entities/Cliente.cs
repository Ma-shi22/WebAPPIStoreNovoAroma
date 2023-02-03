using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Cliente
    {
        public Cliente() { }
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public int IdTipoCliente { get; set; }
        public string Empresa { get; set; }
        public string Sector { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
