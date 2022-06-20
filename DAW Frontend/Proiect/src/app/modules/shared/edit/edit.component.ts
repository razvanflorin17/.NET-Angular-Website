import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, Form, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  public pcForm: FormGroup = new FormGroup( {
    id: new FormControl(0),
    tip: new FormControl(''),
    pret: new FormControl(0),
  })

  public title= '';

  constructor(
    private userService: UserService,
    public dialogRef: MatDialogRef<EditComponent>,
  ) { }

  get id(): AbstractControl {
    return this.pcForm.get('id') as FormGroup;
  }

  get tip(): AbstractControl {
    return this.pcForm.get('tip') as FormGroup;
  }

  get pret(): AbstractControl {
    return this.pcForm.get('pret') as FormGroup;
  }

  ngOnInit(): void {
  }

  public editPC(): void {
    this.userService.editPC(this.pcForm.value).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
        window.location.reload();
      },
      (error) => {
        console.error(error);
      }
    );
  }

}

