import { Configuration } from './../configuration';
import { Http } from '@angular/http';
import { URLSearchParams, Headers } from '@angular/http';
import { Token } from './../models/token.model';
import { Facebook } from 'ionic-native';
import { Platform } from 'ionic-angular';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class FacebookService {

    public Token: Token = new Token();
    private TokenURI: string = Configuration.ApiURI + "token";

    constructor(public platform: Platform, private http: Http) {
        console.log('---- Hello FacebookService Provider ----');
    }

    login() {
        var p = new Promise((resolve, reject) => {
            Facebook.login(['email'])
                .then(success => {
                    this.getAccessToken(success.authResponse.userID)
                        .then(data => {
                            resolve(success);
                        })
                })
                .catch(error => {
                    console.log(JSON.stringify(error));
                    reject(error);
                });
        });
        return p;
    }

    getCurrentUserProfile() {
        var p = new Promise((resolve, reject) => {
            Facebook.api('me?fields=email,name', null)
                .then(profileData => {
                    console.log(JSON.stringify(profileData));
                    resolve(profileData);
                })
                .catch(err => {
                    console.log(JSON.stringify(err));
                    reject(err);
                });
        });
        return p;
    }

    getAccessToken(userName: string) {
        let body = new URLSearchParams();
        body.set('username', userName);
        body.set('authtype', 'Facebook');
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return new Promise(resolve => {
            this.http.post(this.TokenURI, body, { headers: headers })
                .map(response => response.json())
                .subscribe(data => {
                    this.Token.access_token = data.access_token;
                    this.Token.expires_in = data.expires_in;
                    resolve(data);
                }, error => {
                    console.log('Error!');
                    resolve(error);
                });
        });
    }
}
