import { WorkAnywhereProvider } from './../../providers/work-anywhere-provider';
import { ChatManagerPage } from './../chat-manager/chat-manager';
import { BookmarksService } from './../../providers/bookmarks-service';
import { UnitsService } from './../../providers/units-service';
import { CategoryService } from './../../providers/category-service';
import { NotificationPage } from './../notification/notification';
import { PostPage } from './../post/post';
import { Post } from './../../models/post.model';
import { PostDetailPage } from './../post_detail/postdetail';
import { Component } from '@angular/core';
import { NavController, LoadingController, MenuController, NavParams, ToastController } from 'ionic-angular';
import { PostService } from '../../providers/post-service';

@Component({
    selector: 'page-postlist',
    templateUrl: 'postlist.html',
    providers: [PostService]
})

export class PostListPage {

    originPost: any[] = [];
    originWorker: any[] = [];
    posts: any[] = [];
    workers: any[];
    searchString: string = "";
    isPostJob: boolean = true;
    currentType: string = "";
    category: string;
    title: string;
    msgCount: number;

    constructor(public navCtrl: NavController,
        private loadingCtrl: LoadingController,
        private postService: PostService,
        public menuCtrl: MenuController,
        public navParams: NavParams,
        private categoryService: CategoryService,
        private unitService: UnitsService,
        private bookmarksService: BookmarksService,
        private toastCtrl: ToastController) {


    }

    ionViewDidLoad() {
        console.log(`---- Hello post list page ----`);
        this.isPostJob = this.navParams.get('isPostJob');
        console.log(`[PostListPage][Constructor][${this.isPostJob}]`)
        this.load();
        this.msgCount = WorkAnywhereProvider.getInstance().newMessageCount;
    }

    load() {
        if (this.isPostJob == true) {
            this.currentType = "Job";
            this.title = "Việc tìm người";
            this.loadJob(false);
        }
        else {
            this.currentType = "Worker";
            this.title = "Người tìm việc";
            this.loadWorker(true);
        }
    }

    openMenu() {
        this.menuCtrl.open();
    }

    addPost() {
        this.navCtrl.push(PostPage, { isCreated: true });
    }

    search(searchEvent) {
        let term = searchEvent.target.value
        if (term != null) {
            // We will only perform the search if we have 3 or more characters
            if (term.trim() === '' || term.trim().length < 3) {
                // Load cached users
                 if (this.isPostJob == true) {
                    this.posts = this.originPost.slice();
                }
                else {
                    this.workers = this.originWorker.slice();
                }
            } else {
                if (this.isPostJob == true) {
                    this.posts = this.originPost.slice();
                    this.posts = this.posts.filter((p: Post) => p.title.toLowerCase().includes(term.toLowerCase()));
                }
                else {
                    this.workers = this.originWorker.slice();
                    this.workers = this.workers.filter((w: Post) => w.title.toLowerCase().includes(term.toLowerCase()));
                }
            }
        }
    }

    onCancel($event) {
        this.posts = this.originPost.slice();
    }

    viewNotification() {
        this.navCtrl.push(NotificationPage);
    }

    loadJob(isRefresh: boolean) {
        let loader = this.loadingCtrl.create({
            content: "Vui lòng chờ..."
        });
        loader.present();
        this.postService.load(isRefresh, "Job")
            .then((data: any[]) => {
                this.posts = data;
                this.originPost = this.posts.slice();
                loader.dismiss();
            })
            .catch(error => {
                loader.dismiss();
                console.log(`[PostListPage][DoRefresh][ERROR][${error}]`);
            });
    }

    loadWorker(isRefresh: boolean) {
        let loader = this.loadingCtrl.create({
            content: "Vui lòng chờ..."
        });
        loader.present();
        this.postService.load(isRefresh, "Worker")
            .then((data: any[]) => {
                this.workers = data;
                this.originWorker = this.workers.slice();
                loader.dismiss();
            })
            .catch(error => {
                loader.dismiss();
                console.log(`[PostListPage][DoRefresh][ERROR][${error}]`);
            });
    }

    openChatManagerPage() {
        this.navCtrl.push(ChatManagerPage);
    }

    doRefresh(refresher) {
        console.log(`[PostListPage][DoRefresh][Begin async operation]`, refresher);
        setTimeout(() => {
            if (this.currentType == "Job") {
                this.loadJob(true);
            }
            else {
                this.loadWorker(true);
            }
            refresher.complete();
            console.log(`[PostListPage][DoRefresh][Async operation has ended]`);
        }, 2000);
    }



    getImagePathOfCategory(categoryId: number) {
        return this.categoryService.getImagePath(categoryId);
    }

    bookmarks(post: Post) {
        console.log(`[PostListPage][Bookmarks] Saved post to local database.`);
        this.bookmarksService.add(post);
        this.showCustomToast(`Lưu tin đăng thành công.`);
    }

    showDetailPost(post: Post) {
        console.log(`[PostListPage][ShowDetailpost] Displayed detail post page.`);
        this.navCtrl.push(PostDetailPage, { post: post });

    }

    private showCustomToast(message: string) {
        let toast = this.toastCtrl.create({
            message: message,
            duration: 2000
        });
        toast.present();
    }
}

