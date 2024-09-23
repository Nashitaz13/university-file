import { Utility } from './../utilities/utility';
import { Configuration } from './../configuration';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ChatService {

    private getURI: string = Configuration.ApiURI + "chat";

    constructor(public http: Http) {
        console.log('Hello ChatService Provider');
    }

    getAllChat(userId: string) {
        return new Promise(resolve => {

            console.log("[ChatService][getAllChat] Loading data from server...");
            this.http.get(this.getURI + `/${userId}`, { headers: Configuration.getPostHeaderNonAuth() })
                .map(res => res.json())
                .catch(Utility.handleError)
                .subscribe((data: string) => {
                    resolve(data);
                    console.log(`[ChatService][GetAllChat] Resolve data = ${data}`);
                });
        })
    }

    getChanel(userId: string, postId: string, receiveId: string, name: string, imagePath: string) {
        return new Promise(resolve => {
            console.log("[ChatService][getChanel] Loading data from server...");
            var currentTime = new Date().toLocaleString('en-GB');
            this.http.get(this.getURI + `?userId=${userId}&postId=${postId}&receiveId=${receiveId}&name=${name}&time=${currentTime}&imagePath=${imagePath}`)
                .map(res => res.text())
                .catch(Utility.handleError)
                .subscribe((data: string) => {
                    resolve(data);
                    console.log(`[ChatService][GetChanel] Resolve data = ${data}`);
                });
        })
    }

}
