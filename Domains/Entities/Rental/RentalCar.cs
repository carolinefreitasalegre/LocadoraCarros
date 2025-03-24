using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities.Locacoes
{
    public class RentalCar
    {
        public RentalCar(Guid carroId, Guid clienteId, DateTime dataInicio, DateTime dataFimPrevista, DateTime? dataFimReal, decimal precoDiaria, int diasAlugados)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            DataInicio = dataInicio;
            DataFimPrevista = dataFimPrevista;
            DataFimReal = dataFimReal;
            PrecoDiaria = precoDiaria;
            DiasAlugados = diasAlugados;
        }

        public RentalCar(Guid carroId, Guid clienteId, DateTime dataInicio, DateTime dataFimPrevista, DateTime? dataFimReal, decimal precoDiaria, int diasAlugados, decimal valorTotal, StatusLocacao status)
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

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public Guid CarroId { get; set; } 

        public Guid ClienteId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; } 
        [Required]
        public DateTime DataFimPrevista { get; set; } 
        [Required]
        public DateTime? DataFimReal { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoDiaria { get; set; }
        [Required]
        public int DiasAlugados { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        public StatusLocacao Status { get; set; } 
    }

}
