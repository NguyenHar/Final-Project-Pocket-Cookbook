import { Component } from '@angular/core';
import { ExtendedIngredient, Recipe } from '../recipe';
import { RecipeService } from '../recipe.service';
import { MealService } from '../meal.service';
import { KrogerService } from '../kroger.service';
import { KrogerProduct } from '../kroger';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent {
  currentRecipe:Recipe = {} as Recipe;
  showIngredients:boolean = false;
  productsForIngredient:KrogerProduct[] = [];


  constructor(private recipeService:RecipeService, private mealService:MealService, private krogerService:KrogerService) {
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

  getKrogerProductsByQuery(ingredient:string):void{
    this.krogerService.getKrogerProducts(ingredient).subscribe(
      (result) => {
        this.productsForIngredient.push(result);
      }
    )
  }

  currentRecipeSearch():void{
    for (let i=0; i<this.currentRecipe.extendedIngredients.length; i++)
    {
      let ingredient : ExtendedIngredient = this.currentRecipe.extendedIngredients[i];
      this.getKrogerProductsByQuery(ingredient.nameClean!);
    }
  }

}

