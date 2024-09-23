import { ShareLocationService } from './../../providers/shared/share-location-service';
import { Location } from './../../models/location.model';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';

declare var google;

@Component({
    selector: 'page-google-map-page',
    templateUrl: 'google-map-page.html'
})
export class GoogleMapPagePage {

    @ViewChild('map') mapElement: ElementRef;
    originLocation: Location;

    constructor(public navCtrl: NavController, private shareLocationService: ShareLocationService, private modalCtrl: ModalController) { }

    ionViewDidLoad() {
        console.log('---- Hello GoogleMapPagePage Page ----');
        this.originLocation = new Location();
        this.initMap();
    }

    initMap() {

        console.log(`[GoogleMapPagePage][InitMap][CurrentLocation = <${this.shareLocationService.getLocation().latitude}, ${this.shareLocationService.getLocation().longitude}>]`);
        this.originLocation = this.shareLocationService.getLocation();
        let latLng = new google.maps.LatLng(this.shareLocationService.getLocation().latitude, this.shareLocationService.getLocation().longitude);

        let mapOptions = {
            center: latLng,
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControlOptions: {
                style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
                position: google.maps.ControlPosition.BOTTOM_CENTER
            }
        }
        var map = new google.maps.Map(document.getElementById('map'), mapOptions);

        var marker = new google.maps.Marker({
            position: latLng,
            title: "Vị trí của bạn",
            animation: google.maps.Animation.BOUNCE
        });

        // Add marker to map
        marker.setMap(map);

        // Click marker to zoom
        marker.addListener('click', function () {
            this.map.setZoom(20);
            this.map.setCenter(marker.getPosition());
        });

        var input = /** @type {!HTMLInputElement} */(
            document.getElementById('pac-input'));

        map.controls[google.maps.ControlPosition.TOP_CENTER].push(input);

        var autocomplete = new google.maps.places.Autocomplete(input);
        autocomplete.bindTo('bounds', map);

        var infowindow = new google.maps.InfoWindow();
        marker = new google.maps.Marker({
            map: map,
            anchorPoint: new google.maps.Point(0, -29),
            animation: google.maps.Animation.BOUNCE
        });

        autocomplete.addListener('place_changed', function () {
            infowindow.close();
            marker.setVisible(false);
            var place = autocomplete.getPlace();
            if (!place.geometry) {
                // User entered the name of a Place that was not suggested and
                // pressed the Enter key, or the Place Details request failed.
                window.alert("Không tìm được địa điểm bạn vừa nhập: '" + place.name + "'");
                return;
            }

            // If the place has a geometry, then present it on a map.
            if (place.geometry.viewport) {
                map.fitBounds(place.geometry.viewport);
            } else {
                map.setCenter(place.geometry.location);
                map.setZoom(17);  // Why 17? Because it looks good.
            }
            marker.setPosition(place.geometry.location);
            marker.setVisible(true);
            var address = '';
            if (place.address_components) {
                address = [
                    (place.address_components[0] && place.address_components[0].short_name || ''),
                    (place.address_components[1] && place.address_components[1].short_name || ''),
                    (place.address_components[2] && place.address_components[2].short_name || '')
                ].join(' ');
            }

            infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
            infowindow.open(map, marker);
        });

    }

    updateLocation() {

    }
}
