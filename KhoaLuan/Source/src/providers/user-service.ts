import { JsonHelper } from './../utilities/json-helper';
import { Configuration } from './../configuration';
import { User } from './../models/user.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {

    private userURI: string = Configuration.ApiURI + "users";
    private validationUserURI: string = Configuration.ApiURI + "validatedusername/";

    constructor(public http: Http) {
        console.log('---- Hello UserService Provider ----');
    }

    // Get user
    getUserById(userId: string) {
        return new Promise(resolve => {
            this.http.get(`${this.userURI}/${userId}`)
                .map(res => res.json())
                .subscribe((data: User) => {
                    resolve(data);
                    console.log(`[UserService][GetUser] Resolve data successfully: ${JSON.stringify(data)}.`);
                })
        })
    }

    // Create user
    created(user: User) {
        return new Promise(resolve => {
            this.http.post(this.userURI, JsonHelper.UserToJson(user), { headers: Configuration.getPostHeaderNonAuth() })
                .map(response => response.json())
                .subscribe(data => {
                    resolve(data);
                }, error => {
                    console.log(`[UserService][GetUser][ERROR: ${error}]`);
                    resolve("Có lỗi xảy ra khi tạo tài khoản. Vui lòng thử lại.");
                })
        })
    }

    // Updated
    updated(user: User) {
        return new Promise(resolve => {
            this.http.put(`${this.userURI}/${user.userId}`, JsonHelper.UserToJson(user), { headers: Configuration.getPostHeaderNonAuth() })
                .map(response => response.toString())
                .subscribe(data => {
                    resolve(data);
                }, error => {
                    console.log(`[UserService][Updated][ERROR: ${error}]`);
                    resolve(error);
                })
        })
    }


    // Validation user: true if user name is exist, else false.
    isExistUserName(userName: string) {
        return new Promise(resolve => {
            this.http.get(this.validationUserURI + userName)
                .map(res => res.toString())
                .subscribe(data => {
                    resolve(data);
                    console.log(`[UserService][IsExistUserName][${JSON.stringify(data)}]`);
                });
        });
    }
}
