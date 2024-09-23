import { UserDetailPage } from './../user_detail/userdetail';
import { AboutPage } from './../about/about';
import { ContactPage } from './../contact/contact';
import { BookmarksPage } from './../bookmarks/bookmarks';
import { MyPostPage } from './../my-post/my-post';
import { FilterByPage } from './../filter-by/filter-by';
import { UserPage } from './../user/user';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { LoginPage } from './../login/login';
import { PostMapPage } from './../post-map/post-map';
import { Component } from '@angular/core';
import { NavController, MenuController } from 'ionic-angular';
import { PostListPage } from '../post_list/postlist';
import { NotificationPage } from '../notification/notification';
import { Tab } from '../../models/tab.model';
import { OneSignal } from 'ionic-native';

@Component({
    selector: 'page-home',
    templateUrl: 'home.html',
})
export class HomePage {

    notification: any;
    tabLst: Tab[] = [];
    username: string;
    displayName: string;

    constructor(public navCtrl: NavController, public menuCtrl: MenuController) {
        this.tabLst.push(new Tab(PostListPage, "Việc tìm người", "ios-albums-outline", { isPostJob: true }));
        this.tabLst.push(new Tab(PostListPage, "Người tìm việc", "ios-people-outline", { isPostJob: false }));
        this.tabLst.push(new Tab(PostMapPage, "Việc gần bạn", "ios-navigate-outline"));
        this.notification = "ios-notifications"; //ios-notifications-off
    }

    ionViewDidLoad() {
        console.log('Hello Home Page');
        // Get username of current user
        var user = ApplicationUserProvider.User;
        this.displayName = `${user.displayName}`;
        this.username = `@${ApplicationUserProvider.UserName}`;
    }

    ionViewWillEnter() {

    }

    viewNotification() {
        this.navCtrl.push(NotificationPage);
        this.menuCtrl.close();
    }

    openUserPage() {
        this.navCtrl.push(UserPage);
        this.menuCtrl.close();
    }

    showBookmarkPost() {
        this.navCtrl.push(BookmarksPage);
        this.menuCtrl.close();
    }

    showMyPost() {
        this.navCtrl.push(MyPostPage);
        this.menuCtrl.close();
    }

    openSettingPage() {
        this.navCtrl.push(FilterByPage);
        this.menuCtrl.close();
    }

    sendNotification() {
    }

    openAboutPage() {
        this.navCtrl.push(AboutPage);
        this.menuCtrl.close();
    }

    logout() {
        ApplicationUserProvider.ClearApplicationUser();
        this.navCtrl.setRoot(LoginPage);
        OneSignal.deleteTag('user_id');
        this.menuCtrl.close();
    }

}
