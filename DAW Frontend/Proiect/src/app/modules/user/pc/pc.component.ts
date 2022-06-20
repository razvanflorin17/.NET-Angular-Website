import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-pc',
  templateUrl: './pc.component.html',
  styleUrls: ['./pc.component.scss']
})
export class PcComponent implements OnInit {

  public subscription: Subscription | undefined;
  public pret: number = 0;
  public pc = {
    tip: 'default type',
    pret: 0,
  };

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
  ) { }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params => {
      this.pret = +params['pret'];
      if(this.pret)
        this.getPC();
    });
  }

  public getPC(): void {
    this.userService.getPC(this.pret).subscribe(
      (result) => {
        console.log(result);
        this.pc = result.$values[0];
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
