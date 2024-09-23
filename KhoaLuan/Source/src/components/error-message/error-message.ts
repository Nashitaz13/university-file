import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from "ng2-translate";

/*
  Generated class for the ErrorMessage component.

  See https://angular.io/docs/ts/latest/api/core/index/ComponentMetadata-class.html
  for more info on Angular 2 Components.
*/
@Component({
  selector: 'control-messages',
  templateUrl: 'error-message.html'
})
export class ErrorMessageComponent {

  translate: TranslateService;
  
  constructor(translate: TranslateService) {
    this.translate = translate;
  }

  @Input() control: FormControl;
  get errorMessage() {
    for (let propertyName in this.control.errors) {
      if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
        let message: string;
        this.translate.get('ErrorCodes.' + propertyName).subscribe((res: string) => {
          message = res;
        });
        return message;
      }
    }
    return null;
  }

}
