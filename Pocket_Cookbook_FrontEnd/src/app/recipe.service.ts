import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from './recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  baseURL:string = "https://localhost:7270/api/Recipe/";
  constructor(private http:HttpClient) { 

  }

  // Checks database to see if recipe already exists, if it doesn't,
  // Calls Spoonacular API and stores recipe inside database
  // Return Recipe object based on the Meal's primary key id
  getRecipeInfo(id:number):Observable<Recipe> {
    return this.http.get<Recipe>(this.baseURL + "GetRecipeInfo?id=" + id);
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

    return this.http.get<Recipe[]>(this.baseURL + "GetRecipeInfoBulk?ids=" + str);
  }


  // Obsolete
  /*
  // Retrieves list of recipes from the sql database without making an external API call
  // Currently using hard-coded id's that I populated my database with
  // This function is for testing purposes only
  getRecipesFromDb():Observable<Recipe[]> {
    let ids:number[] = [1697541,643642,648279,606953,1096054,1697577,1095886,668492,639957,1697625];
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
    return this.http.get<Recipe[]>(this.baseURL + "GetRecipesFromDb?str=" + str);
  }

  // Retrieves one recipe from the sql database without making an external API call
  getSingleRecipeFromDb(id:number):Observable<Recipe> {
    return this.http.get<Recipe>(this.baseURL + "GetSingleRecipeFromDb?id=" + id);
  }
  */
}
