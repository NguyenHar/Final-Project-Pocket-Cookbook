import { Component } from '@angular/core';
import { MealService } from '../meal.service';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.css']
})
export class MealComponent {

  query:string="";
  mealId:number = 0;

  constructor (private mealService:MealService){
    this.mealService.getMeals(this.query).subscribe(
      (result)=> {
        this.mealId = result;
      }
    )
  }

}
