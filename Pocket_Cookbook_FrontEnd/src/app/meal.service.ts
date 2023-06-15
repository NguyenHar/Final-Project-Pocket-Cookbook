import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal, Result } from './meal';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  url:string = "https://localhost:7270/api/Meal/"
  constructor(private http:HttpClient) { }

  getMeals(query:string):Observable<Result[]>{
    return this.http.get<Result[]>(this.url + "RetrieveResults?query=query%3D" + query);
  }

  
}
