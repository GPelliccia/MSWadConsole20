using System.ComponentModel.DataAnnotations.Schema;

namespace MSWadConsole20.Repository.DataModel
{
    public class ReferenteModel
    {
        public int ReferenteId { get; set; }
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public string? Matricola { get; set; } //MATRICOLA  ,   VARCHAR(8) null       
        public string? CodiceFiscale { get; set; } //CODFIS  ,   VARCHAR(16) null      
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public char Tipo { get; set; } //ISDIRIGENTE    CHAR(1) null
        public string? Utenza { get; set; }
        public DateTime? DataInizioAttivazione { get; set; }
        public DateTime? DataFineAttivazione { get; set; }
        public bool FlagDirigente { get; set; }
        [NotMapped]
        public bool ConDisabilitati { get; set; }
    }
}
