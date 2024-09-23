import { Location } from './../models/location.model';
import { User } from './../models/user.model';
import { Post } from './../models/post.model';

export class JsonHelper {

    static PostToJSON(post: Post) {
        return JSON.stringify(post);
    }

    static UserToJson(user: User) {
        return JSON.stringify(user);
    }

    static LocationToJson(location: Location) {
        return JSON.stringify(location);
    }
}