import { Component, OnInit, ViewChild } from '@angular/core';
import { Data, Router } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { KrogerService } from '../kroger.service';
import { Datum, KrogerProduct } from '../kroger';
import { KrogerLocation, LocationDatum } from '../krogerlocation';
import { MapMarker } from '@angular/google-maps';


@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit{
  currentShoppingList:string[]= [];
  krogerSearchResults:Datum[][] = [];
  itemForCart:KrogerProduct = {} as KrogerProduct;
  cartTotal:number = 0;

  KrogerLocations:KrogerLocation = {} as KrogerLocation;
  // Holmes Hall geolocations
  Lat:number = 42.725677;
  Long:number = -84.466215;
  zoom = 13;
  center: google.maps.LatLngLiteral = {lat:42.7266646, lng:-84.4668331};
  mapOptions: google.maps.MapOptions = {
    mapTypeId: 'roadmap',

  };
  markers: MapMarker[] = [];

  
  constructor(private recipeService:RecipeService, private krogerService:KrogerService, 
    private router:Router) 
  {
    let homeMarker:MapMarker = {} as MapMarker;
    homeMarker.position = {} as MapMarker["position"];  
    homeMarker.position.lat = this.Lat;
    homeMarker.position.lng = this.Long;
    homeMarker.label = { color: 'black', text: 'My Location' };
    homeMarker.title = "Holmes Hall";

    this.markers.push(homeMarker);
  }

  ngOnInit(){
    this.currentShoppingList = this.krogerService.shoppingList;
    this.krogerSearchResults = this.krogerService.productsToShop;   
    
    // Call kroger api to return a list of locations within a radius of a given location
    // Add each location to the google map
    this.krogerService.getKrogerLocations(this.Lat,this.Long).subscribe(
      (result) => {
        this.KrogerLocations = result;
        for (let i=0; i<result.data.length; i++)
        {
          this.addMarker(result.data[i]);
        }
      }
    );
  }

  // Add a marker on the google map based on a given kroger location object
  addMarker(location:LocationDatum) : void {
    let newMarker:MapMarker = {} as MapMarker;
    newMarker.position = {lat: location.geolocation.latitude, lng: location.geolocation.longitude};
    newMarker.label = { color: 'black', text: `${location.name}` };
    newMarker.title = `${location.name}`;
    this.markers.push(newMarker);

    this.krogerSearchResults = this.krogerService.productsToShop;
    console.log(this.krogerSearchResults)
  }

  clearShoppingList():void{
    let emptyStringArray:string[]=[];
    this.krogerService.shoppingList = emptyStringArray; 
  }


  goToRecipe():void{
    this.router.navigate(["recipe"]);
  }

  addToCart():void{ 
    let shoppingCart:Datum[] = [];
    for (let i = 0; i < this.krogerSearchResults.length; i++)
    {
      this.krogerSearchResults[i].forEach((kProduct:Datum) => {
        let item:HTMLInputElement = document.getElementById(kProduct.productId) as HTMLInputElement;
        console.log(item);
        console.log(item.checked);
        if(item.checked)
        {
          shoppingCart.push(kProduct);
          this.cartTotal += kProduct.items[0].price.regular;
        }
        
      });     
    }
  }
}
