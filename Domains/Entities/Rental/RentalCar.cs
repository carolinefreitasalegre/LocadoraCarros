namespace Domain.Entities.Locacoes
{
    public class RentalCar
    {
        public RentalCar(Guid carroId, Guid clienteId, DateTime dataInicio, DateTime dataFimPrevista, DateTime? dataFimReal, decimal precoDiaria, int diasAlugados, decimal valorTotal, string status)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFimPrevista = dataFimPrevista;
            DataFimReal = dataFimReal;
            PrecoDiaria = precoDiaria;
            DiasAlugados = diasAlugados;
            ValorTotal = valorTotal;
            Status = status;
        }

        public Guid Id { get; set; } = Guid.NewGuid(); 
        public Guid CarroId { get; set; } 
        public Guid ClienteId { get; set; } 
        public DateTime DataInicio { get; set; } 
        public DateTime DataFimPrevista { get; set; } 
        public DateTime? DataFimReal { get; set; } 
        public decimal PrecoDiaria { get; set; } 
        public int DiasAlugados { get; set; } 
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } 
    }

}
