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

  getMeals(query:string):Observable<number>{
    return this.http.get<number>(this.url + "FillDbCustomQuery");
  }

  getResults(id:number):Observable<Result[]>{
    return this.http.get<Result[]>(this.url + "RetrieveCustomQueryResults?id=" + id)
  }

  
}
