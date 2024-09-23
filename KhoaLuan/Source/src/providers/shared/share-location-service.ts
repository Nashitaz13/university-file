import { Location } from './../../models/location.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ShareLocationService {

    private location: Location;

    constructor(public http: Http) {
        console.log('---- Hello ShareLocationService Provider ----');
        this.location = new Location();
    }

    setLocation(location: Location){

        console.log(`[ShareLocationService][SetLocation][${location.latitude}, ${location.longitude}, ${location.name}]`);
        this.location = location;

    }

    getLocation() : Location {

        console.log(`[ShareLocationService][GetLocation][${this.location.latitude}, ${this.location.longitude}, ${this.location.name}]`);
        return this.location;

    }
}
