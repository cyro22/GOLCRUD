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

  constructor(private service : AirplaneService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form != null)  
      form.resetForm();
    
    this.service.formData = {
      Id: null,
      Modelo : '',
      QuantidadePassageiros : 0,
      CriadoEm : null,
    }
  }

  onSubmit(form: NgForm){
    if(form.value.Id == null)
      this.insert(form);
    else
      this.update(form);
  }

  insert(form: NgForm){
    this.service.postAirplane(form.value).subscribe(res => {
      //this.toastr.success('Resgistro inserido com sucesso!','Airplane Crud');
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  update(form: NgForm){
    this.service.putAirplane(form.value).subscribe(res => {
      this.resetForm(form);
    });
  }
}
