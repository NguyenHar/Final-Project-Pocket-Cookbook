import { Component } from '@angular/core';
import { Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { MealService } from '../meal.service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent {
  // Recipe containing pre-determined values from the database, to preserve API calls
  //dummyRecipes:Recipe[] = [];
  dummyRecipe:Recipe = {} as Recipe;
  showIngredients:boolean = false;

  /* Todo
    Before making an api call on the particular dish, first check if it already exists
    If it does, use getSingleRecipeFromDb(id:number)
    Otherwise, use getRecipeInfo(id:number)
  */


  constructor(private recipeService:RecipeService, private mealService:MealService) {
    /*this.recipeService.getRecipesFromDb().subscribe(
      (result) => {
        this.dummyRecipes = result;
      }
    )*/
  }
  ngOnInit() {
    this.recipeService.getSingleRecipeFromDb(this.mealService.selectedMeal.id).subscribe(
      (result) => {
        this.dummyRecipe = result;
      }
    );
  }

  toggleIngredients():void {
    this.showIngredients = !this.showIngredients;
  }
}
