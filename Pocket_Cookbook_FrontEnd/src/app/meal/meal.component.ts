import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Meal, Result } from '../meal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.css']
})
export class MealComponent {

  query:string="";
  time:number= 30;
  resultsList:Result[] = [];


  // Hard codes to grab from the sql database on refresh
  // So i'm not spending api calls every time the page is loaded
  constructor (private mealService:MealService, private router:Router) {
    // 59 is a meal in my sql database, you have to change it when you pull the solution
    this.mealService.retrieveMealFromDbById(59).subscribe(
      (result) => {
        this.mealService.searchResults = result;
        this.resultsList = result;
      }
    )
  }
  // Updates the list when anything on the page changes
  ngOnInit() {
    this.resultsList = this.mealService.searchResults;
  }


  // Calls spoonacular API to return a list of meal results
  // Uses user input as the query
  getMealsByQuery():void{
    //let searchQuery = this.query;
    this.mealService.getMeals(this.query).subscribe(
      (result)=> {
        this.mealService.searchResults = result;
        this.resultsList = result;
      }
    )
  }

  // Stores the selected meal result in meal.service.ts as selectedMeal
  selectRecipe(r:Result):void{
    this.mealService.selectedMeal = r;
    this.router.navigate(['recipe']);
  }

  // Stores the selected meal result in meal.service.ts in favoritedMeals
  favoriteRecipe(r:Result):void{
    this.mealService.favoritedMeals.push(r);
  }

  // Used to display the favorite button only if it's not already favorited
  checkFavorite(id:number):boolean{
    for (let i=0; i<this.mealService.favoritedMeals.length; i++){
      if (this.mealService.favoritedMeals[i].primary_key_id == id)
        return true;
    }
    return false;
  }
}
