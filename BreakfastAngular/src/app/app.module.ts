import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { WeatherComponent } from './weather/weather.component';
import { AppRoutingModule } from './/app-routing.module';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { IndexComponent } from './index/index.component';
import { NewsComponent } from './news/news.component';
import { ContactComponent } from './contact/contact.component';
import { TrafficComponent } from './traffic/traffic.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    NavigationBarComponent,
    IndexComponent,
    NewsComponent,
    ContactComponent,
    TrafficComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
