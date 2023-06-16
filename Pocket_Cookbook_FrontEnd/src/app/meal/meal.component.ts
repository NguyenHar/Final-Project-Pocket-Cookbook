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
  time:number= 30;
  resultsList:Result[] = [];

  constructor (private mealService:MealService){
    
  }

  selectTime():void{
    
  }

  getMealsByQuery():void{
    let searchQuery = this.query;
    this.mealService.getMeals(this.query, this.time).subscribe(
      (result)=> {
        this.resultsList = result;
      }
    )
  }

}
