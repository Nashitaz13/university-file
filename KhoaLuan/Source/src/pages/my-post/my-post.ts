import { Post } from './../../models/post.model';
import { PostPage } from './../post/post';
import { Component } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
import { PostService } from './../../providers/post-service';
import { PostDetailPage } from './../../pages/post_detail/postdetail';
import { ApplicationUserProvider } from './../../providers/application-user-provider';

@Component({
    selector: 'page-my-post',
    templateUrl: 'my-post.html',
    providers: [PostService]
})
export class MyPostPage {

    posts: any[];

    constructor(public navCtrl: NavController, private postService: PostService, public loadingCtrl: LoadingController) {

    }

    ionViewDidLoad() {
        console.log('Hello MyPostPage Page');
        let loading = this.loadingCtrl.create({
            spinner: 'crescent',
            content: 'Đang tải...'
        });
        loading.present();
        this.postService.getJobsByJobPoster(ApplicationUserProvider.UserId).then((data: any[]) => {
            this.posts = data;
            loading.dismiss();
        });
    }

    view(post: any) {
        console.log('[MyPostPage][view]');
        this.navCtrl.push(PostDetailPage, { post: post });
    }

    getExpriedClass(post: Post) {
        var currentDate = new Date();
        var expiredDate = new Date(post.dateExpired);
        if (expiredDate.getTime() < new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()).getTime()) {
            return "expired";
        }
        return "";
    }

    edit(post: any) {
        console.log(`[MyPostPage][Edit post]`);
        this.navCtrl.push(PostPage, { isCreated: false, originPost: post });
    }

    getDescription(des: string) {
        return des.slice(0, 70) + '...';
    }
}
