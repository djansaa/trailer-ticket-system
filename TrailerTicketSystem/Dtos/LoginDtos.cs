using System.ComponentModel.DataAnnotations;

namespace TrailerTicketSystem.Dtos
{
    public record LoginDto(
        [Required, Display(Name = "User Name")]
        string UserName,

        [Required, DataType(DataType.Password)]
        string Password
    );
}
