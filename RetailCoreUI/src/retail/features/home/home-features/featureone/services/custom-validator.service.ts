import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { map, Observable } from 'rxjs';
import { ProjectInfoService } from './project-info.service';

@Injectable()
export class CustomValidatorService {
  constructor(private projectInfoSService : ProjectInfoService) {}

  //Method will validate for existing email when new user registers
  public DuplicateProjectNameValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.projectInfoSService.validateDuplicateProject(control.value).pipe(
        map((projectExists) => {
          if (projectExists ) {
            return { uniqueProject: { valid: false } };
          } else return null;
        })
      );
    };
  }
}
