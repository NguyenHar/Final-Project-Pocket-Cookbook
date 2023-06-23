import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Meal, MealSelection, Result } from '../meal';
import { Router } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../recipe';

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
  styleUrls: ['./meal.component.css']
})
export class MealComponent {
  mealSelectionData:MealSelection = {time:30} as MealSelection;

  timeOptions:number[] = [10, 15, 20, 25, 30, 35, 40, 45, 50];
  cuisineOptions:string[] = ["African","Asian","American","British","Cajun","Caribbean","Chinese","Eastern European",
    "European","French","German","Greek","Indian","Irish","Italian","Japanese","Jewish","Korean","Latin American",
    "Mediterranean","Mexican","Middle Eastern","Nordic","Southern","Spanish","Thai","Vietnamese"];

  constructor (private mealService:MealService, private recipeService:RecipeService, private router:Router) {
  }
  // Updates the list when anything on the page changes
  ngOnInit() {
    this.mealSelectionData = this.mealService.mealSelectionData;
  }

  // Calls spoonacular API to return a list of meal results
  // Uses user input as the query
  getMealsByQuery():void{
    this.mealService.returnResultsByMeal(this.mealSelectionData.query, this.mealSelectionData.time).subscribe(
      (result) => {
        this.mealService.mealSelectionData.resultsList = result;
        this.mealSelectionData.resultsList = result;

        let queryIds : number[] = [];
        result.forEach(function (value) {
          queryIds.push(value.id);
        });

        this.recipeService.getRecipeInfoBulk(queryIds).subscribe(
          (result) => {
            this.mealService.mealSelectionData.recipes = result;
            this.mealSelectionData.recipes = result;
          }
        )
      }
    )
  }

  // Calls spoonacular API to return a list of meal results
  // Uses user input as the query
  getMealsByCuisine():void{
    this.mealService.returnResultsByCuisine(this.mealSelectionData.query, this.mealSelectionData.time).subscribe(
      (result) => {
        this.mealService.mealSelectionData.resultsList = result;
        this.mealSelectionData.resultsList = result;

        let queryIds : number[] = [];
        result.forEach(function (value) {
          queryIds.push(value.id);
        });

        this.recipeService.getRecipeInfoBulk(queryIds).subscribe(
          (result) => {
            this.mealService.mealSelectionData.recipes = result;
            this.mealSelectionData.recipes = result;
          }
        )
      }
    )
  }
  

  // Stores the selected meal result in meal.service.ts as selectedMeal
  selectRecipe(r:Result):void{
    this.mealService.mealSelectionData.selectedMeal = r;
    this.router.navigate(['recipe']);
  }

  // Stores the selected meal result in meal.service.ts in favoritedMeals
  favoriteRecipe(r:Result):void{
    this.mealService.mealSelectionData.favoritedMeals.push(r);
  }

  // Used to display the favorite button only if it's not already favorited
  checkFavorite(id:number):boolean{
    for (let i=0; i<this.mealService.mealSelectionData.favoritedMeals.length; i++){
      if (this.mealService.mealSelectionData.favoritedMeals[i].primary_key_id == id)
        return true;
    }
    return false;
  }
}
