import { WorkAnywhereProvider } from './../../providers/work-anywhere-provider';
import { ChatPage } from './../chat/chat';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { ChatService } from './../../providers/chat-service';
import { Utility } from './../../utilities/utility';
import { Chat } from './../../models/chat';
import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
    selector: 'page-chat-manager',
    templateUrl: 'chat-manager.html',
    providers: [ChatService]
})
export class ChatManagerPage {

    chats: Chat[] = [];
    constructor(public navCtrl: NavController,
        private chatService: ChatService) { }

    ionViewDidLoad() {
        console.log('Hello ChatManagerPage Page');
        this.chatService.getAllChat(ApplicationUserProvider.UserId)
            .then((data: Chat[]) => {
                this.chats = data;
                WorkAnywhereProvider.getInstance().newMessageCount = 0; // Set new message count to default
            })
            .catch((err) => {
                console.log(`[ChatManagePage] ERROR: ${JSON.stringify(err)}`);
            })
    }

    itemSelected(item: Chat) {
        var array = item.chanel.split('@');
        if (array.length > 0) {
            if (ApplicationUserProvider.UserId == item.sensorId) {
                // Nguoi dung la nguoi nhan tin
                this.navCtrl.push(ChatPage, {
                    channel: item.chanel,
                    authorId: item.receiveId
                });
            }
            else{
                this.navCtrl.push(ChatPage, {
                    channel: item.chanel,
                    authorId: item.sensorId
                });
            }

        }
    }
}
