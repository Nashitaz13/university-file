import { Component } from '@angular/core';
import { NavController, MenuController } from 'ionic-angular';
import { Post } from '../../models/post.model';

@Component({
    selector: 'page-viewlistuser',
    templateUrl: 'userlist.html'
})
export class UserListPage {

    posts: any[];
    post: Post;

    constructor(public navCtrl: NavController, public menuCtrl: MenuController) {
        this.post = new Post();
        this.post.title = "Phan Y Biển";
        this.post.distance = '1000';
        this.post.description = "Cần việc làm thêm bán thời gian";
        this.post.category = 2;
        
     }

    ionViewDidLoad() {
        console.log('Hello Viewlistuser Page');
    }
}
