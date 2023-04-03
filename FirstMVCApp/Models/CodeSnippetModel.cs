namespace FirstMVCApp.Models
{

    using System.ComponentModel.DataAnnotations;

    public class CodeSnippetModel
    {
        [Key]
        public Guid IDCodeSnippet { get; set; }
        [StringLength(100, ErrorMessage = "Titlul poate sa contina maxim 100 caractere")]
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IDMember { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Numarul reviziei trebuie sa fie pozitiv")]
        public int Revision { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateTimeAdded { get; set; }

    }

}