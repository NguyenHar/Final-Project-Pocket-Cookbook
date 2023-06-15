// To parse this data:
//
//   import { Convert, Recipe } from "./file";
//
//   const recipe = Convert.toRecipe(json);

export interface Recipe {
    primary_key_id:           number;
    id:                       number;
    vegetarian:               boolean;
    vegan:                    boolean;
    glutenFree:               boolean;
    dairyFree:                boolean;
    veryHealthy:              boolean;
    cheap:                    boolean;
    veryPopular:              boolean;
    sustainable:              boolean;
    lowFodmap:                boolean;
    weightWatcherSmartPoints: number;
    gaps:                     string;
    preparationMinutes:       number;
    cookingMinutes:           number;
    aggregateLikes:           number;
    healthScore:              number;
    creditsText:              string;
    sourceName:               string;
    pricePerServing:          number;
    title:                    string;
    readyInMinutes:           number;
    servings:                 number;
    sourceUrl:                string;
    image:                    string;
    imageType:                string;
    summary:                  string;
    instructions:             string;
    extendedIngredients:      ExtendedIngredient[];
    analyzedInstructions:     AnalyzedInstruction[];
    spoonacularSourceUrl:     string;
}

export interface AnalyzedInstruction {
    primary_key_id: number;
    id:             number;
    name:           string;
    steps:          Step[];
    recipe:         null;
    recipeFK:       number;
}

export interface Step {
    primary_key_id:        number;
    id:                    number;
    number:                number;
    step:                  string;
    ingredients:           any[];
    equipment:             Equipment[];
    analyzedInstruction:   null;
    analyzedInstructionFK: number;
}

export interface Equipment {
    primary_key_id: number;
    id:             number;
    name:           string;
    localizedName:  string;
    image:          string;
    step:           null;
    stepFK:         number;
}

export interface ExtendedIngredient {
    primary_key_id: number;
    id:             number;
    aisle:          string;
    image:          null | string;
    consistency:    string;
    name:           string;
    nameClean:      null | string;
    original:       string;
    originalName:   string;
    amount:         number;
    unit:           string;
    measures:       Measures;
    recipe:         null;
    recipeFK:       number;
}

export interface Measures {
    primary_key_id: number;
    id:             number;
    us:             Metric;
    metric:         Metric;
}

export interface Metric {
    primary_key_id: number;
    id:             number;
    amount:         number;
    unitShort:      string;
    unitLong:       string;
}

// Converts JSON strings to/from your types
export class Convert {
    public static toRecipe(json: string): Recipe {
        return JSON.parse(json);
    }

    public static recipeToJson(value: Recipe): string {
        return JSON.stringify(value);
    }
}
