import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MealComponent } from './meal/meal.component';
import { Route, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RecipeComponent } from './recipe/recipe.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from "@angular/material/card";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { SocialLoginModule, SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import { GoogleLoginProvider} from '@abacritt/angularx-social-login';
import { GoogleSigninButtonModule } from '@abacritt/angularx-social-login';
import { GoogleLoginComponent } from './google-login/google-login.component';

const routes : Route[] = [
  { path:'' , component:MealComponent, pathMatch: 'full' },
  { path:'favorites', component:FavoritesComponent},
  { path:'recipe', component:RecipeComponent},
  { path:'shopping-list', component:ShoppingListComponent},
  { path:'login', component:GoogleLoginComponent},
  { path:'home', component:MealComponent },

];

@NgModule({
  declarations: [
    AppComponent,
    MealComponent,
    RecipeComponent,
    FavoritesComponent,
    ShoppingListComponent,
    GoogleLoginComponent
  ],
  imports: [
    BrowserModule, 
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    FlexLayoutModule,
    SocialLoginModule,
    GoogleSigninButtonModule
  ],
  providers: [    {
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider(
            "48105807888-qatpml7icgecbbt9ap5jmud1vl27bqel.apps.googleusercontent.com"
          )
        }
      ],
      onError: (err) => {
        console.error(err);
      }
    } as SocialAuthServiceConfig,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
