import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from './recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  baseURL:string = "https://localhost:7270/api/Recipe/";
  constructor(private http:HttpClient) { }

  // Return Recipe object based on the Meal's primary key id
  getRecipeInfo(id:number) : Observable<Recipe> {
    return this.http.get<Recipe>(this.baseURL + "GetRecipeInfo?id=" + id);
  }
}
