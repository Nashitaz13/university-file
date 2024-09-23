import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { Component } from '@angular/core';
import { NavController, MenuController, ToastController, App } from 'ionic-angular';
import { UserService } from './../../providers/user-service';
import { User } from './../../models/user.model';
import { Location } from './../../models/location.model';

import { HomePage } from '../home/home';

@Component({
    selector: 'page-user',
    templateUrl: 'user.html',
    providers: [UserService]
})

export class UserPage {

    edituserForm: any;
    homePage: any = HomePage;
    minYear: number = 1950;
    maxYear: number = 2050;
    public user: User;
    public location: Location;
    public errors: string;

    constructor(public navCtrl: NavController,
        public menuCtrl: MenuController,
        private toastControl: ToastController,
        private userService: UserService,
        private app: App) {
        this.user = new User();
        this.location = new Location();
    }

    ionViewDidLoad() {
        console.log('---- Hello view user Page ----');
        this.load();
        this.user.birthday = (new Date(1994, 11, 2)).toISOString();
        this.calculateYear();
    }

    private validated() {
        // Step 1: Validated requied
        if (this.user.displayName == "" || this.user.email == "" ||
            this.user.birthday == "" || this.user.phone == "") {
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

    private calculateYear() {
        var currentTime = new Date();
        console.log(`[UserPage][calculateAge] currentTime = ${currentTime}`);
        // Cal min age
        this.minYear = currentTime.getUTCFullYear() - 60;
        console.log(`[UserPage][calculateAge] minYear = ${this.minYear}`);
        // Cal max age
        this.maxYear = currentTime.getUTCFullYear() - 14;
        console.log(`[UserPage][calculateAge] maxYear = ${this.maxYear}`);

    }

    showMessage(message: string, timeout: number) {
        let toast = this.toastControl.create({
            message: message,
            duration: timeout,
            dismissOnPageChange: true,
            cssClass: "toastErrorCss",
        });
        toast.present();
    }

    load() {
        this.user = ApplicationUserProvider.User;
    }

    save() {
        if (!this.validated()) {
            // Show toast with error message validations
            this.userService.updated(this.user)
                .then((data: boolean) => {
                    this.showMessage("Cập nhật thông tin người dùng thành công.", 1500);
                })
                .catch(() => {
                    this.errors = `* Có lỗi xảy ra. Vui lòng kiểm tra kết nối mạng.`;
                })
        }
    }

}
