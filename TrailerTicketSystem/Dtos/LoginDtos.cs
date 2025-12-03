using System.ComponentModel.DataAnnotations;

namespace TrailerTicketSystem.Dtos
{
    public record LoginDto(
        [Required]
        string UserName,

        [Required, DataType(DataType.Password)]
        string Password
    );
}
