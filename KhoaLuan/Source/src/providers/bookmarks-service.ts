import { Post } from './../models/post.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import * as PouchDB from 'pouchdb';

@Injectable()
export class BookmarksService {

    private pouchDB: any;
    private posts: any[] = [];

    constructor(public http: Http) {
        console.log('---- Hello BookmarksService Provider ---');
    }

    initDatabase() {
        this.pouchDB = new PouchDB('bookmarks', { adapter: 'websql' });
    }

    add(post: Post) {
        this.isExistPost(post).then((result: boolean) => {
            if (!result) {
                console.log(`[BookmarksService][Add] Add post to database.`);
                return this.pouchDB.post(post);
            }
            else {
                console.log(`[BookmarksService][Add] Post is existed in database.`);
            }
        });
    }

    delete(post: Post) {
        this.isExistPost(post).then((result: boolean) => {
            if (result) {
                console.log(`[BookmarksService][Delete] Deleted post in database.`);
                var index = this.posts.indexOf(post, 0);
                if (index > -1) {
                    this.posts.splice(index, 1);
                }
                return this.pouchDB.remove(post);
            }
            else {
                console.log(`[BookmarksService][Add] Post is not existed in database.`);

            }
        });
    }

    getAll() {
        console.log(`[BookmarksService][GetAll] Get all post in database.`);
        return new Promise(resolve => {
            if (this.posts.length == 0) {
                return this.pouchDB.allDocs({ include_docs: true })
                    .then(docs => {
                        this.posts = docs.rows.map(row => {
                            return row.doc;
                        });

                        // Listen for changes on the database.
                        this.pouchDB.changes({ live: true, since: 'now', include_docs: true })
                            .on('change', this.onDatabaseChange);

                        resolve(this.posts);
                    });
            } else {
                // Return cached data as a promise
                resolve(this.posts);
            }
        });
    }

    private isExistPost(post: Post) {
        console.log(`[BookmarksService][IsExistPost] Check post is existed in database.`);
        return new Promise(resolve => {
            this.getAll().then(() => {
                var index = this.posts.indexOf(post, 0);
                if (index > -1) {
                    resolve(true); // Is existed post
                }
                else {
                    resolve(false); // Isn't existed post
                }
            })
        });
    }

    private onDatabaseChange = (change) => {
        console.log(`[BookmarksService][OnDatabaseChange] Database has changed.`);       
    }
}
