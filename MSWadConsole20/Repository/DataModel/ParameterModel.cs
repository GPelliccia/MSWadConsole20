using System.ComponentModel;
using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class ParameterModel
    {
        public String Codice
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
                    this._Codice = value.ToLower();
                else this._Codice = value;
            }
        }
        private string _Codice;
        public String Valore { get; set; }
        public String Descrizione { get; set; }
        public String Note { get; set; }
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
