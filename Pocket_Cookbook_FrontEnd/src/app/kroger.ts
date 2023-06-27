// To parse this data:
//
//   import { Convert, KrogerProduct } from "./file";
//
//   const krogerProduct = Convert.toKrogerProduct(json);

export interface KrogerProduct {
    primary_key_id: number;
    data:           Datum[];
    meta:           Meta;
}

export interface Datum {
    primary_key_id: number;
    productId:      string;
    upc:            string;
    brand:          string;
    countryOrigin:  string;
    description:    string;
    images:         Image[];
    items:          Item[];
    product:        null;
    productFK:      number;
}

export interface Image {
    primary_key_id: number;
    perspective:    string;
    sizes:          Size[];
    featured:       boolean;
    data:           null;
    dataFK:         number;
}

export interface Size {
    primary_key_id: number;
    size:           string;
    url:            string;
    img:            null;
    imgFK:          number;
}

export interface Item {
    primary_key_id: number;
    itemId:         string;
    inventory:      Inventory;
    favorite:       boolean;
    fulfillment:    Fulfillment;
    price:          Price;
    size:           string;
    soldBy:         string;
    data:           null;
    dataFK:         number;
}

export interface Fulfillment {
    primary_key_id: number;
    curbside:       boolean;
    delivery:       boolean;
    inStore:        boolean;
    shipToHome:     boolean;
}

export interface Inventory {
    primary_key_id: number;
    stockLevel:     string;
}

export interface Price {
    primary_key_id: number;
    regular:        number;
    promo:          number;
}

export interface Meta {
    primary_key_id: number;
    pagination:     Pagination;
    product:        null;
    productFK:      number;
}

export interface Pagination {
    primary_key_id: number;
    start:          number;
    limit:          number;
    total:          number;
    meta:           null;
    metaFK:         number;
}

// Converts JSON strings to/from your types
export class Convert {
    public static toKrogerProduct(json: string): KrogerProduct {
        return JSON.parse(json);
    }

    public static krogerProductToJson(value: KrogerProduct): string {
        return JSON.stringify(value);
    }
}
