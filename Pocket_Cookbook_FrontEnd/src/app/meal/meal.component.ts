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
  time:number=30;
  newValue:number=0;
  timeOptions:number[] = [10, 15, 20, 25, 30, 35, 40, 45, 50];
  resultsList:Result[] = [];


  /* Much later todo to preserve API calls
    Store user inputs into a dictionary/hash map, key=query, value=meal id
    If the meal type has already been searched for, simply retrieve the meal from the database
    Otherwise, call the API and store new results inside dictionary and the database
  */




  // Hard codes to grab from the sql database on refresh
  // So i'm not spending api calls every time the page is loaded
  constructor (private mealService:MealService, private router:Router) {
    // 59 is a meal in my sql database, you have to change it when you pull the solution
    this.mealService.retrieveMealFromDbById(100).subscribe(
      (result) => {
        this.mealService.searchResults = result;
        this.resultsList = result;
        /* Removed for now, filtering is done in backend
        this.filterNonImageResults(this.mealService.searchResults);
        this.filterNonImageResults(this.resultsList);*/

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
    this.mealService.getMeals(this.query, this.time).subscribe(
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

  /* Removed for now, filter is happening in the backend
  // Remove results where the image is a placeholder
  filterNonImageResults(list:Result[]) : void {
    for (let i=0; i<list.length; i++)
    if (list[i].image == "https://spoonacular.com/recipeImages/606953-312x231.jpg")
    {
      list.splice(i, 1);
    }
  }
  */

  setTime(newValue:number):void{
    this.time = newValue;
    this.getMealsByQuery();
  }
}
