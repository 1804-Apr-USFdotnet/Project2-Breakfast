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
    var zipcode = "33617";
    this.weatherService.getWeatherByZipcode(
      zipcode, 
      () => { if (this.weather != undefined) { this.getIcon(this.weather.condition) } },
      (response) => {this.weather = response}
    );
  }

  getWeather() {
    this.weatherService.getWeatherByZipcode(
      this.searchZip, 
      () => { if (this.weather != undefined) { this.getIcon(this.weather.condition) } },
      (response) => {this.weather = response;
    });
  }

  getIcon(icon: string) {

    if (Number(icon.substring(0,2)) > 3){
      icon = icon.substring(0,2);
    }

    switch (icon) {
      case "01d":
          this.iconClass = "wi wi-day-sunny";
          break;
      case "02d":
          this.iconClass = "wi wi-day-sunny-overcast";
          break;
      case "01n":
          this.iconClass = "wi wi-night-clear";
          break;
      case "02n":
          this.iconClass = "wi wi-night-partly-cloudy";
          break;
      case "03":
          this.iconClass = "wi wi-cloud";
          break;
      case "04":
          this.iconClass = "wi wi-cloudy";
          break;
      case "09":
          this.iconClass = "wi wi-showers";
          break;
      case "10":
          this.iconClass = "wi wi-rain";
          break;
      case "11":
          this.iconClass = "wi wi-thunderstorm";
          break;
      case "13":
          this.iconClass = "wi wi-snow";
          break;
      case "50":
          this.iconClass = "wi wi-fog";
          break;
    }
  }
}
