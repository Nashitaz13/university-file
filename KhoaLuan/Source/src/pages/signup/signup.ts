import { User } from './../../models/user.model';
import { Location } from './../../models/location.model';
import { UserService } from './../../providers/user-service';
import { UtilitiesService } from './../../providers/utilities-service';
import { HomePage } from './../home/home';
import { LoginPage } from './../login/login';
import { Component } from '@angular/core';
import { NavController, ToastController, Platform, LoadingController } from 'ionic-angular';
import { FormBuilder } from '@angular/forms';
import { Geolocation } from 'ionic-native';

@Component({
    selector: 'page-signup',
    templateUrl: 'signup.html',
    providers: [UtilitiesService, UserService]
})

export class SignUpPage {

    public loginPage: any;
    public homePage: any;
    public user: User;
    public location: Location;
    public errors: string;
    public platform: any;

    // Constructor
    constructor(private navCtrl: NavController,
        private formBuilder: FormBuilder,
        private utilitiesService: UtilitiesService,
        private toastControl: ToastController,
        private userService: UserService,
        public loadingCtrl: LoadingController,
        platform: Platform) {
        console.log(`--- Hello signup page ----`);

        this.user = new User();
        this.user.username = this.user.email = this.user.password = this.user.confirmPassword = "";

        // Set home page and login page
        this.loginPage = LoginPage;
        this.homePage = HomePage;

        this.platform = platform;

        this.location = new Location();

        // Get current location of user
        this.platform.ready().then(() => {
            console.log(`[SignUpPage][Constructor][Platform ready...]`);
            Geolocation.getCurrentPosition().then((resp) => {
                this.utilitiesService.getCountryName(resp.coords.latitude, resp.coords.longitude)
                    .then((data: string) => {
                        this.location.name = data;
                        this.location.longitude = resp.coords.longitude;
                        this.location.latitude = resp.coords.latitude;
                    })
            }).catch((error) => {
                this.errors = "* Không thể tìm được vị trí của bạn. Vui lòng kiểm tra internet.";
                console.log(`[SignUpPage][Constructor][ERROR][${error}]`);
            });
        });
    }

    // Create new account method
    createNewAccount() {
        console.log(JSON.stringify(this.user));
        if (this.canExecutedCommand()) {
            var user = new User();
            user.username = this.user.username;
            user.email = this.user.email;
            user.password = this.user.password;
            user.location = this.location;
            let loading = this.loadingCtrl.create({
                spinner: 'crescent',
                content: 'Đang kiểm tra...'
            });
            loading.present();
            // Call api create account
            this.userService.isExistUserName(user.username).then((result: boolean) => {
                if (result == true) {
                    loading.dismiss();
                    this.errors = "* Tên đăng nhập đã tồn tại.";
                }
                else {
                    this.userService.created(user).then(() => {
                            loading.dismiss();
                            this.toastInfo("Đăng nhập thành công.", 1000);
                            this.navCtrl.push(LoginPage);
                        })
                        .catch((err: string) => {
                            loading.dismiss();
                            this.errors = "* Có lỗi khi tạo tài khoản. Vui lòng thử lại lần nữa.";
                            console.log(`[SignUpPage][CreateNewAccount][ERROR][${err}]`);
                        });
                }
            }).catch(error => {
                loading.dismiss();
                this.errors = "* Có lỗi xảy ra. Vui lòng kiểm tra lại kết nối internet.";
            });
        }
    }
    // Can execute command
    private canExecutedCommand() {
        if (this.validated()) {
            return true;
        }
        else {
            return false;
        }
    }

    // Validated data
    private validated() {
        // Step 1: Validated requied
        if (this.user.username == "" || this.user.email == "" ||
            this.user.password == "" || this.user.confirmPassword == "") {
            this.errors = "(*) là bắt buộc.";
            return false;
        }
        // Step 2: Validated email

        // Step 3: Validated password

        // Step 4: Validated confirm password
        if (this.user.password != this.user.confirmPassword) {
            this.errors = "* Xác nhận mật khẩu không chính xác.";
            return false;
        }
        return true;
    }

    // Display toast info
    toastInfo(message: string, timeout: number) {
        let toast = this.toastControl.create({
            message: message,
            duration: timeout,
            dismissOnPageChange: true,
            cssClass: "toastInfoCss",
        });
        toast.present();
    }

    // Display toast error
    toastError(message: string, timeout: number) {
        let toast = this.toastControl.create({
            message: message,
            duration: timeout,
            dismissOnPageChange: true,
            cssClass: "toastErrorCss",
        });
        toast.present();
    }
}
