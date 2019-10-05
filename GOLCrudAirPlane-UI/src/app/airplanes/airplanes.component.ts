import { Component, OnInit } from '@angular/core';
import { AirplaneService } from 'src/app/shared/Airplane.service';

@Component({
  selector: 'app-Airplanes',
  templateUrl: './Airplanes.component.html',
  styleUrls: ['./Airplanes.component.css'],
  providers:[AirplaneService]
})
export class AirplanesComponent implements OnInit {

  constructor(private service : AirplaneService) { 
    
  }

  ngOnInit() {
  }

}
