namespace Breakfast.Business.Weather.Models
{
    public class WeatherSettings
    {
        public int id { get; set; }
        public bool enabled { get; set; } = true;
        public bool farenheit { get; set; } = true;
        public bool windSpeed { get; set; } = false;  //rootObject.wind.speed
        public bool humidity { get; set; } = true;    //rootObject.main.humidity
        public bool cloudiness { get; set; } = false; //rootObject.clouds.all
        public string location { get; set; }

        //convert to domain object
        static public explicit operator WeatherSettings(Data.Models.WeatherSettings wsData)
        {
            WeatherSettings ws = new WeatherSettings()
            {
                id = wsData.Pk_WeatherId,
                enabled = wsData.Enabled,
                farenheit = wsData.Farenheit,
                windSpeed = wsData.WindSpeed,
                humidity = wsData.Humidity,
                cloudiness = wsData.Cloudiness,
                location = wsData.Location
            };

            return ws;
        }

        //convert to entity object
        static public explicit operator Data.Models.WeatherSettings(WeatherSettings ws)
        {
            Data.Models.WeatherSettings wsData = new Data.Models.WeatherSettings()
            {
                Pk_WeatherId = ws.id,
                Enabled = ws.enabled,
                Farenheit = ws.farenheit,
                WindSpeed = ws.windSpeed,
                Humidity = ws.humidity,
                Cloudiness = ws.cloudiness,
                Location = ws.location
            };

            return wsData;
        }
    }
}
