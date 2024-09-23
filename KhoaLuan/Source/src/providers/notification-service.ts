import { Configuration } from './../configuration';
import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class NotificationService {

    constructor(public http: Http) {
        console.log('Hello NotificationService Provider');
    }

    sendAllNotification(sensorid: string, title: string, message: string) {
        var headers = new Headers();
        headers.append("Content-Type", "application/json");
        headers.append("Authorization", "Basic ODkyMjdjZTctOWYzZC00MGMxLWE0Y2MtYzQzMDk0Njg5OTUx");
        var body = {
            "app_id": "7095d3d7-3a10-4b6f-a35d-4c94ee5ae880",
            "contents": { "en": message }
        };
        return new Promise(resolve => {
            this.http.post(`https://onesignal.com/api/v1/notifications`, JSON.stringify(body), { headers: headers })
                .map(response => response.json())
                .subscribe(data => {
                    // Insert to database
                    var notification = {
                        "type": "notification",
                        "sensorId": sensorid,
                        "message": {
                            "title": title,
                            "message": message
                        }
                    }
                    this.http.post(`${Configuration.ApiURI}notification`, JSON.stringify(notification), { headers: Configuration.getPostHeaderNonAuth() })
                        .map(response => response.json())
                        .subscribe(data => {
                            resolve(data);
                        }, error => {
                            console.log('Error!');
                            resolve(error);
                        });
                    resolve(data);
                }, error => {
                    console.log('Error!');
                    resolve(error);
                });
        })
    }

    sendChatNotification(sensorid: string, title: string, message: string, toUserId: string, channel: string) {
        var headers = new Headers();
        headers.append("Content-Type", "application/json");
        headers.append("Authorization", "Basic ODkyMjdjZTctOWYzZC00MGMxLWE0Y2MtYzQzMDk0Njg5OTUx");
        var body = {
            "app_id": "7095d3d7-3a10-4b6f-a35d-4c94ee5ae880",
            "filters": [
                { "field": "tag", "key": "user_id", "relation": "=", "value": toUserId }
            ],
            "data": {"type": "chat"},
            "contents": { "en": message }
        };
        return new Promise(resolve => {
            this.http.post(`https://onesignal.com/api/v1/notifications`, JSON.stringify(body), { headers: headers })
                .map(response => response.json())
                .subscribe(data => {
                    // Insert to database
                    var notification = {
                        "type":"chat",
                        "sensorId": sensorid,
                        "receiveId": toUserId,
                        "channel": channel,
                        "message": {
                            "title": title,
                            "message": message
                        }
                    }
                    this.http.post(`${Configuration.ApiURI}notification`, JSON.stringify(notification), { headers: Configuration.getPostHeaderNonAuth() })
                        .map(response => response.json())
                        .subscribe(data => {
                            resolve(data);
                        }, error => {
                            console.log('Error!');
                            resolve(error);
                        });
                    resolve(data);
                }, error => {
                    console.log('Error!');
                    resolve(error);
                });
        })
    }

}
