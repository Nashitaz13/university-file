import { Storage } from '@ionic/storage';
import { ValidatorsExtension } from './../utilities/validators-extension';
import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { TranslateModule, TranslateLoader, TranslateStaticLoader, TranslateService } from 'ng2-translate/ng2-translate';
import { Http } from "@angular/http";
// Import components
import { ErrorMessageComponent } from '../components/error-message/error-message';
// Import pages
import { MyApp } from './app.component';
import { AboutPage } from '../pages/about/about';
import { ContactPage } from '../pages/contact/contact';
import { HomePage } from '../pages/home/home';
import { TabsPage } from '../pages/tabs/tabs';
import { LoginPage } from './../pages/login/login';
import { PostPage } from './../pages/post/post';
import { UserListPage } from './../pages/user_list/userlist';
import { UserDetailPage } from './../pages/user_detail/userdetail';
import { UserPage } from './../pages/user/user';
import { SignUpPage } from './../pages/signup/signup';
import { NotificationPage } from './../pages/notification/notification';
import { PostDetailPage } from './../pages/post_detail/postdetail';
import { ForgotPasswordPage } from './../pages/forgotpassword/forgotpassword';
import { PostListPage } from './../pages/post_list/postlist';
import { GoogleMapPagePage } from './../pages/google-map-page/google-map-page';
import { PostMapPage } from './../pages/post-map/post-map';
import { ChatManagerPage } from './../pages/chat-manager/chat-manager';
import { GoogleMapDirectionPage } from './../pages/google-map-direction/google-map-direction';
import { BookmarksPage } from './../pages/bookmarks/bookmarks';
import { MyPostPage } from './../pages/my-post/my-post';
import { ChatPage } from './../pages/chat/chat';
import { FilterByPage } from './../pages/filter-by/filter-by';
import { GoogleMapDirectionListPage } from './../pages/google-map-direction-list/google-map-direction-list';

// Import providers
import { ApplicationUserProvider } from './../providers/application-user-provider';
import { SharePostService } from './../providers/shared/share-post-service';
import { ShareLocationService } from './../providers/shared/share-location-service';
import { CategoryService } from './../providers/category-service';
import { ContractTypeService } from './../providers/contract-type-service';
import { SharePostsService } from './../providers/shared/share-posts-service';
import { CloudSettings, CloudModule } from '@ionic/cloud-angular';
import { ConfigService } from './../providers/config-service';
import { BookmarksService } from './../providers/bookmarks-service';
import { UnitsService } from './../providers/units-service';
import { WorkAnywhereProvider } from './../providers/work-anywhere-provider';

export function createTranslateLoader(http: Http) {
  return new TranslateStaticLoader(http, '../assets/languages', '.json');
}

const cloudSettings: CloudSettings = {
  'core': {
    'app_id': '8c0f7cd6'
  },
  'push': {
    'sender_id': '250847158986',
    'pluginConfig': {
      'ios': {
        'badge': true,
        'sound': true
      },
      'android': {
        'iconColor': '#343434'
      }
    }
  }
};

@NgModule({
  declarations: [
    MyApp,
    ErrorMessageComponent,
    GoogleMapPagePage,
    GoogleMapDirectionPage,
    ChatPage,
    PostMapPage,
    LoginPage,
    AboutPage,
    MyPostPage,
    BookmarksPage,
    ContactPage,
    HomePage,
    TabsPage,
    PostListPage,
    ForgotPasswordPage,
    PostDetailPage,
    PostListPage,
    NotificationPage,
    SignUpPage,
    UserPage,
    UserDetailPage,
    ChatManagerPage,
    UserListPage,
    PostPage,
    FilterByPage,
    GoogleMapDirectionListPage
  ],
  imports: [
    IonicModule.forRoot(MyApp, {
      pageTransition: 'ios',
      iconMode: 'ios',
      tabsHideOnSubPages: true
    }),
    CloudModule.forRoot(cloudSettings),
    TranslateModule.forRoot({
      provide: TranslateLoader,
      useFactory: (createTranslateLoader),
      deps: [Http]
    })
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    ErrorMessageComponent,
    GoogleMapPagePage,
    GoogleMapDirectionPage,
    ChatPage,
    PostMapPage,
    MyPostPage,
    BookmarksPage,
    AboutPage,
    ContactPage,
    HomePage,
    TabsPage,
    LoginPage,
    PostListPage,
    ForgotPasswordPage,
    PostDetailPage,
    PostListPage,
    NotificationPage,
    SignUpPage,
    UserPage,
    UserDetailPage,
    ChatManagerPage,
    UserListPage,
    PostPage,
    FilterByPage,
    GoogleMapDirectionListPage
  ],
  providers: [{ provide: ErrorHandler, useClass: IonicErrorHandler }, BookmarksService, ConfigService, Storage, CategoryService, UnitsService, ContractTypeService, ShareLocationService, SharePostService, SharePostsService, ApplicationUserProvider, TranslateService, ValidatorsExtension, WorkAnywhereProvider]
})

export class AppModule { }

