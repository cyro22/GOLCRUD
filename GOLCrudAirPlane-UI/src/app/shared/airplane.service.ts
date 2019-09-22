import { Injectable } from '@angular/core';
import { Airplane } from './Airplane.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
  
  formData : Airplane;
  list : Airplane[];
  readonly rootURL = "http://localhost:52653/api";

  constructor(private http : HttpClient) { }

  postAirplane(formData : Airplane){
    return this.http.post(this.rootURL+'/Airplane',formData);
  }

  refreshList(){
    this.http.get(this.rootURL+'/Airplane')
    .toPromise().then(res => this.list = res as Airplane[]);
  }

  putAirplane(formData : Airplane){
    return this.http.put(this.rootURL+'/Airplane/'+formData.Id, formData);
  }

  deleteAirplane(id : number){
    return this.http.delete(this.rootURL+'/Airplane/'+id);
  }
}
