import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public celebrities: Celebrity[];
  baseUrl: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    http.get<Celebrity[]>(baseUrl + 'Celebrities/GetAllCelebritiesAsync').subscribe(result => {
      this.celebrities = result;
    }, error => {
      alert("An error occurred , plese try leater\n" +"Error details: "+ error.error.Message)
      console.error(error)

    }
    );
  }
  deleteCelebrity(celebrity) {
    this.http.post<Celebrity[]>(this.baseUrl + 'Celebrities/RemoveCelebrity', celebrity).subscribe(result => {
      this.celebrities = result;
    },
      error => {
        alert("An error occurred , plese try leater\n" + "Error details: " + error.error.Message)
        console.error(error)

      }
    );
  }
  fetchCelebrities() {
    this.celebrities= null;
    this.http.get<Celebrity[]>(this.baseUrl + 'Celebrities/GetAllCelebritiesAsync').subscribe(result => {
      this.celebrities = result;
    },
      error => {
        alert("An error occurred , plese try leater\n" + "Error details: " + error.error.Message)
        console.error(error)

      }
    );
  }
}
interface Celebrity {
  name: string;
  birthDate: Date;
  gender: string;
  image: string;
  jobTitle: string[];
}
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
