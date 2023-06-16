import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal, Result } from './meal';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  url:string = "https://localhost:7270/api/Meal/";
  // Meal result selected by button on the home page, to be displayed on recipes page
  selectedMeal:Result = {} as Result; 

  // List of favorited meal results to be displayed on favorites page
  favoritedMeals:Result[] = [];

  // List of meal results from the user's search
  searchResults:Result[] = [];

  constructor(private http:HttpClient) { }
  //https://localhost:7270/api/Meal/MealCustomQueryReturnPKId?query=query%3Drice%26number%3D2
  getMeals(query:string, time:number):Observable<Result[]>{
    return this.http.get<Result[]>(this.url + 'MealCustomQueryReturnResults?' + "query=query%3D" + query + "%26maxReadyTime%3D" + time);
  }

  // Retrieves list of meal results from the sql database without making an external API call
  retrieveMealFromDbById(id:number):Observable<Result[]>{
    return this.http.get<Result[]>(this.url + 'RetrieveResultsByMealId?id=' + id);
  }
  
}
