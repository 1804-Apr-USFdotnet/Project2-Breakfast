import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherData } from '../models/WeatherData';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  weatherData: WeatherData
  constructor(
    private route: ActivatedRoute,
    private weatherService: WeatherService,
  ) { }

  ngOnInit() {
    var zipcode = this.route.snapshot.paramMap.get("zipcode");
    this.weatherService.getWeatherByZipcode(
      zipcode, 
      (response) => {this.weatherData = response}
    );
  }

}
