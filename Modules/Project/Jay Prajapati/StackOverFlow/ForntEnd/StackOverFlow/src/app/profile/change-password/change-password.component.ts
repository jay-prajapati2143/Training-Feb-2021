import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication.service';
import { UsersService } from 'src/app/users.service';
import { PasswordStrengthValidator } from 'src/app/Validation/password-strength.validators';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  hide1 : boolean = true;
  hide2 : boolean = true;
  hide3 : boolean = true;
  constructor(private fb : FormBuilder,
    private _auth : AuthenticationService,
    private route:Router,
    private userService : UsersService) { }

  changePasswordForm = this.fb.group({
    CurrentPassword: ['',[Validators.required,PasswordStrengthValidator]],
    NewPassword : ['',[Validators.required,PasswordStrengthValidator]],
    ConfirmNewPassword : ['',[Validators.required,PasswordStrengthValidator]]
  });

  
  ngOnInit(): void {
  }

  get CurrentPassword(){
    return this.changePasswordForm.get('CurrentPassword')!;
  }
  get NewPassword(){
    return this.changePasswordForm.get('NewPassword')!;
  }
  get ConfirmNewPassword(){
    return this.changePasswordForm.get('ConfirmNewPassword')!;
  }

  changePassword(){
    this.userService.changePassword(this.changePasswordForm.value).subscribe(
      (res:any)=>{
        if(res.succeded){
          console.log(res);
          alert("Password is successfully Updated");
          location.reload();
        }},
      err=>console.log(err)
    )
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

}
