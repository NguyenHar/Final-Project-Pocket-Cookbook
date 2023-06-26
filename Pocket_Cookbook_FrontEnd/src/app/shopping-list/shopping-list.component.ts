import { Component } from '@angular/core';
import { Data, Router } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { KrogerService } from '../kroger.service';
import { Datum, KrogerProduct } from '../kroger';


@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {
  currentShoppingList:string[]= [];
  krogerSearchResults:Datum[][] = [];


  constructor(private recipeService:RecipeService, private krogerService:KrogerService, 
    private router:Router) {

  }

  ngOnInit(){
    this.currentShoppingList = this.krogerService.shoppingList;
    this.krogerSearchResults = this.krogerService.productsToShop;
  }

  clearShoppingList():void{
    let emptyStringArray:string[]=[];
    this.krogerService.shoppingList = emptyStringArray; 
  }


  goToRecipe():void{
    this.router.navigate(["recipe"]);
  }


}
