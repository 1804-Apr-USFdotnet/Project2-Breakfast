import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TrafficService {

  constructor(private httpClient: HttpClient) { }

  getTimeToWork(
    homePlaceId: string,
    workPlaceId: string,
    travelMode: string,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
      var url = "http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/api/traffic/get/"
       + homePlaceId + "/" +workPlaceId + "/" + travelMode + "/" + "1";
      var req = this.httpClient.get(url);
      var promise = req.toPromise();

      promise.then(
        onSuccess,
        onFail
      );
    }
  }
