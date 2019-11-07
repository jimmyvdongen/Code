using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SVORacing.Entiteiten
{
    public class Nieuws
    {
        public Nieuws()
        {
        }

        public Nieuws(int nieuwsid, string afbeelding, ImageSource source, string titel, string inleiding, string datum, string tekst)
        {
            this.nieuwsid = nieuwsid;
            this.afbeelding = afbeelding;
            this.source = source;
            this.titel = titel;
            this.inleiding = inleiding;
            this.datum = datum;
            this.tekst = tekst;

        }

        [JsonProperty(PropertyName = "nieuwsid")]
        public int nieuwsid { set; get; }

        [JsonProperty(PropertyName = "afbeelding")]
        public string afbeelding {
            set
            {
                byte[] Base64Stream = Convert.FromBase64String(value);
                source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            }
            get
            {
                return afbeelding;
            }
        }

        [JsonProperty(PropertyName = "source")]
        public ImageSource source { set; get; }

        [JsonProperty(PropertyName = "titel")]
        public string titel { set; get; }

        [JsonProperty(PropertyName = "inleiding")]
        public string inleiding { set; get; }

        [JsonProperty(PropertyName = "datum")]
        public string datum { set; get; }

        [JsonProperty(PropertyName = "tekst")]
        public string tekst { set; get; }
    }
}
