import { Injectable } from "@angular/core";
import { VehicleInfo, VehicleModel } from './VehicleInfo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: "platform"
})

export class VehicleService {
  constructor(private http: HttpClient) { }

  baseUrl = environment.apiUrl;

  getAllVehicles(): Observable<VehicleModel[]> {
    return this.http.get<VehicleModel[]>(`${this.baseUrl}/vehicle`);//https://localhost:7120/Vehicle
  }

  updateVehicle(id: number, vehicleData: any): Observable<VehicleInfo> {
    return this.http.put<VehicleInfo>(`${this.baseUrl}/vehicle/${id}`, vehicleData);
  }

  deleteVehicle(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}/vehicle/${id}`);
  }

  searchVehicles(searchTerm: string): Observable<VehicleInfo[]> {
    return this.http.get<VehicleInfo[]>(`${this.baseUrl}/vehicle/search?term=${searchTerm}`);
  }

  addVehicle(vehicleData: VehicleInfo): Observable<VehicleInfo> {
    return this.http.post<VehicleInfo>(`${this.baseUrl}/vehicle`, vehicleData);
  }

  //getAllInformations(): Observable<VehicleInfo[]> {
  //  //debugger
  //  return this.http.get<VehicleInfo[]>('https://randomuser.me/api/')
  //    .pipe(
  //      tap(data => {
  //        console.log(data);
  //      })
  //      ,
  //      map((res: any) => {
  //        return res.results.map((item: any) => {
  //          return {

  //          } as VehicleInfo;
  //       })
  //     })
  //   )
  //}

};
