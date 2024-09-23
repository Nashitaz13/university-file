import { ApplicationUserProvider } from './application-user-provider';
import { Token } from './../models/token.model';
import { Configuration } from './../configuration';
import { Injectable } from '@angular/core';
import { Http, Headers, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthService {

    private TokenURI: string = Configuration.ApiURI + "token";
    public Token: Token = new Token();

    constructor(public http: Http) {
        console.log('---- Hello AuthService Provider ----');
    }

    login(username: string, password: string) {
        let body = new URLSearchParams();
        body.set('username', username);
        body.set('password', password);
        body.set('authtype', 'Manual');
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return new Promise(resolve => {
            this.http.post(this.TokenURI, body, { headers: headers })
                .map(response => response.json())
                .subscribe(data => {
                    this.Token.access_token = data.access_token;
                    this.Token.expires_in =  data.expires_in;
                    ApplicationUserProvider.SetUser(username, data.id);// Skip user name
                    resolve(data);
                }, error => {
                    console.log(`[AuthService][Login][ERROR...][${error}]`);
                    resolve(error);
                });
        });
    }

    loginFacebook(username: string){
        let body = new URLSearchParams();
        body.set('username', username);
        body.set('password', "");
        body.set('authtype', 'Facebook');
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return new Promise(resolve => {
            this.http.post(this.TokenURI, body, { headers: headers })
                .map(response => response.json())
                .subscribe(data => {
                    this.Token.access_token = data.access_token;
                    this.Token.expires_in =  data.expires_in;
                    ApplicationUserProvider.SetUser(username, data.id);// Skip user name
                    resolve(data);
                }, error => {
                    console.log(`[AuthService][LoginFacebook][ERROR...][${error}]`);
                    resolve(error);
                });
        });
    }
}
