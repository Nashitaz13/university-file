import { ShareLocationService } from './../../providers/shared/share-location-service';
import { User } from './../../models/user.model';
import { UserService } from './../../providers/user-service';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { ForgotPasswordPage } from './../forgotpassword/forgotpassword';
import { SignUpPage } from './../signup/signup';
import { HomePage } from './../home/home';
import { AuthService } from './../../providers/auth-service';
import { Facebook, OneSignal } from 'ionic-native';
import { FacebookService } from './../../providers/facebook-service';
import { Component, ViewChild } from '@angular/core';
import { NavController, ToastController, Platform, Content, LoadingController } from 'ionic-angular';
import { Configuration } from './../../configuration';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html',
    providers: [FacebookService, AuthService, UserService]
})

export class LoginPage {
    @ViewChild(Content) content: Content;

    public username: string;
    public password: string;
    public errors: string;
    public registerPage: any;
    public forgotpasswordPage: any;
    public store: any;

    private loginCount: number = 0;
    private timeLoginFail: Date;
    private defaultTimeLoginFail: number = 30000;

    constructor(public platform: Platform,
        public navCtrl: NavController,
        public toastCtrl: ToastController,
        private shareLocationService: ShareLocationService,
        public loadingCtrl: LoadingController,
        public authService: AuthService,
        public facebookService: FacebookService,
        public userService: UserService) {
        console.log('Hello LoginPage page.');
        // Init login facebook
        this.platform.ready().then(() => {
            if (this.platform.is('android')) {
                Facebook.browserInit(Configuration.FacebookAppId, "v2.8")
                    .then(resp => {
                        alert('fb  browser init');
                    })
            }
        });

        // Init value
        this.registerPage = SignUpPage;
        this.forgotpasswordPage = ForgotPasswordPage;
        this.errors = "";
        this.username = "";
        this.password = "";
    }

    checkConditionLogin() {
        if (this.loginCount >= 3) {
            var currentTime = new Date();
            if (currentTime.getTime() - this.timeLoginFail.getTime() > this.defaultTimeLoginFail) {
                this.loginCount = 0;
                return true;
            }
            this.errors = '* Đăng nhập sai quá 3 lần. Vui lòng chờ 30 giây!';
            return false;
        }
        return true;
    }

    loginFailChange() {
        this.loginCount += 1;
        this.timeLoginFail = new Date();
        console.log(`[LoginPage][Login] LoginCount ${this.loginCount}`);
    }

    login() {
        this.errors = "";
        if (this.checkConditionLogin()) {
            if (this.username != "" && this.password != "") {
                let loading = this.loadingCtrl.create({
                    spinner: 'crescent',
                    content: 'Vui lòng đợi...'
                });
                loading.present();
                this.authService.login(this.username, this.password)
                    .then((data) => {
                        if (ApplicationUserProvider.UserId != "") {
                            this.userService.getUserById(ApplicationUserProvider.UserId)
                                .then((data: User) => {
                                    console.log(`[LoginPage][Login][Set application user]`);
                                    // Update current location
                                    data.location = this.shareLocationService.getLocation();
                                    this.userService.updated(data).then(() => {
                                        console.log(`[LoginPage][Login] Updated current location of user successfully.`);
                                        ApplicationUserProvider.SetApplicationUser(data);
                                        // Set tags on onesignal
                                        OneSignal.sendTag('user_id', data.userId);
                                        loading.dismiss();
                                        this.navCtrl.push(HomePage);
                                    })
                                        .catch((error) => {
                                            alert(`Có lỗi xảy ra. ${error}`);
                                        })
                                })
                        }
                        else {
                            loading.dismiss();
                            this.errors = '* Đăng nhập thất bại.';
                            this.loginFailChange();
                        }
                    })
                    .catch(error => {
                        loading.dismiss();
                        this.errors = '* Có lỗi xảy ra.' + error;
                    });
            }
            else {
                this.errors = '* Tên đăng nhập và mật khẩu là bắt buộc.';
            }
        }
    }


    loginViaFacebook() {
        this.facebookService.login().then((data) => {
            // Token is not null
            if (this.facebookService.Token.access_token != null) {
                //TODO: Save access token to native storage
                this.showCustomToast('Đăng nhập thành công.');
                this.navCtrl.push(HomePage);
            }
            else {
                this.errors = '* Đăng nhập thất bại.';
            }
        });
    }

    private showCustomToast(message: string) {
        let toast = this.toastCtrl.create({
            message: message,
            duration: 2000
        });
        toast.present();
    }

    openforgotpasswordPage() {
        this.navCtrl.push(ForgotPasswordPage);
    }
}
