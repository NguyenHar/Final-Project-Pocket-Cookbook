import { GoogleLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Component } from '@angular/core';
import { Result } from '../meal';
import { UserFavoritesService } from '../user-favorites.service';

@Component({
  selector: 'app-google-login',
  templateUrl: './google-login.component.html',
  styleUrls: ['./google-login.component.css']
})
export class GoogleLoginComponent {
  // Google login
  user: SocialUser = {} as SocialUser;
  loggedIn: boolean = false;
  userFavorites:Result[] = []; // Display favorites of this user

  constructor (private authService: SocialAuthService, private userService:UserFavoritesService) {
  }

  ngOnInit() {
    // Google login
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
      this.userService.loggedIn = (user != null);
    });
  }
}

