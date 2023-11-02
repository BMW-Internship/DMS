import { Injectable } from "@angular/core";
import { VehicleInfo } from './VehicleInfo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";
import { environment } from "../environments/environment";

@Injectable({
  providedIn: "platform"
})

export class VehicleService {
  constructor(private http: HttpClient) { }


  getAllInformations(): Observable<VehicleInfo[]> {
    //debugger
    return this.http.get<VehicleInfo[]>('https://randomuser.me/api/')
      .pipe(
        tap(data => {
          console.log(data);
        })
        ,
        map((res: any) => {
          return res.results.map((item: any) => {
            return {
             
            } as VehicleInfo;
         })
       })
     )
  }
};
