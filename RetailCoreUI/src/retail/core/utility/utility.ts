import { ElementRef } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';

export class Utility {
  static innerJoin(arr1: any[], arr2: any[], key1: string, key2: string) {
    return arr1
      .filter((a1) => arr2.some((a2) => a1[key1] === a2[key2]))
      .map((a1) => ({
        ...a1,
        ...arr2.find((a2) => a1[key1] === a2[key2]),
      }));
  }
  static clearDropdown(
    formName: FormGroup,
    ctrlName: string,
    defaultVal: string
  ) {
    formName.get(ctrlName)?.setValue(defaultVal);
  }

  static focusOnInvalidFormControl(_frm: FormGroup<any>,elementref: ElementRef  ) {
    for (const key of Object.keys(_frm.controls)) {
      console.log('initial', key);
      if (_frm.controls[key].invalid) {
        const invalidControl = elementref.nativeElement.querySelector(
          '[formControlName="' + key + '"]'
        );
        invalidControl.focus();
        break;
      }
    }
  }
}
