import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Datum, KrogerProduct } from './kroger';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { KrogerLocation } from './krogerlocation';

@Injectable({
  providedIn: 'root'
})
export class KrogerService {

  // url:string="https://pocketcookbookwebsite.azurewebsites.net/api/Kroger/"
  searchResults:KrogerProduct[] = [];
  shoppingList:string[] = [];
  productsToShop:Datum[][] = [];
  // kp:KrogerProduct = {} as KrogerProduct;
  
  constructor(private http:HttpClient) { }


  getKrogerProducts(query:string):Observable<KrogerProduct>{
    return this.http.get<KrogerProduct>(environment.apiUrl + '/api/Kroger/ProductSearch/' + query)
  }

  // getShoppingListKrogerItems(query:string):void{
  //   this.getKrogerProducts(query).subscribe(
  //     (result) => {
  //       this.productsToShop.push(result.data);
  //     }
  //   )
    
  // }


  // Params: comma separated list of ingredients
  // Calls the async function to search multiple ingredients
  getMultipleProducts(list:string):Observable<KrogerProduct[]>{
    return this.http.get<KrogerProduct[]>(environment.apiUrl + '/api/Kroger/GetMultipleProducts?list=' + list);
  }

  // Params: decimal latitude and longitude of center of radius to search at
  getKrogerLocations(Lat:number, Long:number):Observable<KrogerLocation>{
    return this.http.get<KrogerLocation>(environment.apiUrl + `/api/Kroger/GetKrogerLocations?Lat=${Lat}&Long=${Long}`);
  }
}
