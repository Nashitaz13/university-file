import { Location } from './location.model';

export class User {
    username: string;
    password: string;
    confirmPassword: string;
    email: string;
    location: Location;
    displayName: string;
    gender: boolean;
    birthday: string;
    phone: string;
    aboutMe: string;
    avatarPath: string;
    userId: string;
    isAdmin: boolean;
    isVerify: boolean;

    constructor() {

        this.username =  "";
        this.password = "";
        this.confirmPassword = "";
        this.email = "";
        this.location = new Location();
        this.displayName = "";
        this.gender = true;
        this.birthday = "";
        this.phone = "";
        this.aboutMe = "";
        this.avatarPath = "img/default_user.png";

    }
}
