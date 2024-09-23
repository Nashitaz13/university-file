import { Config } from './../../models/config.model';
import { ConfigService } from './../../providers/config-service';
import { Category } from './../../models/category.model';
import { Component } from '@angular/core';
import { NavController, ToastController } from 'ionic-angular';

@Component({
    selector: 'page-filter-by',
    templateUrl: 'filter-by.html'
})
export class FilterByPage {

    config: Config;

    constructor(public navCtrl: NavController,
        private configService: ConfigService,
        private toastCtrl: ToastController) {
        this.config = new Config();
    }

    ionViewDidLoad() {
        console.log('Hello FilterByPage Page');
        this.loadConfig();
    }

    checkedChange(category: Category) {
        this.config.categories.find(c => c.categoryId == category.categoryId).isChecked = !category.isChecked;
    }

    getOpacity(isChecked: boolean) {
        return isChecked == true ? 1 : 0.5;
    }

    loadConfig() {
        this.configService.getConfig().then((data: Config) => {
            console.log(`[FilterByPage][LoadConfig] Load config from database...`);
            this.config = data;
        });
    }

    saveConfig() {
        console.log(`[FilterByPage][SaveConfig] Save config to database.`);
        let toast = this.toastCtrl.create({
            message: "Cập nhật thông tin thành công.",
            duration: 2000,
            position: 'middle'
        });
        this.configService.update(this.config);
        toast.present();
    }

}
