import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.scss']
})
export class AddEditComponent implements OnInit {
  public pcForm: FormGroup = new FormGroup( {
    tip: new FormControl(''),
    pret: new FormControl(0),
  })

  constructor(
    private userService: UserService,
    public dialogRef: MatDialogRef<AddEditComponent>,
  ) { }

  get tip(): AbstractControl {
    return this.pcForm.get('tip') as FormGroup;
  }

  get pret(): AbstractControl {
    return this.pcForm.get('pret') as FormGroup;
  }

  ngOnInit(): void {
  }

  public addPC(): void {
      this.userService.addPC(this.pcForm.value).subscribe(
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
