import { Component, OnInit } from '@angular/core';
import { AirplaneService } from 'src/app/shared/Airplane.service';
import { Airplane } from 'src/app/shared/Airplane.model';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-Airplane-list',
  templateUrl: './Airplane-list.component.html',
  styleUrls: ['./Airplane-list.component.css']
})
export class AirplaneListComponent implements OnInit {


  constructor(private service: AirplaneService, private toastr: ToastrService) {}

  private airplanes: Airplane[];

  ngOnInit() {
    this.service.refreshList();
  }

  popularForm(airplane: Airplane){
    this.service.formData = Object.assign({}, airplane);
  }

  onDelete(id){
    if(confirm('Tem certeza que quer excluir o registro?')){
      this.service.deleteAirplane(id).subscribe(res => {
        this.service.refreshList();
        this.toastr.warning('Excluído com sucesso');
      },
      err => {
        console.log(err);
      })
    }
  }
}
