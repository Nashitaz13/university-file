import { CategoryService } from './category-service';
import { Config } from './../models/config.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import * as PouchDB from 'pouchdb';

@Injectable()
export class ConfigService {
    private pouchDB: any;
    private configs: Config[] = [];

    constructor(public http: Http) {
        console.log('Hello ConfigService Provider');
    }

    initDatabase() {
        this.pouchDB = new PouchDB('config', { adapter: 'websql' });
        var newConfig = new Config();
        newConfig.id = 1;
        newConfig.luong = 0;
        newConfig.isBanThoiGian = true;
        newConfig.isLamThem = true;
        newConfig.isToanThoiGian = true;
        newConfig.categories = [];
        CategoryService.Categories.forEach(category => {
            category.isChecked = true;
            newConfig.categories.push(category);
        });
        this.add(newConfig);
    }

    add(config: Config) {
        this.isExistConfig(config).then((isExist: boolean) => {
            if (isExist) {
                console.log(`[ConfigService][Add] Config is existed in database.`);
            }
            else {
                console.log(`[ConfigService][Add] Add config to database.`);
                return this.pouchDB.post(config);
            }
        })
    }

    update(config: Config) {
        if (this.isExistConfig(config)) {
            console.log(`[ConfigService][Updated] Updated config in database.`);
            this.pouchDB.put(config);
        }
        else {
            this.add(config);
        }
    }

    getConfig() {
        return new Promise(resolve => {
            this.pouchDB.allDocs({ include_docs: true })
                .then(docs => {
                    this.configs = docs.rows.map(row => {
                        return row.doc;
                    });
                    resolve(this.configs.find(p => true)); // Resolve config
                })
        });
    }

    isExistConfig(config: Config) {
        console.log(`[ConfigService][IsExistConfig] Check config is existed in database.`);
        return new Promise(resolve => {
            this.getConfig().then(() => {
                var result = this.configs.find(c => c.id == config.id);
                if (result != null) {
                    console.log(`[ConfigService][IsExistConfig] Is exist config in database.`);
                    resolve(true);
                }
                else {
                    console.log(`[ConfigService][IsExistConfig] Is NOT exist config in database.`);
                    resolve(false);
                }
            });
        })
    }
}
