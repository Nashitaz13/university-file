import { Unit } from './../../models/unit.model';
import { UnitsService } from './../../providers/units-service';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { SharePostService } from './../../providers/shared/share-post-service';
import { GoogleMapPagePage } from './../google-map-page/google-map-page';
import { ShareLocationService } from './../../providers/shared/share-location-service';
import { HomePage } from './../home/home';
import { Location } from './../../models/location.model';
import { UtilitiesService } from './../../providers/utilities-service';
import { JsonHelper } from './../../utilities/json-helper';
import { Post } from './../../models/post.model';
import { PostService } from './../../providers/post-service';
import { FormBuilder } from '@angular/forms';
import { ContractTypeService } from './../../providers/contract-type-service';
import { CategoryService } from './../../providers/category-service';
import { Component, Input } from '@angular/core';
import { NavController, Platform, LoadingController, ToastController, NavParams } from 'ionic-angular';
import { Category } from '../../models/category.model';
import { ContractType } from '../../models/contracttype.model';
import { Geolocation } from 'ionic-native';

@Component({
    selector: 'page-post',
    templateUrl: 'post.html',
    providers: [UtilitiesService, PostService]
})
export class PostPage {

    @Input() isCreated: boolean;
    @Input() originPost: any;

    categories: Category[];
    contracttypes: ContractType[];
    units: Unit[];
    createPostForm: any;
    location: Location;
    errors: any;
    post: Post;
    platform: any;
    targetPath: string = "img/default_post.png";
    isJob: boolean = true;

    constructor(public navCtrl: NavController,
        private formBuilder: FormBuilder,
        private postService: PostService,
        private utilitiesService: UtilitiesService,
        public loadingCtrl: LoadingController,
        private toastControl: ToastController,
        private sharedPostService: SharePostService,
        private shareLocationService: ShareLocationService,
        public params: NavParams,
        platform: Platform) {
        console.log("---- Hello post page ---- ");
        this.isCreated = this.params.get('isCreated');
        console.log(`[PostPage][Constructor] isCreated = ${this.isCreated}, isJob = ${this.isJob}`);


        this.categories = CategoryService.Categories;
        this.contracttypes = ContractTypeService.ContractTypes;
        this.units = UnitsService.Units;
        this.errors = "";

        if (this.isCreated == true) {
            // Is created
            this.post = new Post();
            this.post.authorId = ApplicationUserProvider.UserId;
            this.post.title = "";
            this.post.category = CategoryService.Categories.find(p => true).categoryId;
            this.post.contractType = ContractTypeService.ContractTypes.find(p => true).contractTypeId;
            this.post.dateExpired = new Date().toISOString();
            this.post.description = "";
            this.post.salary = 0;
            this.post.unit = UnitsService.Units.find(p => true).unitId;
            this.post.state = "Publish";

            this.location = new Location();

            // Get current location of user
            this.platform = platform;
            this.platform.ready().then(() => {
                console.log("[PostPage][Constructor][Platform ready...]");
            });
        }
        else {
            // Is updated
            console.log(`[PostPage][Constructor] Updated post.`);
            this.post = this.params.get('originPost');
            this.location = this.post.location;
        }

        console.log("[PostPage][Constructor][End function.]");
    }

    createNewPost() {
        console.log("[PostPage][CreateNewPost][Entry function...]");
        if (this.validated()) {
            this.post.location = this.location;
            let loading = this.loadingCtrl.create({
                spinner: 'crescent',
                content: 'Vui lòng đợi...'
            });
            loading.present();
            console.log(`[PostPage][CreateNewPost] ${JSON.stringify(this.post)}`);

            // Call api create post
            this.postService.created(this.post).then((data) => {
                if (data == true) {
                    loading.dismiss();
                    let toast = this.toastControl.create({
                        message: "Đăng tin thành công",
                        duration: 1500,
                        dismissOnPageChange: true
                    });
                    toast.present();
                    this.navCtrl.push(HomePage);
                }
                else {
                    loading.dismiss();
                    this.errors = "* Có lỗi xảy ra. Vui lòng thử lại.";
                }
            })
                .catch(error => {
                    loading.dismiss();
                    console.log("[PostPage][CreateNewPost][Error...]" + "[" + error + "]");
                })
            console.log(JsonHelper.PostToJSON(this.post));
        }
        console.log("[PostPage][CreateNewPost][End function.]");
    }

    openGoogleMapPage() {
        this.navCtrl.push(GoogleMapPagePage);
    }

    ionViewDidEnter() {

        console.log(`[PostPage][IonViewDidEnter]`);
        this.location = this.shareLocationService.getLocation(); // Get current Geolocation

    }

    updatedPost() {
        console.log("[PostPage][UpdatedPost][Entry function...]");
        if (this.validated()) {
            this.post.location = this.location;
            let loading = this.loadingCtrl.create({
                spinner: 'crescent',
                content: 'Vui lòng đợi...'
            });
            // Call api updated post
            this.postService.updated(this.post).then(() => {
                loading.dismiss();
                let toast = this.toastControl.create({
                    message: "Cập nhật thành công",
                    duration: 2000,
                    dismissOnPageChange: true,
                    cssClass: "toastInfoCss",
                });
                toast.present();
            })
        }

        console.log("[PostPage][UpdatedPost][End function.]");
    }

    deletedPost() {
        console.log("[PostPage][DeletedPost][Entry function...]");
        let loading = this.loadingCtrl.create({
            spinner: 'crescent',
            content: 'Vui lòng đợi...'
        });
        // Call api delete post
        this.postService.deleted(this.post.postId.toString()).then(() => {
            loading.dismiss();
            let toast = this.toastControl.create({
                message: "Xóa bài đăng thành công",
                duration: 2000,
                dismissOnPageChange: true,
                cssClass: "toastInfoCss",
            });
            toast.present();
        })

        console.log("[PostPage][DeletedPost][End function.]");
    }

    private validated() {

        console.log("[PostPage][Validated][Entry function...]");
        this.errors = "";
        // Validated required
        if (this.post.title == "" || this.post.description == "" || this.post.salary == null) {
            this.errors = "(*) bắt buộc";
            return false;
        }
        // Validated salary is invalid
        if (this.post.salary < 0) {
            this.errors = "* Lương phải là số dương.";
        }
        // Validated dated expried
        if (this.post.dateExpired != null && this.post.dateExpired != "") {
            var currentDate = new Date();
            var specificDate = new Date(this.post.dateExpired);
            if (specificDate.getTime() < new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()).getTime()) {
                this.errors = "* Ngày hết hạn phải lớn hơn ngày hiện tại.";
                return false;
            }
        }

        // Validated get location
        if (this.location.name == "") {
            this.errors = "* Không thể tìm được vị trí của bạn. Vui lòng kiểm tra kết nối internet.";
            return false;
        }
        console.log("[PostPage][Validated][End function.]");
        return true;

    }
}
