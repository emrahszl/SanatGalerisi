using System.ComponentModel.DataAnnotations;

namespace GaleriAPI.Dtos
{
    public class PutTabloDto
    {
        [Required(ErrorMessage = "Ressam alanı zorunludur.")]
        public string Ressam { get; set; } = null!;

        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        public DateTime ResminYapilmaTarihi { get; set; }
    }
}
