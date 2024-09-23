import { Config } from './../models/config.model';
import { Observable } from 'rxjs/Observable';

export class Utility {
    // Format salary=value(0)&contracttype=value(true:false:true)&category=value(1:2:3)
    static toConfigString(originConfig: Config) {
        var configString = `salary=${originConfig.luong}&radius=${originConfig.bankinh}`;

        // Hard code 100 in case selected = false
        var contracttypeString = `contractypes=${originConfig.isLamThem ? 0 : 100}-${originConfig.isBanThoiGian ? 1 : 100}-${originConfig.isToanThoiGian ? 2 : 100}`;

        var categoriesString = "";
        // Get selected list category
        originConfig.categories.forEach((category) => {
            if (category.isChecked) {
                if (categoriesString == "") {
                    categoriesString = `categories=${category.categoryId}`;
                }
                else {
                    categoriesString += `-${category.categoryId}`;
                }
            }
        });
        console.log(`[FilterByPage][BuildUserConfig] List selected category: ${categoriesString}`);
        if (categoriesString != "") {
            configString += `&${contracttypeString}&${categoriesString}`;
        }
        console.log(`[FilterByPage][BuildUserConfig] Config: ${configString}`);
        return configString;
    }

    /*
   * WebRTC date format
   * Takes a string date.
   * Usage:
   *   value | WebRTCDate:format
   * Example:
   *   {{ '2016-03-29T21:32:33.805Z' |  WebRTCDate:full }}
   *   formats to: 21:32:33 29-03-2016
   */
    static transformDateTime(value: string): string {
        let result: string = value;

        if (value) {
            let array: Array<string> = value.split('T');
            if (array.length > 0) {
                let date: string = array[0];
                let time: string = array[1];
                //
                var dateArray: Array<string> = date.split('-');
                result = `${dateArray[2]}/${dateArray[1]}/${dateArray[0]}` + ', ' + time.substr(0, 8);
            }
        }
        return result;
    }

    static handleError(error) {
        var errMsg = JSON.stringify(error);
        console.log(errMsg);
        alert(`Không thể kết nối tới máy chủ.`);
        return Observable.throw(null);
    }


}