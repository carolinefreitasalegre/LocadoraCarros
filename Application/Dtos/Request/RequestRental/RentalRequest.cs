using Domain.Enums;

namespace Application.Dtos.Request.RequestRental
{
    public class RentalRequest
    {
        public Guid CarroId { get; set; }

        public Guid ClienteId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFimPrevista { get; set; }
        public DateTime? DataFimReal { get; set; }

        public decimal PrecoDiaria { get; set; }
        public int DiasAlugados { get; set; }

        public StatusLocacao Status { get; set; }
    }
}
