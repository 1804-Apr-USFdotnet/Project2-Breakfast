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
  }

  ngOnInit() {
    this.searchZip = "33617";
    this.getWeather();
  }

  getWeather() {
    this.weatherService.getWeatherByZipcode(
        this.searchZip, 
        (response) => {
            this.weather = response
        }
    );
  }
}