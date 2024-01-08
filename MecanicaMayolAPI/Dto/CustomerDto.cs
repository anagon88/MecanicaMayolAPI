using System.ComponentModel.DataAnnotations;

namespace MecanicaMayolAPI.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
