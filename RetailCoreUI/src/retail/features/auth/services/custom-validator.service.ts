import { Injectable } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  ControlContainer,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
} from '@angular/forms';
import { Observable, map } from 'rxjs';
import { RegistrationService } from './registration.service';
import { LoggerService } from '../../../core/services/logger.service';

@Injectable()
export class CustomValidatorService {
  constructor(
    private registrationService: RegistrationService,
    private logger: LoggerService
  ) {}

  //Method will validate for existing email when new user registers
  public DuplicateEmailValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.registrationService.validateUserByEmail(control.value).pipe(
        map((isEmailExists) => {
          if (isEmailExists) {
            return { uniqueEmail: { valid: false } };
          } else return null;
        })
      );
    };
  }

  //Method will validate for existing username when new user registers
  public DuplicateUsernameValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.registrationService
        .validateUserByUsername(control.value)
        .pipe(
          map((isUsernameExists) => {
            if (isUsernameExists) {
              return { uniqueUsername: { valid: false } };
            } else return null;
          })
        );
    };
  }

  //Method will validate the password and confirm password field
  public passwordMatchValidator(group: FormGroup) {
    let password = group.get('password')?.value;
    let confirmPassword = group.get('confirmPassword')?.value;
    if (
      !password ||
      password.trim() === '' ||
      !confirmPassword ||
      confirmPassword.trim() === ''
    )
      return null;
    if (password === confirmPassword) {
      return null;
    } else {
      return { mismatch: true };
    }
  }


//function will check whether form input fields contains only whiteSpaces   
// public notOnlyWhitespace(): ValidatorFn {
//   return (control: AbstractControl): { [key: string]: boolean } | null => {
//     if (control.value == null) {
//       return null;  // Handle null values separately if needed
//     }

//     // Check if the value contains only whitespace characters
//     if ((control.value as string).trim().length === 0) {
//       return { 'notOnlyWhitespace': true };  // Validation failed
//     } else {
//       return null;  // Validation passed
//     }
//   };
// }
}



