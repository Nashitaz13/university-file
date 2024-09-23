import { Utility } from './../utilities/utility';
import { Configuration } from './../configuration';
import { Unit } from './../models/unit.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UnitsService {
    public static Units: Unit[] = [];

    constructor(public http: Http) {
        console.log('---- Hello UnitsProvider Provider ----');
    }

    getUnit(id: number) {
        return UnitsService.Units.find(c => c.unitId == id).name;
    }

    load() {
        console.log("[ContractTypeService][Load][Entry function...]");

        return new Promise(resolve => {// don't have the data yet
            console.log("[ContractTypeService][Load][Loading data from server...]");
            this.http.get(`${Configuration.ApiURI}units`)
                .map(res => res.json())
                .catch(Utility.handleError)
                .subscribe(data => {
                    UnitsService.Units = data;
                    resolve(data);
                    console.log("[ContractTypeService][Load][Resolve data]");
                });
        })
    }

}
