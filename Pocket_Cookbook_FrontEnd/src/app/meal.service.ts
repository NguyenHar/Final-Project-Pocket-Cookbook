import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal, MealSelection, Result } from './meal';
import { HttpClient } from '@angular/common/http';
import { SocialUser } from '@abacritt/angularx-social-login';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  // Object that encapsulates all of the input information necessary
  mealSelectionData:MealSelection = {} as MealSelection;
  // url:string = "https://pocketcookbookwebsite.azurewebsites.net/api/Meal/";

  constructor(private http:HttpClient) { 
    this.mealSelectionData.time = 30;
    this.mealSelectionData.recipes = [];
    this.mealSelectionData.resultsList = [];
    this.mealSelectionData.favoritedMeals = [];
  }

  // // Obsolete
  // // Retrieves list of meal results from api call
  // getMeals(query:string, time:number):Observable<Result[]>{
  //   return this.http.get<Result[]>(this.url + 'MealCustomQueryReturnResults?' + "query=query%3D" + query + "%26maxReadyTime%3D" + time);
  // }

  // // Obsolete
  // // Retrieves list of meal results from the sql database without making an external API call
  // retrieveMealFromDbById(id:number):Observable<Result[]>{
  //   return this.http.get<Result[]>(this.url + 'RetrieveResultsByMealId?id=' + id);
  // }

  // Makes the above 2 functions obsolete
  // Checks database to see if this request already exists in database, if true return those results
  // If doesn't exist in database, make a spoonacular api call and store it in the database
  // Returns: list of results matching the query and time restraints
  returnResultsByMeal(query:string, time:number):Observable<Result[]>{
    return this.http.get<Result[]>(environment.apiUrl.toString() + '/api/Meal/"ReturnResultsbyMealQuery?query=query%3D' + query + '%26maxReadyTime%3D' + time);
  }

  // Checks database to see if this request already exists in database, if true return those results
  // If doesn't exist in database, make a spoonacular api call and store it in the database
    // Returns: list of results matching the cuisine and time restraints
  returnResultsByCuisine(query:string, time:number):Observable<Result[]>{
    return this.http.get<Result[]>(environment.apiUrl.toString() + '/api/Meal/"ReturnResultsbyMealQuery?query=cuisine%3D' + query + '%26maxReadyTime%3D' + time);
  }

  // Checks the database and finds the meal's total result number based on result PK id'
  // Returns: quantity of search results for that meal
  getResultCount(id:number):Observable<number>{
    return this.http.get<number>(environment.apiUrl.toString() + '/api/Meal/"GetResultCount?resultId=' + id);
  }

}
