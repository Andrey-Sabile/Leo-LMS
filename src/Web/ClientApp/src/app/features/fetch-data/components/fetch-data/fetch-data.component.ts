import { Component, inject } from '@angular/core';
import { WeatherForecastsClient, WeatherForecast } from '@app/data-access/api/api-client';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  standalone: true,
  imports: [DatePipe],
})
export class FetchDataComponent {
  private client = inject(WeatherForecastsClient);

  public forecasts: WeatherForecast[] = [];

  /** Inserted by Angular inject() migration for backwards compatibility */
  constructor(...args: unknown[]);

  constructor() {
    const client = this.client;

    client.getWeatherForecasts().subscribe({
      next: result => this.forecasts = result,
      error: error => console.error(error)
    });
  }
}
