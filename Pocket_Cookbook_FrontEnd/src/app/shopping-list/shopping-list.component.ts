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
  itemForCart:KrogerProduct = {} as KrogerProduct;
  cartTotal:number = 0;


  constructor(private recipeService:RecipeService, private krogerService:KrogerService, 
    private router:Router) {
  }

  ngOnInit(){
    this.currentShoppingList = this.krogerService.shoppingList;
    this.krogerSearchResults = this.krogerService.productsToShop;
    console.log(this.krogerSearchResults)
  }

  clearShoppingList():void{
    let emptyStringArray:string[]=[];
    this.krogerService.shoppingList = emptyStringArray; 
  }

  goToRecipe():void{
    this.router.navigate(["recipe"]);
  }

  addToCart():void{ 
    let shoppingCart:Datum[] = [];
    for (let i = 0; i < 2; i++)
    {
      this.krogerSearchResults[i].forEach((kProduct:Datum) => {
        let item:HTMLInputElement = document.getElementById(kProduct.productId) as HTMLInputElement;
        if(item.checked)
        {
          shoppingCart.push(kProduct);
          this.cartTotal += kProduct.items[0].price.regular;
        }
        
      });     
    }
  }

}
