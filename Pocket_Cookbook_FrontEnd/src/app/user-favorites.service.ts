import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Result } from './meal';
import { SocialUser } from '@abacritt/angularx-social-login';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserFavoritesService {
  // baseURL:string = "https://pocketcookbookwebsite.azurewebsites.net/api/UserFavorites/";
  // Status if a user is logged in
  loggedIn: boolean = false;
  // The person currently logged in
  user: SocialUser = {} as SocialUser;
  constructor(private http:HttpClient) { }

  // Searches the database and return as list of results that the user favorited
  getUserFavorites(userId:string):Observable<Result[]>{
    return this.http.get<Result[]>(environment.apiUrl + "/api/UserFavorites/GetUserFavorites?userid=" + userId);
  }
  // Adds favorited result from the user to the database
  addUserFavorite(userId:string, resultPKId:number):Observable<any>{
    return this.http.post<any>(environment.apiUrl + "/api/UserFavorites/AddUserFavorite?userid=" + userId + "&resultPKId=" + resultPKId, {});
  }
  // Removes favorited result of the user from the database
  removeUserFavorite(userId:string, resultPKId:number):Observable<any>{
    return this.http.delete<any>(environment.apiUrl+ "/api/UserFavorites/RemoveUserFavorite?userid=" + userId + "&resultPKId=" + resultPKId);
  }
}
