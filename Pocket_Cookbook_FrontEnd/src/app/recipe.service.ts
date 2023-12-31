import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from './recipe';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  // baseURL:string = "https://pocketcookbookwebsite.azurewebsites.net/api/Recipe/";  
  constructor(private http:HttpClient) { 

  }

  // Checks database to see if recipe already exists, if it doesn't,
  // Calls Spoonacular API and stores recipe inside database
  // Return Recipe object based on the result id
  getRecipeInfo(id:number):Observable<Recipe> {
    return this.http.get<Recipe>(environment.apiUrl + "/api/Recipe/GetRecipeInfo?id=" + id);
  }

  // Checks database to see if recipe already exists, if it doesn't,
  // Calls Spoonacular API and stores recipe inside database
  // Return list of recipe objects based on the Meal's primary key id
  getRecipeInfoBulk(ids:number[]):Observable<Recipe[]> {
    let str:string = "";
    for (let i=0; i<ids.length; i++)
    {
      if (i < ids.length - 1)
      {
        str += ids[i];
        str += '%2C';
      }
      else
      {
        str += ids[i];
      }
    }

    return this.http.get<Recipe[]>(environment.apiUrl + "/api/Recipe/GetRecipeInfoBulk?ids=" + str);
  }
}
