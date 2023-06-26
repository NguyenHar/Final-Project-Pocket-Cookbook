import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { KrogerService } from '../kroger.service';
import { KrogerProduct } from '../kroger';


@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {
  currentShoppingList:string[]= this.krogerService.shoppingList;
  krogerSearchResults:KrogerProduct[] = this.krogerService.productsToShop;


  constructor(private recipeService:RecipeService, private krogerService:KrogerService, private router:Router) {

  }

  clearShoppingList():void{
    let emptyStringArray:string[]=[];
    this.krogerService.shoppingList = emptyStringArray; 
  }




}
