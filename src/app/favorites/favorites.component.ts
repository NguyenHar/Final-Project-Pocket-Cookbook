import { Component } from '@angular/core';
import { MealService } from '../meal.service';
import { Result } from '../meal';
import { Router } from '@angular/router';
import { UserFavoritesService } from '../user-favorites.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent {
  favoritedMeals:Result[] = [];

  constructor(private mealService:MealService, private router:Router, private userService:UserFavoritesService) {
  }
  // Update the displayed list whenver the page is modified
  ngOnInit() {
    // this.favoritedMeals = this.mealService.mealSelectionData.favoritedMeals;
    this.userService.getUserFavorites(this.userService.user.id).subscribe(
      (result) => {
        this.favoritedMeals = result;
      }
    );
  }

  // Stores the selected meal result in meal.service.ts as selectedMeal
  selectRecipe(r:Result):void{
    this.mealService.mealSelectionData.selectedMeal = r;
    this.router.navigate(['recipe']);
  }

  // Removes the favorited meal from meal.service.ts's favoritedMeals
  removeFavorite(index:number):void {
    this.userService.removeUserFavorite(this.userService.user.id, this.favoritedMeals[index].primary_key_id).subscribe(
      () => {
        this.favoritedMeals.splice(index, 1);
      }
    );

  }
}
