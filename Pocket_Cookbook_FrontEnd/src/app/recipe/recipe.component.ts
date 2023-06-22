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
  async ngOnInit() {
    await this.recipeService.getRecipeInfo(this.mealService.selectedMeal.id).subscribe(
      (result) => {
        this.currentRecipe = result;
        this.currentRecipeSearch();
      }
    );
  }

  toggleIngredients():void {
    this.showIngredients = !this.showIngredients;
  }

  async getKrogerProductsByQuery(ingredient:string):Promise<void>{
    this.krogerService.getKrogerProducts(ingredient).subscribe(
      (result) => {
        this.productsForIngredient.push(result);
      }
    )
  }

  async currentRecipeSearch():Promise<void>{
    for (let i=0; i<this.currentRecipe.extendedIngredients.length; i++)
    {
      let ingredient : ExtendedIngredient = this.currentRecipe.extendedIngredients[i];
      await this.getKrogerProductsByQuery(ingredient.nameClean!);
      //await this.delay(1000);
    }
  }

  delay(ms:number) : any{
    return new Promise(resolve => setTimeout(resolve, ms));
  }

}

