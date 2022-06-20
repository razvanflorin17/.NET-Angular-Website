import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user/user.component';
import { MaterialModule } from '../material/material.module';
import { PcComponent } from './pc/pc.component';
import { MarksPipe } from 'src/app/marks.pipe';
import { HoverDirective } from 'src/app/hover.directive';


@NgModule({
  declarations: [
    UserComponent,
    PcComponent,
    MarksPipe,
    HoverDirective,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    MaterialModule,
  ],
  exports: [
    MarksPipe,
    HoverDirective,
  ]
})
export class UserModule { }
