import { WorkAnywhereProvider } from './../../providers/work-anywhere-provider';
import { ChatManagerPage } from './../chat-manager/chat-manager';
import { Post } from './../../models/post.model';
import { ShareLocationService } from './../../providers/shared/share-location-service';
import { PostService } from './../../providers/post-service';
import { NotificationPage } from './../notification/notification';
import { PostPage } from './../post/post';
import { Component } from '@angular/core';
import { NavController, LoadingController, MenuController } from 'ionic-angular';

declare var google;

@Component({
    selector: 'page-post-map',
    templateUrl: 'post-map.html',
    providers: [PostService]
})
export class PostMapPage {

    map: any;
    posts: any[];
    workers: any[];
    markers = [];
    segment: string;
    latLng: any;
    msgCount: number;

    constructor(public navCtrl: NavController, private shareLocationService: ShareLocationService, private loadingCtrl: LoadingController, private postService: PostService, public menuCtrl: MenuController) {
        this.segment = "job";
    }

    ionViewDidLoad() {
        console.log('---- Hello PostMapPagePage Page ----');
        this.initMap();
        this.loadJob(false);
        this.msgCount = WorkAnywhereProvider.getInstance().newMessageCount;

    }

    openMenu() {
        this.menuCtrl.open();
    }

    openChatManagerPage() {
        this.navCtrl.push(ChatManagerPage);
    }

    addPost() {
        this.navCtrl.push(PostPage, { isCreated: true });
    }

    viewNotification() {
        this.navCtrl.push(NotificationPage);
    }

    initMap() {

        this.latLng = new google.maps.LatLng(this.shareLocationService.getLocation().latitude, this.shareLocationService.getLocation().longitude);
        console.log(`[PostMapPage][InitMap][latLng][${this.latLng}]`);
        let mapOptions = {
            center: this.latLng,
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControlOptions: {
                style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
                position: google.maps.ControlPosition.BOTTOM_CENTER
            }
        }
        this.map = new google.maps.Map(document.getElementById('postmap'), mapOptions);

        this.addUserMarker(this.latLng);
    }

    addUserMarker(latLng: any) {
        var marker = new google.maps.Marker({
            position: latLng,
            title: "Vị trí của bạn",
            animation: google.maps.Animation.BOUNCE
        });
        // Add marker to map
        marker.setMap(this.map);
        this.markers.push(marker);
    }

    addOtherMarker(latLng: any, title: string) {
        var marker = new google.maps.Marker({
            position: latLng,
            title: title,
            animation: google.maps.Animation.DROP
        });
        marker.setMap(this.map);
        this.markers.push(marker);
    }

    removeAllMarker() {
        for (var i = 0; i < this.markers.length; i++) {
            this.markers[i].setMap(null);
        }
        this.markers = [];
    }

    changeMarker() {
        this.removeAllMarker();
        if (this.segment == "job") {
            this.loadJob(false);
        }
        else {
            this.loadWorker(false);
        }
    }

    loadJob(isRefresh: boolean) {
        let loader = this.loadingCtrl.create({
            content: "Vui lòng chờ..."
        });
        loader.present();
        this.postService.load(isRefresh, "Job")
            .then((data: any[]) => {
                this.posts = data;
                this.addUserMarker(this.latLng);
                this.posts.forEach((element: Post) => {
                    let latLng = new google.maps.LatLng(element.location.latitude, element.location.longitude);
                    this.addOtherMarker(latLng, element.title);
                });
                loader.dismiss();
            })
            .catch(error => {
                loader.dismiss();
                console.log(`[PostListPage][DoRefresh][ERROR][${error}]`);
            });
    }

    loadWorker(isRefresh: boolean) {
        let loader = this.loadingCtrl.create({
            content: "Vui lòng chờ..."
        });
        loader.present();
        this.postService.load(isRefresh, "Worker")
            .then((data: any[]) => {
                this.workers = data;
                this.addUserMarker(this.latLng);
                this.workers.forEach((element: Post) => {
                    let latLng = new google.maps.LatLng(element.location.latitude, element.location.longitude);
                    this.addOtherMarker(latLng, element.title);
                });
                loader.dismiss();
            })
            .catch(error => {
                loader.dismiss();
                console.log(`[PostListPage][DoRefresh][ERROR][${error}]`);
            });
    }
}
