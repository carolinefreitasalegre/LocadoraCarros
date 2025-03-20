namespace Domain.Entities.Cars
{
    public class Cars
    {
        public Cars(string model, int year, int dors, string marca, string placa, string cor, int quilometragem, string cambio, string combustivel, int capacidade, bool arCondicionado, bool disponivel, decimal precoDiaria, string status, DateTime? dataUltimaManutencao)
        {
            Model = model;
            Year = year;
            Dors = dors;
            Marca = marca;
            Placa = placa;
            Cor = cor;
            Quilometragem = quilometragem;
            Cambio = cambio;
            Combustivel = combustivel;
            Capacidade = capacidade;
            ArCondicionado = arCondicionado;
            Disponivel = disponivel;
            PrecoDiaria = precoDiaria;
            Status = status;
            DataUltimaManutencao = dataUltimaManutencao;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Model { get; set; }
        public int Year { get; set; }
        public int Dors { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int Quilometragem { get; set; }
        public string Cambio { get; set; }
        public string Combustivel { get; set; }
        public int Capacidade { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Disponivel { get; set; }
        public decimal PrecoDiaria { get; set; }
        public string Status { get; set; }
        public DateTime? DataUltimaManutencao { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;

    }
}

