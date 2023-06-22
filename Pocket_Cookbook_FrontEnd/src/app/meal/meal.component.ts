import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Meal, Result } from '../meal';
import { Router } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.css']
})
export class MealComponent {

  selectedSearch:string = "";
  query:string="";
  time:number;
  newValue:number=0;
  timeOptions:number[] = [10, 15, 20, 25, 30, 35, 40, 45, 50];
  resultsList:Result[] = [];
  resultQty:number = 0;
  recipes:Recipe[] = [];

  constructor (private mealService:MealService, private recipeService:RecipeService, private router:Router) {
    this.time = 30;
    /* DELETE THIS LATER
    * this is to populate the front page with stuff every time we refresh
    * so we don't have to enter stuff in the text box every time
    */
    this.mealService.returnResultsByMeal('pasta', 30).subscribe(
      (result) => {
        this.mealService.searchResults = result;
        this.resultsList = result;

        let queryIds : number[] = [];
        result.forEach(function (value) {
          queryIds.push(value.id);
        });

        this.recipeService.getRecipeInfoBulk(queryIds).subscribe(
          (result) => {
            this.recipes = result;
          }
        )
      }
    );
  }
  // Updates the list when anything on the page changes
  ngOnInit() {
    this.resultsList = this.mealService.searchResults;
  }

  // Calls spoonacular API to return a list of meal results
  // Uses user input as the query
  getMealsByQuery():void{
    //let searchQuery = this.query;
    this.mealService.returnResultsByMeal(this.query, this.time).subscribe(
      (result) => {
        this.mealService.searchResults = result;
        this.resultsList = result;

        let queryIds : number[] = [];
        result.forEach(function (value) {
          queryIds.push(value.id);
        });

        this.recipeService.getRecipeInfoBulk(queryIds).subscribe(
          (result) => {
            this.recipes = result;
            this.mealService.getResultCount(this.resultsList[0].primary_key_id).subscribe(
              (result) => {
                this.resultQty = result;
              }
            )
          }
        )
      }
    )
  }

  // Calls spoonacular API to return a list of meal results
  // Uses user input as the query
  getMealsByCuisine():void{
    //let searchQuery = this.query;
    this.mealService.returnResultsByCuisine(this.query, this.time).subscribe(
      (result) => {
        this.mealService.searchResults = result;
        this.resultsList = result;

        let queryIds : number[] = [];
        result.forEach(function (value) {
          queryIds.push(value.id);
        });

        this.recipeService.getRecipeInfoBulk(queryIds).subscribe(
          (result) => {
          }
        )
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

  // Sets the maximum time required to make the meal
  setTime(newValue:number):void{
    this.time = newValue;
    this.getMealsByQuery();
  }
}
