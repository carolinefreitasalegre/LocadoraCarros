using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities.Cars
{
    public class Cars
    {
        public Cars(string model, int year, int dors, string marca, string placa, string cor, int quilometragem, string cambio, string combustivel, int capacidade, bool arCondicionado, bool disponivel, decimal precoDiaria, StatusCarro status, DateTime? dataUltimaManutencao)
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

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Dors { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        public int Quilometragem { get; set; }
        [Required]
        public string Cambio { get; set; }
        [Required]
        public string Combustivel { get; set; }
        [Required]
        public int Capacidade { get; set; }
        [Required]
        public bool ArCondicionado { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoDiaria { get; set; }
        [Required]
        public StatusCarro Status { get; set; }

        public DateTime? DataUltimaManutencao { get; set; }
        public DateTime RegisterTime { get; set; } = DateTime.Now;

    }
}

