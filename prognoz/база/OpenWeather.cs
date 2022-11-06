using Newtonsoft.Json;
namespace Prognoz
{
    internal class OpenWeather
    {
        public Coord coord;
        public Weather[] weather;
        [JsonProperty("base")]
        public string Base;
        public Main main;
        public Wind wind;
        public Clouds clouds;
        public double dt;
        public sys sys;
        public int id;
        public string name;
        public double code;
    }
}
