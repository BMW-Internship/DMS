import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { EditVehicleDetailsComponent } from './edit-vehicle-details/edit-vehicle-details.component';

const routes: Routes = [
  {
    path: 'edit-vehicle-details/:id', component: EditVehicleDetailsComponent
  
  }
];

@NgModule({

  imports: [RouterModule.forRoot(routes)],

  exports: [RouterModule]

})

export class AppRoutingModule { }
