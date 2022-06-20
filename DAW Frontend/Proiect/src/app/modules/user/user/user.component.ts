import { HttpHeaders, HttpContext, HttpParams } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NavigationExtras, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ComponenteService } from 'src/app/services/componente.service';
import { DataService } from 'src/app/services/data.service';
import { UserService } from 'src/app/services/user.service';
import { AddEditComponent } from '../../shared/add-edit/add-edit.component';
import { EditComponent } from '../../shared/edit/edit.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit, OnDestroy{

  public subscription!: Subscription;
  public loggedUser: any;
  public PCs = [];
  public displayedColumns = ['id', 'tip', 'pret', 'pc', 'edit', 'delete'];
  public Componente = [];
  public displayedColumns2 = ['id', 'nume', 'pret', 'detalii'];

  constructor(
    private router: Router,
    private dataService: DataService,
    private userService: UserService,
    private componenteService: ComponenteService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.subscription = this.dataService.currentUser.subscribe(user => {
      if(user.email == '')
        this.loggedUser.email = ' ';
      else
        this.loggedUser.email = ', ' + user.email});
  
    this.userService.getAllPCs().subscribe(
      (result) => {
        console.log(result);
        this.PCs = result.$values;
      },
      (error) => {
        console.error(error);
      }
    );

    this.componenteService.getAllComponente().subscribe(
      (result) => {
        console.log(result);
        this.Componente = result.$values;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public logout(): void{
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);
  }

  public deletePC(id: any): void {
    const options = {
      headers: new HttpHeaders(),
    };

    this.userService.deletePC(id).subscribe(
      (result) => {
        console.log(result);
        this.PCs = result;
      },
      (error) => {
        console.log(error);
      }
    );

    window.location.reload();
  }

  public openModal(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '550px';
    const dialogRef = this.dialog.open(AddEditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe( (result) => {
      console.log(result);
      if(result)
        this.PCs = result;
    });
  }

  public openModal2(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '550px';
    const dialogRef = this.dialog.open(EditComponent, dialogConfig);
    dialogRef.afterClosed().subscribe( (result) => {
      console.log(result);
      if(result)
        this.PCs = result;
    });
  }

  public addNewPC(): void {
    this.openModal();
  }

  public editPC(): void {
    this.openModal2();
  }

  public goToPC(pret: NavigationExtras | undefined): void {
    this.router.navigate(['pc', pret]);
  }
}
