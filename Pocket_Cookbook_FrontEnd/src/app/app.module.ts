import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MealComponent } from './meal/meal.component';
import { Route, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RecipeComponent } from './recipe/recipe.component';
import { FavoritesComponent } from './favorites/favorites.component';

const routes : Route[] = [
  { path:'' , component:MealComponent, pathMatch: 'full' },
  { path:'favorites', component:FavoritesComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    MealComponent,
    RecipeComponent,
    FavoritesComponent
  ],
  imports: [
    BrowserModule, 
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
