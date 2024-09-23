import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
    selector: 'page-forgotpassword',
    templateUrl: 'forgotpassword.html'
})

export class ForgotPasswordPage {

    public username: string;
    public email: string;
    public errors: string;

    constructor(public navCtrl: NavController) {
        this.username = "";
        this.errors = "";
        this.username = "";
    }

    get_password() {
        console.log("model-based form submitted");
    }

}
