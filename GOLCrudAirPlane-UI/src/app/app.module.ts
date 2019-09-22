import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AirplanesComponent } from './Airplanes/Airplanes.component';
import { AirplaneComponent } from './Airplanes/Airplane/Airplane.component';
import { AirplaneListComponent } from './Airplanes/Airplane-list/Airplane-list.component';
import { AirplaneService } from './shared/Airplane.service';

@NgModule({
  declarations: [
    AppComponent,
    AirplanesComponent,
    AirplaneComponent,
    AirplaneListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule
  ],
  providers: [AirplaneService],
  bootstrap: [AppComponent]
})
export class AppModule { }
