import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  constructor(private fb : FormBuilder,
    private authService : AuthenticationService) { }
  form = this.fb.group({
    UserName : ['',[Validators.required]],
    
  });

  ngOnInit(): void {
  }


  get userName(){
    return this.form.get('UserName')!;
  }

  Submit(){
    this.authService.resetPasswordToken(this.form.value).subscribe(
      (res : any)=>{
        //console.log(res)
        if(res.status == "Success"){
          alert(res.message);
        }
      },
      err=>console.log(err)
    );
  }
}
