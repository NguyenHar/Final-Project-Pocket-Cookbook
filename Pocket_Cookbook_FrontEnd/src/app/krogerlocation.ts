// To parse this data:
//
//   import { Convert, KrogerLocation } from "./file";
//
//   const krogerLocation = Convert.toKrogerLocation(json);

export interface KrogerLocation {
    primary_key_id: number;
    data:           LocationDatum[];
}

export interface LocationDatum {
    primary_key_id: number;
    address:        Address;
    chain:          string;
    phone:          string;
    geolocation:    Geolocation;
    locationId:     string;
    storeNumber:    string;
    divisionNumber: string;
    name:           string;
    krogerLocation: null;
    krogerFK:       number;
}

export interface Address {
    primary_key_id: number;
    addressLine1:   string;
    addressLine2:   null;
    city:           string;
    county:         string;
    state:          string;
    zipCode:        string;
}

export interface Geolocation {
    primary_key_id: number;
    latLng:         string;
    latitude:       number;
    longitude:      number;
}

// Converts JSON strings to/from your types
export class Convert {
    public static toKrogerLocation(json: string): KrogerLocation {
        return JSON.parse(json);
    }

    public static krogerLocationToJson(value: KrogerLocation): string {
        return JSON.stringify(value);
    }
}
