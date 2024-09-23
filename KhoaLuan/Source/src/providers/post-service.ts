import { ApplicationUserProvider } from './application-user-provider';
import { Utility } from './../utilities/utility';
import { Config } from './../models/config.model';
import { ConfigService } from './config-service';
import { SharePostsService } from './shared/share-posts-service';
import { Configuration } from './../configuration';
import { JsonHelper } from './../utilities/json-helper';
import { Post } from './../models/post.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Storage } from '@ionic/storage';

@Injectable()
export class PostService {

    private filterString: string;
    private getURI: string = Configuration.ApiURI + "posts?limit=20";
    private postURI: string = Configuration.ApiURI + "posts";

    headers: any;
    isCreated: boolean = true;

    constructor(public http: Http, public storage: Storage, private sharePostsService: SharePostsService, private configService: ConfigService) {
        console.log('---- Hello PostService Provider ----');
    }

    load(isRefresh: boolean, type: string) {
        console.log("[PostService][Load][Entry function...]");
        if (this.sharePostsService.get(type).length > 0 && isRefresh == false) {
            console.log("[PostService][Load][Has local data]");
            return new Promise(resolve => {
                resolve(this.sharePostsService.get(type));
            });
        }
        else {
            return new Promise(resolve => {// don't have the data yet
                this.configService.getConfig().then((data: Config) => {
                    var c = new Config();
                    c = data;
                    this.filterString = Utility.toConfigString(c);
                    console.log("[PostService][Load][Loading data from server...]");
                    var URI = this.getURI + `&Latitude=${ApplicationUserProvider.User.location.latitude}&Longitude=${ApplicationUserProvider.User.location.longitude}&Name=${ApplicationUserProvider.User.location.name}` + `&type=${type}&${this.filterString}`;
                    console.log("[PostService][Load] URI: " + URI);
                    this.http.get(URI)
                        .map(res => res.json())
                        .subscribe((data: Post[]) => {
                            // Remove post expried
                            var result = data.filter(p => {
                                var expriedDate = new Date(p.dateExpired);
                                var currentDate = new Date();
                                if (expriedDate.getTime() > currentDate.getTime()) {
                                    return p;
                                }
                            });
                            this.sharePostsService.set(result, type);
                            resolve(result);
                            console.log("[PostService][Load] Resolve data.");
                        });
                });

            })
        }
    }

    created(post: Post) {

        console.log("[PostService][Created][Entry function...]");
        return new Promise(resolve => {
            this.http.post(this.postURI, JsonHelper.PostToJSON(post), { headers: Configuration.getPostHeaderNonAuth() })
                .map(response => response.json())
                .subscribe(response => {
                    console.log(`[PostService][Created][Resolve data...][${response}]`);
                    resolve(response);
                }, error => {
                    console.log("[PostService][Created][Error...]" + "[" + error + "]");
                    resolve(error);
                })
        })

    }

    updated(post: Post) {
        console.log("[PostService][Updated][Entry function...]");
        return new Promise(resolve => {
            this.http.put(`${this.postURI}/${post.postId}`, JsonHelper.PostToJSON(post), { headers: Configuration.getPostHeaderNonAuth() })
                .map(response => response.toString())
                .subscribe(response => {
                    console.log(`[PostService][Updated][Resolve data...][${response}]`);
                    resolve(response);
                }, error => {
                    console.log("[PostService][Updated][Error...]" + "[" + error + "]");
                    resolve(error);
                })
        })
    }

    deleted(id: string) {

        console.log("[PostService][Deleted][Entry function...]");
        return new Promise(resolve => {
            this.http.put(`${this.postURI}/${id}`, JSON.stringify(id), { headers: Configuration.getPostHeaderNonAuth() })
                .map(response => response.toString())
                .subscribe(response => {
                    console.log(`[PostService][Deleted][Resolve data...][${response}]`);
                    resolve(response);
                }, error => {
                    console.log("[PostService][Deleted] Error... [" + error + "]");
                    resolve(error);
                })
        })
    }

    getJobsByJobPoster(authorId: string) {
        console.log("[PostService][GetJobsByJobPoster][Entry function...]");
        return new Promise(resolve => {
            this.http.get(`${Configuration.ApiURI}postby/${authorId}` + `?Latitude=${ApplicationUserProvider.User.location.latitude}&Longitude=${ApplicationUserProvider.User.location.longitude}&Name=${ApplicationUserProvider.User.location.name}`)
                .map(response => response.json())
                .subscribe(response => {
                    console.log(`[PostService][GetJobsByJobPoster][Resolve data...][${response}]`);
                    resolve(response);
                }, error => {
                    console.log("[PostService][GetJobsByJobPoster][Error...]" + "[" + error + "]");
                    resolve(error);
                })
        })

    }
}
