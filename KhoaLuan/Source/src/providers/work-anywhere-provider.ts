import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class WorkAnywhereProvider {

    private static instance: WorkAnywhereProvider;

    public newMessageCount: number = 0; // count when has new message notification 

    constructor() {
        console.log('Hello WorkAnywhereProvider Provider');
    }

    static getInstance() {
        if (!WorkAnywhereProvider.instance) {
            WorkAnywhereProvider.instance = new WorkAnywhereProvider();
        }
        return WorkAnywhereProvider.instance;
    }

}
