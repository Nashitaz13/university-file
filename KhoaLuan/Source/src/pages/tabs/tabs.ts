import { Component, Input } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { Tab } from '../../models/tab.model';

@Component({
  selector: 'page-tabs',
  templateUrl: 'tabs.html'
})
export class TabsPage {
  @Input() arrayTab: Tab[] = [];

  constructor(public navCtrl: NavController,public params:NavParams) {  
    this.arrayTab = this.params.get('tabLst');
  }

  ionViewDidLoad() {
    console.log('Hello Tabs Page');
  }

}
