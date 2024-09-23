import { Location } from './../../models/location.model';
import { Component, Input } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
declare var google;

@Component({
    selector: 'page-google-map-direction-list',
    templateUrl: 'google-map-direction-list.html'
})
export class GoogleMapDirectionListPage {

    @Input() startLocation: Location;
    @Input() destinateLocation: Location;

    constructor(public navCtrl: NavController,
        private navParams: NavParams) {
        this.startLocation = new Location();
        this.destinateLocation = new Location();
    }

    ionViewDidLoad() {
        console.log('Hello GoogleMapDirectionPage Page');
        this.startLocation = this.navParams.get(`startLocation`);
        this.destinateLocation = this.navParams.get(`destinateLocation`);
        this.initMap();
    }

    initMap() {
        var directionsService = new google.maps.DirectionsService;
        var directionsDisplay = new google.maps.DirectionsRenderer;
        var map = new google.maps.Map(document.getElementById('map-direction-list'), {
            zoom: 15,
            center: { lat: this.startLocation.latitude, lng: this.startLocation.longitude }
        });
        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('panel'));
        this.calculateAndDisplayRoute(directionsService, directionsDisplay);
    }

    calculateAndDisplayRoute(directionsService, directionsDisplay) {
        directionsService.route({
            origin: { lat: this.startLocation.latitude, lng: this.startLocation.longitude },
            destination: { lat: this.destinateLocation.latitude, lng: this.destinateLocation.longitude },
            travelMode: 'DRIVING'
        }, function (response, status) {
            if (status === 'OK') {
                directionsDisplay.setDirections(response);
            } else {
                alert('Không tìm được địa điểm này. Status code: ' + status);
            }
        });
    }

}
