import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal } from './meal';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  url:string = "https://localhost:7270/api/Meal/FillDbCustomQuery"
  constructor(private http:HttpClient) { }

  getAllOrders():Observable<any>{
    return this.http.get<Meal[]>(this.url);
  }
}
