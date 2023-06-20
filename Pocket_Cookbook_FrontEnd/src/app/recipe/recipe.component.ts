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
  currentRecipe:Recipe = {} as Recipe;
  showIngredients:boolean = false;


  constructor(private recipeService:RecipeService, private mealService:MealService) {
  }
  ngOnInit() {
    this.recipeService.getRecipeInfo(this.mealService.selectedMeal.id).subscribe(
      (result) => {
        this.currentRecipe = result;
      }
    );
  }

  toggleIngredients():void {
    this.showIngredients = !this.showIngredients;
  }
}
