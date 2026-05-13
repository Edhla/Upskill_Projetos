using System;
using System.Collections.Generic;
using System.Text;

namespace LibGerenciadorOficina.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int Ano { get; set; }
        public DateTime UltimaInspecao { get; set; }
        public bool Estado { get; set; }
    }
}
