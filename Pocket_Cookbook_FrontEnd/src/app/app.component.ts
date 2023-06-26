import { SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserFavoritesService } from './user-favorites.service';
import { MealService } from './meal.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PocketCookbook';
  // Google login
  user: SocialUser = {} as SocialUser;
  loggedIn: boolean = false;
  called:boolean = true;


  constructor(private router: Router, private authService:SocialAuthService, 
    private userService:UserFavoritesService, private mealService:MealService) {
  }
  ngOnInit() {
    // Google login
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.userService.user = user;
      this.loggedIn = (user != null);
      this.userService.loggedIn = (user != null);
      this.redirectTo("home");
    });
    this.redirectTo("");
  }

  // Refreshes the page
  redirectTo(uri: string):void {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
    this.router.navigate([uri]));
  }

  // Logs the user out
  userLogout():void {
    this.authService.signOut();
    this.user = {} as SocialUser;
    
    this.loggedIn = false;
    this.userService.loggedIn = false;
    this.redirectTo("home");
  }
}