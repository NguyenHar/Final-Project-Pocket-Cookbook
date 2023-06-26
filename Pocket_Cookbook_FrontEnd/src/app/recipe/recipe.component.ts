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
  showCart:boolean = true

  constructor(private recipeService:RecipeService, private mealService:MealService, private krogerService:KrogerService) {
  }
  ngOnInit() {
    this.recipeService.getRecipeInfo(this.mealService.mealSelectionData.selectedMeal.id).subscribe(
      (result) => {
        this.currentRecipe = result;
        this.getKrogerProductList();
      }
      );
  }
  addToShoppingList(s:string):void{
    this.krogerService.shoppingList.push(s);
  }

  shoppingListKrogerSearch(query:string):void{
    this.krogerService.getShoppingListKrogerItems(query);
  }

  // Creates a comma-separated string of ingredient names
  // Sends the string to the backend function where the kroger api is called
  // Stores list of kroger product object that is returned from the api
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

