import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KrogerProduct } from './kroger';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KrogerService {

  url:string="https://localhost:7270/api/Kroger/"
  searchResults:KrogerProduct[] = [];
  shoppingList:string[] = [];
  productsToShop:KrogerProduct[] = [];
  kp:KrogerProduct = {} as KrogerProduct;
  
  constructor(private http:HttpClient) { }


  getKrogerProducts(query:string):Observable<KrogerProduct>{
    return this.http.get<KrogerProduct>(this.url + 'ProductSearch/' + query)
  }

  getShoppingListKrogerItems(query:string):void{
    this.getKrogerProducts(query).subscribe(
      (result) => {
        this.kp = result
        this.productsToShop.push(this.kp);
      }
    )
    
  }


  // Params: comma separated list of ingredients
  // Calls the async function to search multiple ingredients
  getMultipleProducts(list:string):Observable<KrogerProduct[]>{
    return this.http.get<KrogerProduct[]>(this.url + 'GetMultipleProducts?list=' + list);
  }
}
