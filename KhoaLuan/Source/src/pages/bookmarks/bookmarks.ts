import { PostDetailPage } from './../post_detail/postdetail';
import { BookmarksService } from './../../providers/bookmarks-service';
import { CategoryService } from './../../providers/category-service';
import { Component } from '@angular/core';
import { NavController, AlertController, LoadingController } from 'ionic-angular';

@Component({
    selector: 'page-bookmarks',
    templateUrl: 'bookmarks.html'
})
export class BookmarksPage {

    posts: any[];

    constructor(public navCtrl: NavController,
        private bookmarksService: BookmarksService,
        private alertCtrl: AlertController,
        private categoryService: CategoryService,
        private loadingCtrl: LoadingController) { }

    ionViewDidLoad() {
        console.log('Hello BookmarksPage Page');
        let loading = this.loadingCtrl.create({
            spinner: 'crescent',
            content: 'Vui lòng đợi...'
        });
        loading.present();
        this.bookmarksService.getAll().then((data: any[]) => {
            this.posts = data;
            loading.dismiss();
        });
    }
    getDescription(des: string) {
        return des.slice(0, 70) + '...';
    }
    view(post: any) {
        console.log(`[BookmarksPage][ViewDetailPost]`);
        this.navCtrl.push(PostDetailPage, { post: post });
    }

    getImagePath(categoryId: number) {
        console.log(`[BookmarksPage][GetImagePath]`);
        return this.categoryService.getImagePath(categoryId);
    }

    delete(post: any) {
        console.log(`[BookmarksPage][Delete]`);
        let confirm = this.alertCtrl.create({
            title: 'Xóa tin đăng',
            message: 'Bạn có muốn xóa tin này?',
            buttons: [
                {
                    text: 'Đồng ý',
                    handler: () => {
                        console.log(`[BookmarksPage][Delete] Deleted Post.`);
                        this.bookmarksService.delete(post);
                    }
                },
                {
                    text: 'Hủy',
                    handler: () => {
                        console.log('Disagree clicked');
                    }
                }
            ]
        });
        confirm.present();
    }
}
