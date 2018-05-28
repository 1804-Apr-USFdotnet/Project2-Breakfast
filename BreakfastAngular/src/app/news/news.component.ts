import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NewsService } from '../news.service';
import { Article } from '../models/Article';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  articles: Article[];
  userId: string;
  constructor(private route: ActivatedRoute, private newsService: NewsService) { 
  }

  ngOnInit() {
    this.userId = "breakfast13";
    this.getArticles();
  }

  getArticles() {
    this.newsService.getArticlesById(
        this.userId, 
        (response) => {
            this.articles = response;
        }
    );
  }

}
