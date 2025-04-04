using System.ComponentModel.DataAnnotations.Schema;

namespace MSWadConsole20.Repository.DataModel.Request
{
    public class ReferentRequest
    {
        public int ReferenteId { get; set; }
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public string? Matricola { get; set; }
        public string? CodiceFiscale { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Tipo { get; set; }
        public string? Utenza { get; set; }
        public int? ConDisabilitati { get; set; }
        public DateTime? DataInizioAttivazione { get; set; }

    }
}
