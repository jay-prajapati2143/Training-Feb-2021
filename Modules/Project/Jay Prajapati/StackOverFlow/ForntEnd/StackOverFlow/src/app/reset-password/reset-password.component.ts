import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { PasswordStrengthValidator } from '../Validation/password-strength.validators';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  hide1 : boolean = true;
  hide2 : boolean = true;
  hide3 : boolean = true;
  urlParams : {
    token : string,
    userId : string
  }={
    token : "",
    userId : ""
  }


  constructor(private fb : FormBuilder,
    private route: ActivatedRoute,
    private router : Router,
    private authServices : AuthenticationService) {   }

    ngOnInit(): void {
      this.urlParams.token = this.route.snapshot.queryParamMap.get('token');
      this.urlParams.userId = this.route.snapshot.queryParamMap.get('userid');
      console.log(this.urlParams.token);
    }

   resetPasswordForm = this.fb.group({
    UserName : ['',Validators.required],
    Password: ['',[Validators.required,PasswordStrengthValidator]],
    ConfirmPassword : ['',[Validators.required,PasswordStrengthValidator]],
    Token : ['']
  });



  
  


  get UserName(){
    return this.resetPasswordForm.get('UserName')!;
  }

  get Password(){
    return this.resetPasswordForm.get('Password')!;
  }
  get ConfirmPassword(){
    return this.resetPasswordForm.get('ConfirmPassword')!;
  }

  
  CurrentPasswordToggle(){
    if(this.hide1){
      this.hide1 = false;
    }else
    {
      this.hide1 = true;
    }
  }

  NewPasswordToggle(){
    if(this.hide2){
      this.hide2 = false;
    }else
    {
      this.hide2 = true;
    }
  }

  ConfirmNewPasswordToggle(){
    if(this.hide3){
      this.hide3 = false;
    }else
    {
      this.hide3 = true;
    }
  }
  
  

  resetPassword(){
  this.resetPasswordForm.patchValue(
    {
    Token : this.urlParams.token
  }
    )
    console.log(this.resetPasswordForm.value);
    this.authServices.resetPassword(this.resetPasswordForm.value).subscribe(
      (res : any)=>{
        if(res.status == "Success"){
          alert(res.message);
          this.router.navigate(['login']);
        }
      },
      err=>{
        console.log(err);
      }
    )
  }



  navigateTologin(){
    this.router.navigate(['login']);
  }
}
