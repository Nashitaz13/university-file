import { WorkAnywhereProvider } from './../providers/work-anywhere-provider';
import { Configuration } from './../configuration';
import { ConfigService } from './../providers/config-service';
import { BookmarksService } from './../providers/bookmarks-service';
import { PubNubService } from './../providers/pubnub-service';
import { UnitsService } from './../providers/units-service';
import { CategoryService } from './../providers/category-service';
import { ContractTypeService } from './../providers/contract-type-service';
import { ShareLocationService } from './../providers/shared/share-location-service';
import { UtilitiesService } from './../providers/utilities-service';
import { LoginPage } from './../pages/login/login';
import { Component } from '@angular/core';
import { Platform, ToastController } from 'ionic-angular';
import { StatusBar, Splashscreen, OneSignal, Geolocation } from 'ionic-native';
import { TranslateService } from 'ng2-translate';
import './rxjs-operators';

@Component({
    templateUrl: 'app.html',
    providers: [UtilitiesService, PubNubService]
})
export class MyApp {
    rootPage = LoginPage;
    platform: any;

    constructor(platform: Platform, private translate: TranslateService,
        private utilitiesService: UtilitiesService,
        private shareLocationService: ShareLocationService,
        private contractTypeService: ContractTypeService,
        private categoryService: CategoryService,
        private unitsService: UnitsService,
        private toastCtrl: ToastController,
        private bookmarksDB: BookmarksService,
        private configDB: ConfigService) {
        this.platform = platform;
        this.platform.ready().then(() => {
            // Okay, so the platform is ready and our plugins are available.
            // Here you can do any higher level native things you might need.
            console.log(`App is ready...`);
            StatusBar.styleDefault();
            Splashscreen.hide();
            translate.setDefaultLang('vi');
            translate.use('vi');
            // Add the following to your existing ready fuction.
            this.initData();
            this.initializePushNotification();
        });
    }

    initData() {
        // Get country name
        navigator.geolocation.getCurrentPosition(
            (resp) => {
                if (resp.coords.latitude != null && resp.coords.longitude != null) {
                    this.showCustomToast(`Cập nhật vị trí hiện tại thành công.`);
                }
                this.utilitiesService.getCountryName(resp.coords.latitude, resp.coords.longitude)
                    .then((data: string) => {
                        this.shareLocationService.setLocation({ latitude: resp.coords.latitude, longitude: resp.coords.longitude, name: data });// Set location to share location service
                    })
            },
            (error) => {
                // alert(`Không thể tìm thấy vị trí của bạn. Vui lòng kiểm tra GPS và kết nối internet. Chi tiết: ${error.message}`);
                // Hard code
                this.utilitiesService.getCountryName(10.8629465, 106.8101102)
                    .then((data: string) => {
                        this.shareLocationService.setLocation({ latitude: 10.8629465, longitude: 106.8101102, name: data });// Set location to share location service
                    })
            }, { maximumAge: 3000, timeout: 5000, enableHighAccuracy: true });

        // Get category
        this.categoryService.load()
            .then(data => {
                this.configDB.initDatabase();
            })
            .catch(err => {
                this.showCustomToast(`Không thể kết nối tới cơ sở dữ liệu. Vui lòng kiểm tra kết nối internet.`);
                alert(err);
            });
        this.contractTypeService.load();
        this.unitsService.load();
        // Init local database
        this.bookmarksDB.initDatabase();
    }

    initializePushNotification() {
        OneSignal.startInit(Configuration.OneSignalAppId, Configuration.OneSignalProjectNumber);
        OneSignal.inFocusDisplaying(OneSignal.OSInFocusDisplayOption.InAppAlert);
        OneSignal.setSubscription(true);
        OneSignal.handleNotificationReceived().subscribe((data) => {
            // do something when the notification is received. Updated new message count notification
            var result = data.notification.payload.additionalData;
            if (result && result.data) {
                if (result.data.type) {
                    if (result.data.type == 'chat') {
                        WorkAnywhereProvider.getInstance().newMessageCount += 1;
                    }
                }
            }
        });
        OneSignal.handleNotificationOpened().subscribe((data) => {
            // do something when the notification is opened.
            var result = data.notification.payload.additionalData;
            if (result && result.data) {
                if (result.data.type) {
                    if (result.data.type == 'chat') {
                        WorkAnywhereProvider.getInstance().newMessageCount -= 1;
                        if (WorkAnywhereProvider.getInstance().newMessageCount < 0) {
                            WorkAnywhereProvider.getInstance().newMessageCount = 0;
                        }
                    }
                }
            }
        });
        OneSignal.inFocusDisplaying(2);
        OneSignal.endInit();
        OneSignal.getIds().then(data => {
            // this gives you back the new userId and pushToken associated with the device. Helpful.
        });
    }

    exitApp() {
        this.platform.exitApp();
    }

    private showCustomToast(message: string) {
        let toast = this.toastCtrl.create({
            message: message,
            duration: 2000
        });
        toast.present();
    }
}
