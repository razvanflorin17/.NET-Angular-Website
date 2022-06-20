import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private userSource = new BehaviorSubject({
    email: '',
    password: '',
  });
  public currentUser = this.userSource.asObservable();

  private registerSource = new BehaviorSubject({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
  });
   public currentRegisterUser = this.registerSource.asObservable();

  constructor() { }

  public changeUserData(user: { email: string; password: string; }): void{
    this.userSource.next(user)
  }
  public changeRegisterUserData (registerUser: { firstName: string; lastName: string; email: string; password: string; }): void{
    this.registerSource.next(registerUser);
  }

}
