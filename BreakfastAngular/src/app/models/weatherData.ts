import { ForecastDay } from '../models/ForecastDay';

export class WeatherData
{
  city: string;
  country: string;
  description: string;
  windSpeed: number;
  temperature: number;
  temperatureType: string;
  humidity: number;
  cloudiness: number;
  condition: string;
  forecastDays: ForecastDay[];
}