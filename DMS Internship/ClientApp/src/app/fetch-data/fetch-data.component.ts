import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: DMS[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DMS[]>(baseUrl + 'DMS').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface DMS {

  vehicleId: bigint;

  Make: string;

  Model: string;

  Price: number;
}



