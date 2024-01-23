import { Component, Inject, OnInit } from '@angular/core';
import { VehicleModel, VehicleInfo } from '../VehicleInfo';
import { VehicleService } from '../vehicle.service';
import { HttpClient } from '@angular/common/http';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  vehicID = new FormControl('');

  public vehicleModels: VehicleModel[] = [];

  constructor(private vehicleService: VehicleService, private http: HttpClient) {
    // ...
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

  vehicleWork = {id: 0 ,series: ' ', priceInclusive: 0, price: 0 }; //vehicleWork is a placeholder name doen't mean anything just trying to change the name from the one on VehicleInfo.ts

  updateVehicleForm(f: any) {
    console.log("I am here");
    console.log(f);
  }

  searchVehicles() {
    const filteredVehicle: VehicleModel = {
      id: this.vehicleWork.id,
      series: this.vehicleWork.series,
      priceInclusive: this.vehicleWork.priceInclusive,
      price: this.vehicleWork.price
    }; 

    this.vehicleService.searchVehicles(filteredVehicle.id).subscribe(() => {
      // ..
    });
  };

  //inputValues = { Make: ' ', Model: ' ', Price: 0 };

  //updateVehicle() {
  //  const updatedVehicle: VehicleModel = {
  //    id: 0,
  //    series: this.inputValues.Make + this.inputValues.Model,
  //    priceInclusive: this.inputValues.Price,
  //    price: this.inputValues.Price
  //  };
  //}


  //let vehicleData = {
  //  id: data.vehicleId,
  //  series: data.Make + data.Model,
  //  priceInclusive: data.Price,
  //  price: data.Prices

  /*vehicleUpdate = {Make: ' ', Model: ' ', Price: 0 };*/

  updateVehicle() {
    console.log("Blah blah blah");
    console.log(this.vehicID);
    //const updatedVehicle: VehicleModel = {
    //  id: 0,
    //  series: this.vehicleUpdate.Make + this.vehicleUpdate.Model,
    //  priceInclusive: this.vehicleUpdate.Price,
    //  price: this.vehicleUpdate.Price,
    //};

    //this.vehicleService.updateVehicle(this.vehicID, updatedVehicle)
    //  .subscribe(response => {
    //    console.log(response)
    //});
  };

  deleteVehicle() {
    this.vehicleService.deleteVehicle(this.vehicleWork.id)
      .subscribe(response => {
        console.log(response)
      });
  };
};
