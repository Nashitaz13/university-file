import { GoogleMapDirectionPage } from './../google-map-direction/google-map-direction';
import { Utility } from './../../utilities/utility';
import { ChatService } from './../../providers/chat-service';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { ChatPage } from './../chat/chat';
import { UnitsService } from './../../providers/units-service';
import { ContractTypeService } from './../../providers/contract-type-service';
import { CategoryService } from './../../providers/category-service';
import { Component } from '@angular/core';
import { NavController, NavParams, AlertController, ToastController } from 'ionic-angular';
import { FormBuilder } from '@angular/forms';
import { Post } from '../../models/post.model';
import { SocialSharing } from 'ionic-native';

@Component({
    selector: 'page-viewpost',
    templateUrl: 'postdetail.html',
    providers: [ChatService]
})

export class PostDetailPage {

    post: Post;
    category: string;
    contracttype: string;
    locationname: string;
    dateExpired: string;
    unit: string;
    isOwner: boolean = false;
    createDate: string;

    constructor(public navCtrl: NavController,
        private fb: FormBuilder,
        public params: NavParams,
        private categoryService: CategoryService,
        private contracttypeService: ContractTypeService,
        private unitService: UnitsService,
        private chatService: ChatService,
        private alertCtrl: AlertController,
        private toastCtrl: ToastController) {

        this.post = new Post();
        this.post = this.params.get('post');
        console.log(`[PostDetailPage] Detail post: ${JSON.stringify(this.post)}`);
    }

    ionViewDidLoad() {
        if (this.post.authorId == ApplicationUserProvider.UserId) { // If post of user
            this.isOwner = true;
        }
        this.category = this.categoryService.getCategoryName(this.post.category);
        this.contracttype = this.contracttypeService.getContractType(this.post.contractType);
        this.unit = this.unitService.getUnit(this.post.unit);
        console.log(`[PostDetailPage][Constructor] Date Expried = ${this.post.dateExpired}`);
        this.createDate = Utility.transformDateTime(this.post.createdDate);
        this.dateExpired = Utility.transformDateTime(this.post.dateExpired);
        this.locationname = this.post.location.name;
    }

    openChatPage() {
        if (!this.isOwner) {
            var channel = "";
            var name = ApplicationUserProvider.User.displayName + '-' + this.post.title;
            this.chatService.getChanel(ApplicationUserProvider.UserId, this.post.postId, this.post.authorId, name, this.categoryService.getImagePath(this.post.category)).then((data: string) => {
                channel = data;
                console.log(`[PostDetailPage][OpenChatPage] Created chanel: ${channel}`);
                this.navCtrl.push(ChatPage, {
                    channel: channel,
                    authorId: this.post.authorId
                });
            })
        }
    }

    getImagePathOfCategory(categoryId: number) {
        return this.categoryService.getImagePath(categoryId);
    }

    openDirectionPage() {
        console.log(`[PostDetailPage][OpenDirectionPage] Open direction page.`);
        this.navCtrl.push(GoogleMapDirectionPage, {
            startLocation: ApplicationUserProvider.User.location,
            destinateLocation: this.post.location
        });
    }

    facebookShared() {
        // Check if sharing via facebook is supported
        SocialSharing.canShareVia("facebook").then(() => {
            // Sharing via facebook is possible
            var message = this.post.title + ` from @WorkAnywhere`;
            SocialSharing.shareViaFacebook(message, "img/logo.png").then(() => {
                this.showCustomToast("Chia sẻ tin đăng thành công.");
            }).catch((error) => {
                // Error!
                this.showAlert("Error", error);
            });
        }).catch(() => {
            // Sharing via facebook is not possible
            this.showAlert("Error", "Sharing via facebook is not possible")
        });

    }

    reportPost() {
        // Function not implements
        this.showAlert("Exception", 'Throw not implemented exception.');
    }

    private showAlert(title: string, subTitle: string) {
        let alert = this.alertCtrl.create({
            title: title,
            subTitle: subTitle,
            buttons: ['OK']
        });
        alert.present();
    }

    private showCustomToast(message: string) {
        let toast = this.toastCtrl.create({
            message: message,
            duration: 2000
        });
        toast.present();
    }

}
