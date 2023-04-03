using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class AnnouncementModel
    {
        [Key]
        public Guid? IdAnnouncement { get; set; }

        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        [MaxLength(250, ErrorMessage = "Campul title poate contine maxim 250 caractere")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        [StringLength(250, ErrorMessage = "Campul Text poate contine maxim 250 caractere")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        public DateTime EventDate { get; set; }

        [StringLength(1000, ErrorMessage = "Acest camp poate contine maxim 1000 de caractere")]
        [Required(ErrorMessage = "Campul acesta este obligatoriu")]
        [MinLength(5, ErrorMessage = "Trebuie sa ai minim 5 caractere")]
        public string Tags { get; set; }
    }
}