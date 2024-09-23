import { Post } from './../../models/post.model';
import { PostService } from './../../providers/post-service';
import { UserService } from './../../providers/user-service';
import { Location } from './../../models/location.model';
import { User } from './../../models/user.model';
import { Component, Input } from '@angular/core';
import { NavController, NavParams, LoadingController } from 'ionic-angular';
 

@Component({
    selector: 'page-viewuser',
    templateUrl: 'userdetail.html',
    providers: [PostService, UserService]
})
export class UserDetailPage {

    @Input() userId: string;
    user: User;
    location: Location;
    segment: string;
    isJobList: boolean = true;
    postList: Post[] = [];
    gender: string;

    constructor(public navCtrl: NavController,
        private userService: UserService,
        private postService: PostService,
        private navParams: NavParams,
        private loadingCtrl: LoadingController) {

        this.user = new User();

    }

    ionViewDidLoad() {
        console.log('---- Hello view user Page ----');

        let loading = this.loadingCtrl.create({
            spinner: 'crescent',
            content: 'Vui lòng đợi...'
        });
        loading.present();
        this.userId = this.navParams.get('userId');
        console.log(`[UserDetailPage] Get user id: ${this.userId}`);
        this.userService.getUserById(this.userId).then((user: User) => {
            this.user = user;
            this.gender = this.user.gender == true ? "Nam" : "Nữ";
            loading.dismissAll();
            this.segment = "post";
            this.updateUserData();
        }).catch((error) => {
            console.log(`[UserDetailPage] Has error in case loading data from server.`);
            alert(error);
            loading.dismissAll();
        })
    }

    updateUserData() {

        if (this.segment == "post") {
            this.loadMyPosts();
            this.isJobList = true;
        }
        else if (this.segment == "job") {
            this.loadApplyPost();
            this.isJobList = true;
        }
        else {
            this.isJobList = false;
        }

    }

    loadMyPosts() {
        if (this.postList.length == 0) {
            this.postService.getJobsByJobPoster(this.userId).then((data: any[]) => {
                this.postList = data;
                console.log(`[UserDetailPage][LoadMyPosts] Load my post successfully.`);
            }).catch((error) => {
                alert(error);
                console.log(`[UserDetailPage][LoadMyPosts] Has occurs error: ${error}.`);
            })
        }
    }

    loadApplyPost() {
        this.postList = [];
    }
}
