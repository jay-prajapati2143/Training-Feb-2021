import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {

  emailConfirmed : boolean = false;
  urlParams : {
    token : string,
    userId : string
  }={
    token : "",
    userId : ""
  };

  constructor(
    private route : ActivatedRoute,
    private authService : AuthenticationService,
    private router : Router
    ){ }

  ngOnInit() {
    
    //this.urlParams.token = this.route.snapshot.queryParamMap.get('token');
    //this.urlParams.userId = this.route.snapshot.queryParamMap.get('userid');
    this.route.queryParamMap.subscribe(
      (param:any) =>{
        //console.log(param);
        //console.log(param.params);
        //console.log(param.params.token);
        
        this.urlParams.token = param.params.token;
        this.urlParams.userId = param.params.userid;
        
      }
    );
    
  this.ConfirmEmail();
  }


  ConfirmEmail(){
    
    this.authService.confirmEmail(this.urlParams).subscribe(
      ()=>{
        this.emailConfirmed = true;
      },
      (error)=>{
        this.emailConfirmed = false;
      }
    )
  }

  navigateToLogin(){
    this.router.navigate(['login']);
  }

}
