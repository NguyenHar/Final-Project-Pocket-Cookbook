// To parse this data:
//
//   import { Convert, Meal } from "./file";
//

import { Recipe } from "./recipe";

//   const meal = Convert.toMeal(json);
export interface Meal {
    primary_key_id: number;
    id:             number;
    results:        Result[];
    offset:         number;
    number:         number;
    totalResults:   number;
}
export interface Result {
    primary_key_id: number;
    id:             number;
    title:          string;
    image:          string;
    imageType:      string;
    meal:           Meal;
}

export interface MealSelection {
    selectedMeal:   Result;
    selectedSearch: string;
    query:          string;
    time:           number;
    newValue:       number;
    recipes:        Recipe[];
    resultsList:    Result[];
    favoritedMeals: Result[];
}


// Converts JSON strings to/from your types
export class Convert {
    public static toMeal(json: string): Meal {
        return JSON.parse(json);
    }
    public static mealToJson(value: Meal): string {
        return JSON.stringify(value);
    }
}
