import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from "@angular/router";
import { WeatherComponent } from './weather/weather.component';
import { NewsComponent } from './news/news.component';
import { IndexComponent } from './index/index.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';

const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "weather", component: WeatherComponent },
  { path: "news", component: NewsComponent },
  { path: '',   redirectTo: '/index', pathMatch: 'full' }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  declarations: []
})
export class AppRoutingModule { }
