namespace Application.Dtos.Request.CreateCarRequest

{
    public class CreateCarRequest
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Dors { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int Quilometragem { get; set; }
        public string Cambio { get; set; } = string.Empty;
        public string Combustivel { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Disponivel { get; set; }
        public decimal PrecoDiaria { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? DataUltimaManutencao { get; set; }
    }
}
