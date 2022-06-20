import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { Pc } from '../interfaces/pc';
import { PcEdit } from '../interfaces/pc-edit';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public url = 'https://localhost:44335/api/PC';

  private headers= new HttpHeaders()
  .set('Authorization', `Bearer ${localStorage.getItem('token')}`)
  .set('Content-Type', 'application/json');

  constructor(
    public http: HttpClient,
  ) { }
  
  public getAllPCs(): Observable<any> {
    return this.http.get(`${this.url}`, {headers: this.headers});
  }

  public getPC(pret: number): Observable<any> {
    return this.http.get(`${this.url}/${pret}`, {headers: this.headers});
  }

  public deletePC(id: any): Observable<any> {
    return this.http.delete(`${this.url}/${id}`, {headers: this.headers});
  }

  public addPC(pc: Pc): Observable<any> {
    return this.http.post<any>(`${this.url}`, pc, {headers: this.headers});
  }

  public editPC(pc: PcEdit): Observable<any> {
    const pc2 = {
      tip: pc.tip,
      pret: pc.pret,
    }
    return this.http.put<any>(`${this.url}/${pc.id}`, pc2, {headers: this.headers});
  }
}
