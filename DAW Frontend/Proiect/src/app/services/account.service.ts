import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { HttpClient } from '@angular/common/http';
import { RegisterUser } from '../interfaces/register-user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public url: string = 'https://localhost:44335/api/Account';

  constructor(
    private http: HttpClient,
  ) {}

  public login(user: User): Observable<any> {
    return this.http.post<any>(`${this.url}/login`, user);
  }

  public register(registerUser: RegisterUser): Observable<any> {
    return this.http.post<any>(`${this.url}/register`,registerUser);
  }
}
