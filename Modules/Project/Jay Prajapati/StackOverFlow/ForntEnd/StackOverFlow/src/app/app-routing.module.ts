import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { AuthGuard } from './auth.guard';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { QuesionAnswerDetailComponent } from './quesion-answer-detail/quesion-answer-detail.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

const routes: Routes = [
  { path: '', loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModule) },
  { path: 'home-page', loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModule) },
  {path : 'login', component : LoginComponent},
  {path : 'register', component : RegisterComponent},
  {
    path : 'ask-question', 
    component : AskQuestionComponent,
    canActivate : [AuthGuard]
  },{path:"confirmemail",component : ConfirmEmailComponent},
  {path : "forgetpassword", component : ForgetPasswordComponent},
  {path:"resetpassword",component : ResetPasswordComponent},

  
  {path : "**", component : PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
