import { Component } from '@angular/core';

@Component({
  selector: 'app-edit-vehichle-details',
  templateUrl: './edit-vehichle-details.component.html',
  styleUrls: ['./edit-vehichle-details.component.scss']
})
export class EditVehichleDetailsComponent {

}
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { VehicleEntities } from '../VehicleEntities.model';
import { VehicleInfo } from '../VehicleInfo';

@Component({
  selector: 'app-edit-vehicle-details',
  templateUrl: './edit-vehicle-details.component.html',
  styleUrls: ['./edit-vehicle-details.component.css']
})
export class EditVehicleDetailsComponent implements OnInit {
  vehicleFormData = {
    vehicleId : 0,
    Make: ' ',
   Model: ' ', 
   Price: 0};

  editMode: boolean = false;

  vehicleEntities: VehicleEntities = new VehicleEntities;
 // vehicleEntity : VehicleEntity;
  vehicleId: any;
  submitted: boolean = false;
    ngForm: any;

  constructor(private route: ActivatedRoute, private router: Router, public VehicleServices: VehicleService) {
    
  }

  ngOnInit(): void {
  this.vehicleId
    this.route.params.subscribe(params => {
      this.vehicleId = params['VehicleId'];

      if (this.vehicleId == "new") {
        this.editMode = false;
      }
      else {
        this.editMode = true;
        this.VehicleServices.getById(this.vehicleId).subscribe((result: any) => {
          this.vehicleEntities = result;
          this.ngForm.patchValue({
          vehicleId :this.vehicleEntities.VehicleId,
          make :this.vehicleEntities.make,
          model :this.vehicleEntities.Model,
          Price :this.vehicleEntities.Price,

          });

        })
      }
    })
  }
  addVehicle() {

    if (!this.editMode) {
      this.VehicleServices.addVehicle(this.vehicleFormData).subscribe((result: any) => {
        this.submitted = true;
        const newVehicle: VehicleInfo = {
          vehicleId: 0,
          Make: this.vehicleEntities.make,
          Model: this.vehicleEntities.Model,
          Price: this.vehicleEntities.Price
        };
      })


    }
    else {
      this.VehicleServices.updateVehicle(this.vehicleId, this.vehicleFormData).subscribe((result: any) => {
        

      })
    }
   
}}
