import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Result } from './meal';
import { SocialUser } from '@abacritt/angularx-social-login';

@Injectable({
  providedIn: 'root'
})
export class UserFavoritesService {
  baseURL:string = "https://localhost:7270/api/UserFavorites/";
  // Status if a user is logged in
  loggedIn: boolean = false;
  // The person currently logged in
  user: SocialUser = {} as SocialUser;
  constructor(private http:HttpClient) { }

  // Searches the database and return as list of results that the user favorited
  getUserFavorites(userId:string):Observable<Result[]>{
    return this.http.get<Result[]>(this.baseURL + "GetUserFavorites?userid=" + userId);
  }
  // Adds favorited result from the user to the database
  addUserFavorite(userId:string, resultPKId:number):Observable<any>{
    return this.http.post<any>(this.baseURL + "AddUserFavorite?userid=" + userId + "&resultPKId=" + resultPKId, {});
  }
  // Removes favorited result of the user from the database
  removeUserFavorite(userId:string, resultPKId:number):Observable<any>{
    return this.http.delete<any>(this.baseURL + "RemoveUserFavorite?userid=" + userId + "&resultPKId=" + resultPKId);
  }
}