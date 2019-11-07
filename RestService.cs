using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SVORacing
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient
            {

            };
        }

        public async Task<List<Entiteiten.Nieuws>> verkrijgNieuws()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgnieuws.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Nieuws>>(content);
        }

        public async Task<List<Entiteiten.Nieuws>> verkrijgNieuwsPersoonlijk()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgnieuwspersoonlijk.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Nieuws>>(content);
        }

        public async Task<List<Entiteiten.Videos>> verkrijgVideos()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgvideos.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Videos>>(content);
        }

        public async Task<List<Entiteiten.Videos>> verkrijgVideos2019()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgvideos2019.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Videos>>(content);
        }

        public async Task<List<Entiteiten.VolgendeRace>> verkrijgVolgendeRace()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgvolgenderace.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.VolgendeRace>>(content);
        }

        public async Task<string> verkrijgLive()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijglive.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return content;
        }

        public async Task<List<Entiteiten.Spelers>> verkrijgTussenstand()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgtussenstand.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Spelers>>(content);
        }

        public async Task<List<Entiteiten.Albums>> verkrijgAlbums()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgalbums.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Albums>>(content);
        }

        public async Task<List<Entiteiten.Albums>> verkrijgAlbums2019()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgalbums2019.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Albums>>(content);
        }

        public async Task<List<Entiteiten.Uitslagen>> verkrijgUitslagen()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijguitslagen.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Uitslagen>>(content);
        }

        public async Task<List<Entiteiten.Fotos>> verkrijgFotos(string albumid)
        {
            var uri = new Uri("https://svoracing.app-mazing.nl/verkrijgfotos.php");
            var json = "{\"albumid\":\"" + albumid + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Fotos>>(result);
        }

        public async Task<ImageSource> verkrijgFoto(string fotoid)
        {
            var uri = new Uri("https://svoracing.app-mazing.nl/verkrijgfoto.php");
            var json = "{\"fotoid\":\"" + fotoid + "\"}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            byte[] Base64Stream = Convert.FromBase64String(result);
            var source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            return source;
        }

        public async Task<List<Entiteiten.Nieuws>> verkrijgHeader()
        {
            var response = await client.GetAsync("https://svoracing.app-mazing.nl/verkrijgheader.php").ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Entiteiten.Nieuws>>(content);
        }




    }
}
