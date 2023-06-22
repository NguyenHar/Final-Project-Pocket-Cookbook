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
  productsForIngredient:KrogerProduct[] = [];



  constructor(private recipeService:RecipeService, private mealService:MealService, private krogerService:KrogerService) {
  }
  ngOnInit() {
    this.recipeService.getRecipeInfo(this.mealService.selectedMeal.id).subscribe(
      (result) => {
        this.currentRecipe = result;
        this.getKrogerProductList();
      }
      );
  }

  getKrogerProductList():void{
    let list : string = "";
    for (let i=0; i<this.currentRecipe.extendedIngredients.length; i++)
    {
      let ingredient: ExtendedIngredient = this.currentRecipe.extendedIngredients[i];
      if (i < this.currentRecipe.extendedIngredients.length - 1 ) {
        list += this.currentRecipe.extendedIngredients[i].nameClean!.split(' ').join('%20') + ',';
      }
      else{
        list += this.currentRecipe.extendedIngredients[i].nameClean!.split(' ').join('%20');
      }
    }
    this.krogerService.getMultipleProducts(list).subscribe(
      (result) => {
        this.productsForIngredient = result;
      }
    );
  }
  



}

