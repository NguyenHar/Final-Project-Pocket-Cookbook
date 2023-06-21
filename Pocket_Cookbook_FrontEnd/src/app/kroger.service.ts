import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KrogerProduct } from './kroger';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KrogerService {

  url:string="https://localhost:7270/api/Kroger/ProductSearch/"
  searchResults:KrogerProduct[] = [];
  
  constructor(private http:HttpClient) { }


  getKrogerProducts(query:string):Observable<KrogerProduct>{
    return this.http.get<KrogerProduct>(this.url + query)
  }
}
