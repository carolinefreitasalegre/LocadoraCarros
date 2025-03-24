namespace Application.Dtos.Response.ResponseRental
{
    public class CreateRentalResponse
    {
        public Guid CarroId { get; set; }

        public Guid ClienteId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFimPrevista { get; set; }
        public DateTime? DataFimReal { get; set; }

        public decimal PrecoDiaria { get; set; }
        public int DiasAlugados { get; set; }
    }
}
