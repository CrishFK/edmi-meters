import { Component } from '@angular/core';
import { EdmiMetersService } from '../Services/edmi-meters-service';
import { Meter } from '../Models/Meter';

@Component({
  selector: 'app-root',
  templateUrl: '../Views/app.component.html',
  styleUrls: ['../Styles/app.component.scss']
})


export class AppComponent {

  constructor(private edmiMetersService: EdmiMetersService){ }
  
  title = 'Edmi Meters Frontend';
  
  serial: number = 0;
  firmwareVersion: string = "";
  ip: string = "";
  port:number = 8080;
  state: string = "";
  
  meterType: string = "";
  meterList:string[]=["Electric", "Gateway", "Water"];

  showGatewayParameters : boolean = false;

  meterTable: string[] = ['id', 'serial', 'firmwareVersion', 'state'];
  gatewaytable: string[] = ['id', 'serial', 'firmwareVersion', 'state', 'ip','port'];
  metersTabledisplayedColumns = this.meterTable;
  metersTableResponse : Meter[] = [];
  meterResquest : Meter = {
    id: 0, 
    serial: this.serial,
    firmwareVersion: this.firmwareVersion,
    ip: this.ip,
    port: this.port,
    state: this.state
  };
  
  
  checkParameters(){
    return this.serial == 0 || this.meterType == "" ? false : true;
  }

  onChange(){
    this.meterType == "Gateway" ? this.showGatewayParameters = true : this.showGatewayParameters = false;
  }

  addMeter(){
    if(this.checkParameters()){
      this.meterResquest = {
        id: 0, 
        serial: this.serial,
        firmwareVersion: this.firmwareVersion,
        ip: this.ip,
        port: this.port,
        state: this.state
      };
      this.edmiMetersService.addMeter(this.meterType, this.meterResquest).subscribe(
        meterResponse => {
        console.log(meterResponse)
      });
    } 
  }

  getMeter(){
  
       this.edmiMetersService.getMeter(this.meterType).subscribe(
          meterResponse => {
            console.log(meterResponse);
          this.metersTableResponse = meterResponse; 
          this.meterType == "Gateway" ? this.metersTabledisplayedColumns = this.gatewaytable : 
                                        this.metersTabledisplayedColumns = this.meterTable;
        });
    }

  getMeterBySerial(){
  
      this.edmiMetersService.getMeterBySerial(this.meterType, this.serial).subscribe(
         meterResponse => {
         this.metersTableResponse = meterResponse; 
         this.meterType == "Gateway" ? this.metersTabledisplayedColumns = this.gatewaytable : 
                                       this.metersTabledisplayedColumns = this.meterTable;
       });
   }

}

