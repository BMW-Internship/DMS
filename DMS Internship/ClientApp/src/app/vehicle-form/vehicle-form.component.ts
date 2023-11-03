import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { VehicleInfo } from '../VehicleInfo';
import { VehicleService } from '../vehicle.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html'
})
export class VehicleFormComponent implements OnInit{

  constructor(private vehicleService: VehicleService, private http: HttpClient) {
    // ...
  }

  ngOnInit(): void {

   }

  inputValues = {Make: ' ', Model: ' ', Price: 0};

  onSubmit(form: NgForm) {
    console.log(form.value);
  }

  addVehicle() {
    const newVehicle: VehicleInfo = {
      vehicleId: 0,
      Make: this.inputValues.Make,
      Model: this.inputValues.Model,
      Price: this.inputValues.Price
    };

    this.vehicleService.addVehicle(newVehicle).subscribe(() => {
      //this.vehicleInfo = data;
    });
  }
}
