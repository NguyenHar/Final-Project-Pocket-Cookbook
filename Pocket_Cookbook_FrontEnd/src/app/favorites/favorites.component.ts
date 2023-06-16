import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Result } from '../meal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent {
  favoritedMeals:Result[] = [];

  constructor(private mealService:MealService, private router:Router) {
  }
  // Update the displayed list whenver the page is modified
  ngOnInit() {
    this.favoritedMeals = this.mealService.favoritedMeals;
  }

  // Stores the selected meal result in meal.service.ts as selectedMeal
  selectRecipe(r:Result):void{
    this.mealService.selectedMeal = r;
    this.router.navigate(['recipe']);
  }

  // Removes the favorited meal from meal.service.ts's favoritedMeals
  removeFavorite(index:number):void {
    this.mealService.favoritedMeals.splice(index, 1);
  }
}
