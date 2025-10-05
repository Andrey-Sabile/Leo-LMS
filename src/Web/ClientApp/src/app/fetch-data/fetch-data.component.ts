import { Component } from '@angular/core';
import { WeatherForecastsClient, WeatherForecast } from '../web-api-client';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  standalone: true,
  imports: [DatePipe],
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private client: WeatherForecastsClient) {
    client.getWeatherForecasts().subscribe({
      next: result => this.forecasts = result,
      error: error => console.error(error)
    });
  }
}
