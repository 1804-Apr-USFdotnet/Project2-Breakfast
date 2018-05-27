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

  constructor(private route: ActivatedRoute, private weatherService: WeatherService) { 
    // this.weather.forecastDays = new Array<ForecastDay>(new ForecastDay({tempMin: 1, tempMax: 2}));
  }

  ngOnInit() {
    //var zipcode = this.route.snapshot.paramMap.get("zipcode");
    var zipcode = "33617";
    this.weatherService.getWeatherByZipcode(
      zipcode, 
      (response) => {this.weather = response}
    );
  }

  getWeather() {
    this.weatherService.getWeatherByZipcode(
      this.searchZip, 
      (response) => {this.weather = response;
    });
  }

}
