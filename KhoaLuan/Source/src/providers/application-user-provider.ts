import { User } from './../models/user.model';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class ApplicationUserProvider {

    public static UserName: string = "";
    public static UserId: string = "";
    public static User: User;

    public static SetUser(userName: string, id: string) {
        console.log(`[ApplicationUserProvider][SetUser][${userName}, ${id}]`);
        this.UserName = userName;
        this.UserId = id;
    }

    public static SetApplicationUser(user: User) {
        console.log(`[ApplicationUserProvider][SetApplicationUser] user: ${JSON.stringify(user)}`);
        this.User = user;
    }

    public static ClearApplicationUser() {
        console.log(`[ApplicationUserProvider][ClearApplicationUser]`);
        this.UserName = "";
        this.UserId = "";
        this.User = null;
    }
}
