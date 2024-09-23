import { Post } from './../../models/post.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class SharePostService {

    private post: Post;

    constructor(public http: Http) {
        console.log('---- Hello SharePostService Provider ----');
        this.post = new Post();
    }

    setOriginPost(post: Post){

        console.log(`[SharePostService][SetLocation]`);
        this.post = post;

    }

    getOriginPost() : Post {

        console.log(`[SharePostService][GetLocation]`);
        return this.post;

    }
}
