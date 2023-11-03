import { Component, Inject, OnInit } from '@angular/core';
import { VehicleModel, VehicleInfo } from '../VehicleInfo';
import { VehicleService } from '../vehicle.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public vehicleModels: VehicleModel[] = [];

  constructor(private vehicleService: VehicleService) {

  }

  ngOnInit() {
    this.vehicleService.getAllVehicles().subscribe(
      (data) => {
        this.vehicleModels = data;
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  vehicleId = { id: 0, series: ' ', priceInclusive: 0, price: 0 };

  searchVehicle() {
    const filteredVehicle: VehicleModel = {
      id: this.vehicleId.id,
      series: this.vehicleId.series,
      priceInclusive: this.vehicleId.priceInclusive,
      price: this.vehicleId.price
    }

    this.vehicleService.searchVehicles(filteredVehicle.id).subscribe(() => {

    });
  };

  updateVehicle() {

  }
}
