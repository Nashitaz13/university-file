import { Utility } from './../utilities/utility';
import { Configuration } from './../configuration';
import { ContractType } from './../models/contracttype.model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ContractTypeService {
    public static ContractTypes: ContractType[] = [];

    constructor(public http: Http) {
        console.log(`--- Hello contract type service ----`);
    }

    getContractType(id: number) {
        return ContractTypeService.ContractTypes.find(c => c.contractTypeId == id).name;
    }

    load() {
        console.log("[ContractTypeService][Load][Entry function...]");

        return new Promise(resolve => {// don't have the data yet
            console.log("[ContractTypeService][Load][Loading data from server...]");
            this.http.get(`${Configuration.ApiURI}contracttypes`)
                .map(res => res.json())
                .catch(Utility.handleError)
                .subscribe(data => {
                    ContractTypeService.ContractTypes = data;
                    resolve(data);
                    console.log("[ContractTypeService][Load] Resolve data successfully.");
                });
        })
    }
}
