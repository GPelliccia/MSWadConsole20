using System.ComponentModel;
using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel.Data
{
    public class ParameterData
    {
        public string Codice
        {
            get
            {
                if (!string.IsNullOrEmpty(_Codice))
                    return _Codice.ToLower();
                else
                    return _Codice;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _Codice = value.ToLower();
                else _Codice = value;
            }
        }
        private string _Codice;
        public string Valore { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
        public bool Obbligatorio { get; set; }
        public Tipo TipoParametro { get; set; }
        public UnitaMisura UnitaDiMisura { get; set; }
        public enum Tipo
        {
            [EnumMember]
            [Description("S")]
            ALFANUMERICO,
            [EnumMember]
            [Description("N")]
            NUMERICO,
            [EnumMember]
            [Description("B")]
            BOOLEANO,
            [EnumMember]
            [Description("D")]
            DATA,
            [EnumMember]
            [Description("X")]
            SCONOSCIUTO
        }

        [DataContract(Namespace = "http://WSWad.WCF")]
        public enum UnitaMisura
        {
            [EnumMember]
            [Description("T")]
            TERA,
            [EnumMember]
            [Description("G")]
            GIGA,
            [EnumMember]
            [Description("M")]
            MEGA,
            [EnumMember]
            [Description("B")]
            BYTE,
            [EnumMember]
            [Description("S")]
            SECONDO,
            [EnumMember]
            [Description("MS")]
            MILLISECONDO,
            [EnumMember]
            [Description("X")]
            SCONOSCIUTO
        }
    }
}
