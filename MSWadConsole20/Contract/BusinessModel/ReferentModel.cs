using System.ComponentModel.DataAnnotations.Schema;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class ReferentModel
    {
        public int Id { get; set; }
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public string? Matricola { get; set; }
        public string? CodiceFiscale { get; set; } 
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public char Tipo { get; set; } 
        public string? Utenza { get; set; }
        public DateTime? DataInizioAttivazione { get; set; }
        public DateTime? DataFineAttivazione { get; set; }
        public bool FlagDirigente { get; set; }
        public bool FlagDisabilitati { get; set; }
    }
}
