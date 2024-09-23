import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UtilitiesService {

  constructor(public http: Http) {
        console.log(`---- Hello utilities service ----`);
  }

  // Get city name from geolocation via google map api
  getCountryName(latitude: number, longitude: number){
    console.log(`[UtilitiesService][GetCountryName][Entry function...]`);
    var apiURI = 'http://maps.googleapis.com/maps/api/geocode/json?latlng='+ latitude + ',' + longitude + '&sensor=false';
    console.log(`[UtilitiesService][GetCountryName][API URI][${apiURI}]`);
     return new Promise(resolve => {                  
            this.http.get(apiURI)
                .map(res => res.json())
                .subscribe(data => {
                    resolve(data.results[0].formatted_address);
                    console.log(`[UtilitiesService][GetCountryName][End function.]`);
                });
        });
  }
}
