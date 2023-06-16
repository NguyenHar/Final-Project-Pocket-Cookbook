import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal, Result } from './meal';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  url:string = "https://localhost:7270/api/Meal/";
  constructor(private http:HttpClient) { }
  //https://localhost:7270/api/Meal/MealCustomQueryReturnPKId?query=query%3Drice%26number%3D2
  getMeals(query:string, time: number):Observable<Result[]>{
    return this.http.get<Result[]>(this.url + 'MealCustomQueryReturnResults?' + "query=query%3D" + query + "%26maxReadyTime%3D" + time);
  }

  
}
