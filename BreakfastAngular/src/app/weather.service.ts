import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private httpClient: HttpClient) { }

  getWeatherByZipcode(
    zipcode: string,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
      var url = "http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/api/weather/get/" + zipcode;
      var req = this.httpClient.get(url);
      var promise = req.toPromise();

      promise.then(
        onSuccess,
        onFail
      );
    }
  }
