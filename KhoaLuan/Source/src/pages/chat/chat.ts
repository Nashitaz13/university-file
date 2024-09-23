import { NotificationService } from './../../providers/notification-service';
import { Utility } from './../../utilities/utility';
import { UserDetailPage } from './../user_detail/userdetail';
import { ApplicationUserProvider } from './../../providers/application-user-provider';
import { Component, Input } from '@angular/core';
import { Platform, NavParams, NavController } from 'ionic-angular';

import { PubNubService, PubNubEvent, PubNubEventType } from '../../providers/pubnub-service';

@Component({
    templateUrl: 'chat.html',
    selector: 'page-chat',
    providers: [ PubNubService, NotificationService]
})
export class ChatPage {
    @Input() channel: string;
    @Input() authorId: string;


    originchannel: string;
    message: string;
    messages: Array<any>;
    originuserid: string;

    constructor(private platform: Platform, 
    private navCtrl: NavController, 
    private pubNubService: PubNubService, 
    private nav: NavParams,
    private notification: NotificationService) { 
        this.authorId = this.nav.get('authorId');
        console.log(`[ChatPage] Get author id: ${this.authorId}`);
    }

    ionViewDidLoad() {
        this.originuserid = ApplicationUserProvider.UserId;
        console.log(`[ChatPage][UserId][${this.originuserid}]`);
        this.originchannel = this.nav.get('channel');
        console.log(`[ChatPage][Channel][${this.originchannel}]`);
    }

    ionViewWillEnter() {
        this.platform.ready().then(() => {
            console.log(`[ChatPage][IonViewWillEnter]`);
            // Get history for channel
            this.pubNubService.history(this.originchannel).subscribe((event: PubNubEvent) => {
                let messages: Array<any> = [];
                for (let i = 0; i < event.value[0].length; i++) {
                    messages.push(this.createMessage(event.value[0][i].message));
                }
                this.messages = messages;
            }, (error) => {
                console.log(JSON.stringify(error));
            });
            // Subscribe to messages channel
            this.pubNubService.subscribe(this.originchannel).subscribe((event: PubNubEvent) => {
                if (event.type === PubNubEventType.MESSAGE) {
                    this.messages.push(this.createMessage(event.value));
                }
            }, (error) => {
                console.log(JSON.stringify(error));
            });
        });
    }

    createMessage(message: any): any {
        return {
            content: message.content,
            date: Utility.transformDateTime(message.date),
            sender_uuid: message.sender_uuid,
            ownclass: message.sender_uuid == this.originuserid ? "own" : ""
        };
    }

    sendMessage() {
        let messageContent = this.message;
        // Don't send an empty message 
        if (messageContent && messageContent !== '') {
            this.pubNubService.publish(this.originchannel, {
                content: messageContent,
                sender_uuid: this.originuserid,
                date: new Date()
            }).subscribe((event: PubNubEvent) => {
                console.log('Published', event.value);
                // Reset the messageContent input
                this.notification.sendChatNotification(this.originuserid,"Tin nhắn mới", messageContent, this.authorId, this.originchannel);
                this.message = "";
            }, (error) => {
                // Handle error here
                console.log('Publish error', JSON.stringify(error));
            }
                );
        }
    }

    detailUserPage(){
        console.log(`[ChatPage][DetailUserPage] Entry function...`);
        this.navCtrl.push(UserDetailPage, {
            userId: this.authorId
        });
    }
}