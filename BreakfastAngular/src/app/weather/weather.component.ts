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
  weather: WeatherData

  constructor(
    private route: ActivatedRoute,
    private weatherService: WeatherService
  ) { }

  ngOnInit() {
    //var zipcode = this.route.snapshot.paramMap.get("zipcode");
    var zipcode = "33617";
    this.weatherService.getWeatherByZipcode(
      zipcode, 
      (response) => {this.weather = response}
    );
  }

}
