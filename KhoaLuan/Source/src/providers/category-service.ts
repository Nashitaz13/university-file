import { Utility } from './../utilities/utility';
import { Configuration } from './../configuration';
import { Category } from './../models/category.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryService {
    public static Categories: Category[] = [];

    constructor(public http: Http) {
        console.log(`--- Hello category service ----`);
    }

    getCategoryName(id: number) {
        return CategoryService.Categories.find(c => c.categoryId == id).name;
    }

    getImagePath(id: number) {
        return CategoryService.Categories.find(c => c.categoryId == id).imagePath;
    }

    load() {
        console.log("[ContractTypeService][Load][Entry function...]");
        return new Promise(resolve => {// don't have the data yet
            console.log("[ContractTypeService][Load][Loading data from server...]");
            this.http.get(`${Configuration.ApiURI}categories`)
                .map(res => res.json())
                .catch(Utility.handleError)
                .subscribe(data => {
                    CategoryService.Categories = data;
                    resolve(data);
                    console.log("[ContractTypeService][Load] Resolve data successfully.");
                });
        })
    }


}
