import { Component, Inject, OnInit } from '@angular/core';
import { VehicleModel, VehicleInfo } from '../VehicleInfo';
import { VehicleService } from '../vehicle.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  searchText: any; 
  public vehicleModels: VehicleModel[] = [];
    filteredVehicle: VehicleModel[]
      
    = [];
    

  editMode: boolean = false;
 
  constructor(private vehicleService: VehicleService, private http: HttpClient,private route: ActivatedRoute, private router: Router) {
    

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

    console.log(this.vehicleModels);
  }

  //vehicleId = { id : 0 , series: ' ', priceInclusive: 0, price: 0 };

  //searchVehicle() {
  //  const filteredVehicle: VehicleModel = {
  //    id: this.vehicleId.id,
  //    series: this.vehicleId.series,
  //    priceInclusive: this.vehicleId.priceInclusive,
  //    price: this.vehicleId.price
  //  }

  //  this.vehicleService.searchVehicles(filteredVehicle.id).subscribe(() => {

  //  });
  //};

  updateVehicle() {

  }

  DeleteVehicle(Id: any) {

    this.vehicleService.deleteVehicle(Id).subscribe((result: any) => {
      console.log(result);
    
    });
  }


  editVehicle(vehicleId: number) {
    this.router.navigate(['/edit-vehicle-details', vehicleId])

  }
}
