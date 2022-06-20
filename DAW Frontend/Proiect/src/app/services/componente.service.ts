import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ComponenteService {

  public url = 'https://localhost:44335/api/Componente';

  private headers= new HttpHeaders()
  .set('Authorization', `Bearer ${localStorage.getItem('token')}`)
  .set('Content-Type', 'application/json');

  constructor(
    public http: HttpClient,
  ) { }
  
  public getAllComponente(): Observable<any> {
    return this.http.get(`${this.url}`, {headers: this.headers});
  }
  
}