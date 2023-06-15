// To parse this data:
//
//   import { Convert, Meal } from "./file";
//
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
    meal:           null;
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
