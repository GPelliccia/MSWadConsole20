using System.ComponentModel.DataAnnotations.Schema;

namespace MSWadConsole20.Repository.DataModel.Request
{
    public class ReferentRequest
    {
        public int ReferenteId { get; set; }
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public string? Utenza { get; set; }
        public int? ConDisabilitati { get; set; }
    }
}
