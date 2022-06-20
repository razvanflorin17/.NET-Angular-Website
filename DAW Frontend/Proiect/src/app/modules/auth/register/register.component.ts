import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private dataService: DataService,
    private accountService: AccountService,
    ) { }

    get firstName(): AbstractControl{
      return this.registerForm.get('firstName') as FormGroup;
    }
    get lastName(): AbstractControl{
      return this.registerForm.get('lastName') as FormGroup;
    }
    get email(): AbstractControl{
      return this.registerForm.get('email') as FormGroup;
    }
    get password(): AbstractControl{
      return this.registerForm.get('password') as FormGroup;
    }

  ngOnInit(): void {
  }
  public register(): void
  {
    const registerUser={
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    }

    this.dataService.changeRegisterUserData(this.registerForm.value);
    this.accountService.register(registerUser).subscribe();
  }
  public login(): void {
    this.router.navigate(['/auth/login']);
  }
}
