using System;
using System.Collections.Generic;

namespace GolLabs.Domain
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHoraPartida { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}