import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private httpClient: HttpClient) { }

  getArticles(
    userId: string,
    onSuccess,
    onFail = (reason) => console.log(reason)) {
      var url = "http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/api/news/getArticles/" + userId;
      var req = this.httpClient.get(url);
      var promise = req.toPromise();

      promise.then(
        onSuccess,
        onFail
      );
    }
  }