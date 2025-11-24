using System.ComponentModel.DataAnnotations;

namespace TrailerTicketSystem.Dtos
{
    public record LoginDto(
        [property: Required]
        [property: Display(Name = "User Name")]
        string UserName,

        [property: Required]
        [property: DataType(DataType.Password)]
        string Password);
}
