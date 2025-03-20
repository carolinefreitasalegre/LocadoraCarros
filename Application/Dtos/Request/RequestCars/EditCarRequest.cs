using System.Text.Json.Serialization;
using Application.Dtos.Request.CreateCarRequest;


public class EditCarRequest : CreateCarRequest
{
    public Guid Id { get; set; }

    [JsonIgnore]
    public new string Placa { get; } = string.Empty;
}

