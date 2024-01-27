import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../vehicle.service';
import { VehicleEntities } from '../VehicleEntities.model';
import { VehicleInfo } from '../VehicleInfo';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edit-vehicle-details',
  templateUrl: './edit-vehicle-details.component.html',
  styleUrls: ['./edit-vehicle-details.component.css']
})
export class EditVehicleDetailsComponent implements OnInit {
  inputValues = {
    /*vehicleId: 0,*/
    Make: ' ',
    Model: ' ',
    Price: 0
  };

  editMode: boolean = false;
  vehicleModels: VehicleInfo[] = [];
  searchVehicleId: any;
  selectedVehicle: VehicleInfo | null = null;
  vehicleEntities: VehicleEntities = new VehicleEntities;
  // vehicleEntity : VehicleEntity;
  vehicleId: any;
  submitted: boolean = false;
  ngForm: any;

  constructor(private route: ActivatedRoute, private router: Router, private VehicleServices: VehicleService, private http: HttpClient) {

  }

  onSubmit(form: NgForm) {
    // Handle the form submission logic
    this.addVehicle();
  }

  ngOnInit(): void {
    /* this.vehicleId*/
    this.route.params.subscribe(params => {
      this.vehicleId = params['id'];

      // Check if the vehicleId is defined to determine edit mode
      this.editMode = this.vehicleId !== undefined;

      if (this.vehicleId !== undefined) {
        /* this.editMode = false;*/
        // Fetch the details of the selected vehicle based on vehicleId
        this.VehicleServices.getById(this.vehicleId).subscribe(
          (vehicleDetails: any) => {
            // Update inputValues with the details of the selected vehicle
            this.inputValues.Make = vehicleDetails.series;
            this.inputValues.Model = vehicleDetails.priceInclusive;
            this.inputValues.Price = vehicleDetails.price;

            console.log('object' + vehicleDetails);
          },
          (error: any) => {
            console.error(error);
          }
        );
      }
      //else {
      //  this.editMode = true;
      //  this.VehicleServices.getById(this.vehicleId).subscribe((result: any) => {
      //    this.vehicleEntities = result;
      //    this.ngForm.patchValue({
      //    vehicleId :this.vehicleEntities.VehicleId,
      //    make :this.vehicleEntities.make,
      //    model :this.vehicleEntities.Model,
      //    Price :this.vehicleEntities.Price,

      //    });

      //  })
      //}
    });
  }
  addVehicle() {

    if (this.editMode) {
       // Update existing vehicle
      const updatedVehicle: VehicleInfo = {
        vehicleId: 0,
        Make: this.inputValues.Make,
        Model: this.inputValues.Model,
        Price: this.inputValues.Price
      };
        
        this.VehicleServices.updateVehicle(this.vehicleId, updatedVehicle).subscribe(
          (result: any) => {
            window.alert('Vehicle updated successfully');
            this.router.navigate(['fetch-data']);

          },
          (error: any) => {
            console.error(error);
          }
        );
    }
    else {

      // Add new vehicle
      const newVehicle: VehicleInfo = {
        vehicleId: 0,
        Make: this.inputValues.Make,
        Model: this.inputValues.Model,
        Price: this.inputValues.Price
      };
      this.VehicleServices.updateVehicle(this.vehicleId, this.inputValues).subscribe((result: any) => {
        this.submitted = true;
        window.alert('Vehicle added successfully');

      },
        (error: any) => {
          console.error(error);
        },
      );

    } 
    }
  }

