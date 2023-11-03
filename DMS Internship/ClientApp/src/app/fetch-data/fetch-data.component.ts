import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VehicleModel } from '../VehicleInfo';
import { VehicleService } from '../vehicle.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public vehicleModels: VehicleModel[] = [];
  searchTerm: string = '';
  //searchResults: VehicleInfo[] = [];
 // filteredVehicles: VehicleInfo[] = [];

  constructor(private vehicleService: VehicleService) { }

  //search() {
  //  if (this.searchTerm) {
  //    this.filteredVehicles = this.vehicleInfo.filter((vehicle) =>
  //      vehicle.Make.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
  //      vehicle.Model.toLowerCase().includes(this.searchTerm.toLowerCase())
  //    );
  //  } else {
  //    this.filteredVehicles = this.vehicleInfo;
  //  }
  //}

  ngOnInit() {
    this.vehicleService.getAllVehicles().subscribe(
      (data) => {
        this.vehicleModels = data;
        //this.filteredVehicles = data;
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

}
