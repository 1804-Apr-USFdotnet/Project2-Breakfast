import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherData } from '../models/WeatherData';
import { ForecastDay } from '../models/ForecastDay';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  weather: WeatherData;
  searchZip: string;
  iconClass = "";

  constructor(private route: ActivatedRoute, private weatherService: WeatherService) { 
    // this.weather.forecastDays = new Array<ForecastDay>(new ForecastDay({tempMin: 1, tempMax: 2}));
  }

  ngOnInit() {
    //var zipcode = this.route.snapshot.paramMap.get("zipcode");
    this.searchZip = "33617";
    this.getWeather();
    // this.weatherService.getWeatherByZipcode(
    //   zipcode, 
    //   (response) => {this.weather = response, this.getIcon(this.weather.condition)}
    // );
  }

  getWeather() {
    this.weatherService.getWeatherByZipcode(
        this.searchZip, 
        (response) => {
            this.weather = response, 
            this.weather.condition = this.getIcon(this.weather.condition),
            this.weather.forecastDays.forEach(function(part, index, forecastArray) {
                forecastArray[index] = this.getIcon(forecastArray[index]);
          });
        }
    );
  }

  getIcon(icon: string) {

    if (Number(icon.substring(0,2)) > 3){
      icon = icon.substring(0,2);
    }

    switch (icon) {
      case "01d":
          return "wi wi-day-sunny";
      case "02d":
          return "wi wi-day-sunny-overcast";
      case "01n":
          return "wi wi-night-clear";
      case "02n":
          return "wi wi-night-partly-cloudy";          
      case "03":
          return "wi wi-cloud";   
      case "04":
          return "wi wi-cloudy";
      case "09":
          return "wi wi-showers";
      case "10":
          return "wi wi-rain";
      case "11":
          return "wi wi-thunderstorm";
      case "13":
          return "wi wi-snow";
      case "50":
          return "wi wi-fog";
    }
  }
}
