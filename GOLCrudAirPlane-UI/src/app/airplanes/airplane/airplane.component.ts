import { Component, OnInit } from '@angular/core';
import { AirplaneService } from 'src/app/shared/Airplane.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-Airplane',
  templateUrl: './Airplane.component.html',
  styleUrls: ['./Airplane.component.css']
})
export class AirplaneComponent implements OnInit {

  constructor(private service : AirplaneService, 
    private toastr : ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm){
    if(form != null)  
      form.resetForm();
    
    this.service.formData = {
      Id: "00000000-0000-0000-0000-000000000000",
      Modelo : "",
      QuantidadePassageiros : null,
      CriadoEm : null
    }
  }

  onSubmit(form: NgForm){
    if(this.service.formData.Id == null || this.service.formData.Id == "00000000-0000-0000-0000-000000000000"){
      this.insert(form);
    }
    else
      this.update(form);
      this.service.refreshList();
  }

  insert(form: NgForm){
    this.service.postAirplane().subscribe( res => {
        this.resetForm(form);
        this.toastr.success('Resgistro inserido com sucesso!','Airplane Crud');
        this.service.refreshList();
        console.log(res);
      },
      err => {
        console.log(err);
      } 
    )
  }

  update(form: NgForm){
    this.service.putAirplane().subscribe(res => {
      this.resetForm(form);
      this.toastr.success('Resgistro atualizado com sucesso!','Airplane Crud');
        this.service.refreshList();
        console.log(res);
      },
      err => {
        console.log(err);
      } 
    )
  }

}
