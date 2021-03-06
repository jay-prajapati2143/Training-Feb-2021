import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuestionsRoutingModule } from './questions-routing.module';
import { QuestionsComponent } from './questions.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuestionsComponent,
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    QuestionsRoutingModule,
    ReactiveFormsModule
  ]
})
export class QuestionsModule { }
