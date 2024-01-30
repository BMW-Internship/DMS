import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehicleService } from './vehicle.service';
import { EditVehicleDetailsComponent } from './edit-vehicle-details/edit-vehicle-details.component';
import { AppRoutingModule } from './app-routing-module';
import { FilterPipe } from './filter.pipe';
 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
   EditVehicleDetailsComponent,
    FetchDataComponent,
    VehicleFormComponent,
    FilterPipe 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'vehicle-form', component: VehicleFormComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: '-edit-vehicle-details', component: EditVehicleDetailsComponent },


    ]),
    AppRoutingModule
  ],
  providers: [VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
