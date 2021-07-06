import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';


import {AuthenticationService} from '../authentication.service';
import { PasswordStrengthValidator } from '../Validation/password-strength.validators';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide1 : boolean = true;
  hide2 : boolean = true;
  hide3 : boolean = true;
  public currentUserToken : any;
  public error : any;
  @Output() public childEvent = new EventEmitter();


  constructor(private fb : FormBuilder,private _auth : AuthenticationService,private route:Router) { }

  loginForm = this.fb.group({
    Username: ['',[Validators.required,Validators.minLength(3)]],
    Password : ['',[Validators.required,PasswordStrengthValidator]]
  });
  ngOnInit(): void {
    
  }

  get userName(){
    return this.loginForm.get('Username')!;
  }
  get password(){
    return this.loginForm.get('Password')!;
  }

  loginUser(){
    
    this._auth.loginUser(this.loginForm.value)
      .subscribe(
        (res: any) => {
             debugger;
       if(res.status == "Success"){
         debugger;
            localStorage.setItem('token', res.token);
            localStorage.setItem('userId',res.user);
            alert(res.message);
            //console.log(res);
            //this.currentUserToken = res;
            //console.log(res.message);
            //console.log(res.token);
            this.route.navigate(['']);
       } else{
         alert(res.message);
        
       }
         

          // if (res.status == "Success") {
          //   localStorage.setItem('token', res.token);
          //   localStorage.setItem('userId',res.user);
          //   alert(res.message);
          //   //console.log(res);
          //   //this.currentUserToken = res;
          //   console.log(res.message);
          //   //console.log(res.token);
          //   this.route.navigate(['']);
              
          // } else {
          //   alert(res.message);
          // }


        },
        (err : any) => {
          alert(err.message);
        }
      );

      
    // if(this.currentUser.response.status == "Success"){
    //   this.route.navigate(['']);
    // }else{
    //   alert(this.error);
    // }
  }
 
  registerUser(){
    this.route.navigate(['register']);
  }

  CurrentPasswordToggle(){
    if(this.hide1){
      this.hide1 = false;
    }else
    {
      this.hide1 = true;
    }
  }

}
