import { Injectable } from '@angular/core';
import { Airplane } from './Airplane.model';
import { HttpClient } from "@angular/common/http";
import {formatDate} from '@angular/common';



@Injectable({
  providedIn: 'root'
})
export class AirplaneService {
 
  formData: Airplane;
  list: Airplane[];

  readonly rootURL = "http://localhost:52653/api";

  constructor(private http: HttpClient) { }
  
  postAirplane()
  {
    this.formData.CriadoEm = this.RetornaDataHoraAtual();
    return this.http.post(this.rootURL+'/Airplane', this.formData);
  }
  
  putAirplane()
  {
    return this.http.put(this.rootURL+'/Airplane/'+ this.formData.Id, this.formData, {responseType: 'text'});
  }
  
  deleteAirplane(id: number)
  {
    return this.http.delete(this.rootURL+'/Airplane/' + id, {responseType: 'text'});
  }

  refreshList() {
    return this.http.get(this.rootURL+'/Airplane').subscribe((res : any[])=>{
      this.list = res;
      });

      
    //.toPromise()
    //.then(res => this.list = res as Airplane[]);
  }

  RetornaDataHoraAtual(){
    var dNow = new Date();
    var localdate = dNow.getDate() + '/' + (dNow.getMonth()+1) + '/' + dNow.getFullYear();
    return localdate;
  }

  
}

