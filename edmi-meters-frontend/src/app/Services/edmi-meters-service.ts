import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Meter } from '../Models/Meter';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class EdmiMetersService {

  constructor(private httpClient: HttpClient) { }


  getMeter(controller: string) : Observable<Meter[]>{
    return this.httpClient.get<Meter[]>('/api/' + controller);
  }

  getMeterBySerial(controller: string, id: number) : Observable<Meter[]>{
    return this.httpClient.get<Meter[]>('/api/' + controller + "/" + id);
  }

  addMeter(controller: string, meter: Meter) : Observable<Meter> {
    return this.httpClient.post<Meter>('/api/' + controller, meter, httpOptions)
  }

}
