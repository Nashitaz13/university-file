import { Post } from './../../models/post.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class SharePostsService {

    private jobs: Post[] = [];
    private workers: Post[] = [];

    constructor(public http: Http) {
        console.log('---- Hello SharePostsService Provider ----');
    }

    set(posts: Post[], type: string) {

        console.log(`[SharePostsService][SetListPosts]`);
        if (type == "Job") {
            this.jobs = posts;
        }
        else {
            this.workers = posts;
        }

    }

    get(type: string): Post[] {
        console.log(`[SharePostsService][GetListPosts]`);
        if (type == "Job") {
            return this.jobs;
        }
        else {
            return this.workers;
        }
    }

    addListPosts(post: Post) {
        console.log(`[SharePostsService][AddListPosts]`);
        this.jobs.push(post);
    }

    getPostById(id: string): Post {
        return this.jobs.find(p => p.postId == id);
    }

}
