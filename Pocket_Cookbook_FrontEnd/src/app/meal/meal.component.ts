import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Result } from '../meal';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.css']
})
export class MealComponent {

  query:string="";
  resultsList:Result[] = [];

  constructor (private mealService:MealService){
    this.mealService.getMeals(this.query).subscribe(
      (result)=> {
        this.resultsList = result;
      }
    )
  }

}
