import { Router, RouterModule } from '@angular/router';
import { AuthenticationService } from '../../../../core/auth/authentication.service';
import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AuthenticationResponse } from '../../../../core/models/authentication-response.model';
import { LoggerService } from '../../../../core/services/logger.service';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { CaptchaService } from '../../services/captcha.service';
import { ICaptchaResponse } from '../../models/registration/captcha.model';
import { CommonModule } from '@angular/common';
import { isApiResponse } from '../../../../core/guards/type.guard';

@Component({
  selector: 'retail-login',
  standalone: true,
  imports: [UI_Modules, ReactiveFormsModule, RouterModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [CaptchaService],
})
export class LoginComponent implements OnInit {
  errormessage: string = '';
  captchaImage: string = '';
  captchaKey: string = '';
  isFormSubmitted: boolean = false;
  loginForm: FormGroup = new FormGroup({
    email: new FormControl(),
    password: new FormControl(),
    captcha: new FormControl(),
    rememberMe: new FormControl(),
  });
  autofocus: boolean = false;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private captchaService: CaptchaService,
    private elementref: ElementRef,
    private logger: LoggerService
  ) { }

  ngOnInit() {
    // this.handleExistingToken();
  }

  private handleExistingToken() {
    this.verifyExistingToken()
      .then((valid) => {
        if (valid) {
          this.router.navigateByUrl('/home');
        }
      })
      .catch((error) => {
        this.initializeLoginForm();
        this.generateCaptcha();
      });
  }

  private initializeLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
        updateOn: 'submit',
      }),

      password: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(40),
        ],
        updateOn: 'submit',
      }),
      captcha: new FormControl('', {
        validators: [Validators.required, Validators.maxLength(6)],
        updateOn: 'submit',
      }),
      rememberMe: new FormControl(),
    });
  }

  registration() {
    this.router.navigateByUrl('/auth/register');
  }

  login() {
    this.errormessage = '';
    const email: string = this.loginForm.get('email')?.value || '';
    const password: string = this.loginForm.get('password')?.value || '';
    const captchaValue: string = this.loginForm.get('captcha')?.value || '';
    const rememberMe = this.loginForm.get('rememberMe')?.value || false;
    this.isFormSubmitted = true;

    if (this.loginForm.valid) {
      this.authenticationService
        .validate(email, password, this.captchaKey, captchaValue, rememberMe)
        .subscribe(
          (x: AuthenticationResponse) => {
            if (x.isMFAEnabled && x.isAuthenticated)
              this.router.navigateByUrl('/auth/verify-otp', {
                state: {
                  userId: x.userId,
                  mfaOptionsDetail: x.mfaOptionsDetail,
                },
              });
            else if (x.isAuthenticated) this.router.navigateByUrl('/home');
          },
          (error) => {
            if (isApiResponse(error)) {
              this.errormessage = error.message;
            }
            this.logger.error('Login not successful', error);
          }
        );
      this.regenerateCaptcha();
    } else {
      this.focusOnInvalidFormControl();
    }
  }

  cancel() {
    this.router.navigateByUrl('/auth/login');
  }

  generateCaptcha() {
    this.captchaService.generateCaptcha().subscribe(
      (response: ICaptchaResponse) => {
        this.captchaImage = 'data:image/png;base64,' + response.captchaImage;
        this.captchaKey = response.captchaKey;
      },
      (error) => {
        this.logger.error('Error generating captcha image', error);
      }
    );
  }

  regenerateCaptcha() {
    this.loginForm.controls['captcha'].reset();
    this.captchaService.regenerateCaptcha().subscribe(
      (response: ICaptchaResponse) => {
        this.captchaImage = 'data:image/png;base64,' + response.captchaImage;
        this.captchaKey = response.captchaKey;
      },
      (error) => {
        this.logger.error('Error regenerating captcha image', error);
      }
    );
  }

  verifyExistingToken(): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this.authenticationService.verifyExistingToken().subscribe(
        (result: boolean) => {
          resolve(result);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  focusOnInvalidFormControl() {
    for (const key of Object.keys(this.loginForm.controls)) {
      if (this.loginForm.controls[key].invalid) {
        const invalidControl = this.elementref.nativeElement.querySelector(
          '[formControlName="' + key + '"]'
        );
        if (key === 'password') this.autofocus = true;
        invalidControl.focus();
        break;
      }
    }
  }
}
