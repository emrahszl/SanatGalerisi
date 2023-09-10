using System.ComponentModel.DataAnnotations;

namespace GaleriAPI.Dtos
{
    public class PostTabloDto
    {
        [Required(ErrorMessage = "Ressam alanı zorunludur.")]
        public string Ressam { get; set; } = null!;
        
        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime ResminYapilmaTarihi { get; set; }
    }
}
