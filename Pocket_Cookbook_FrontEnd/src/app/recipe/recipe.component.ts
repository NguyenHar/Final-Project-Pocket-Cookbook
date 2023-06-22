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
        // this.currentRecipeSearch();
        this.getKrogerProductList();
      }
      );
  }


  // // Button to show/hide the list of ingredients
  // toggleIngredients():void {
  //   this.showIngredients = !this.showIngredients;
  // }

  // // params: string to search for 
  // // Calls the service to retrieve a list of kroger products
  // async getKrogerProductsByQuery(ingredient:string):Promise<void>{
  //   this.krogerService.getKrogerProducts(ingredient).subscribe(
  //     (result) => {
  //       this.productsForIngredient.push(result);
  //     }
  //   )
  // }

  // // Loops through the list of ingredients and calls the kroger api on each ingredient
  // async currentRecipeSearch():Promise<void>{
  //   for (let i=0; i<this.currentRecipe.extendedIngredients.length; i++)
  //   {
  //     let ingredient : ExtendedIngredient = this.currentRecipe.extendedIngredients[i];
  //     let name : string = ingredient.nameClean!.split(' ').join('%20');

  //     await this.getKrogerProductsByQuery(name);
  //     await this.delay(500);
  //   }
  // }

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
    console.log(list);
    this.krogerService.getMultipleProducts(list).subscribe(
      (result) => {
        this.productsForIngredient = result;
      }
    );
  }
  


  // Used to add a time delay between each process to make sure the async call has sufficient time to run
  delay(ms:number) : any{
    return new Promise(resolve => setTimeout(resolve, ms));
  }

}

