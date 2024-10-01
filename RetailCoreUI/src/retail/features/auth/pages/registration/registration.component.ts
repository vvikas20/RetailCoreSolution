import { Component, ElementRef } from '@angular/core';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';
import { Observable } from 'rxjs';
import { RegistrationService } from '../../services/registration.service';
import { angularModules } from '../../../../shared/modules/angular-modules.export';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { User } from '../../models/registration/user.model';
import { CommonModule } from '@angular/common';
import { CustomValidatorService } from '../../services/custom-validator.service';
import { AlertService } from '../../../../core/ui-services/alert.service';
import { LoggerService } from '../../../../core/services/logger.service';
import { Utility } from '../../../../core/utility/utility';


@Component({
  selector: 'retail-registration',
  standalone: true,
  imports: [UI_Modules, angularModules, CommonModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss',
  providers: [RegistrationService, CustomValidatorService],
})
export class RegistrationComponent {
  lstCountries: Array<any> = [];
  lstCities: Array<any> = [];
  lstState: Array<any> = [];
  lstExtension: Array<any> = [];
  lstBrand: Array<any> = [];
  lstVerticalMarket: Array<any> = [];
  lstProductinterestedin: Array<any> = [];
  lstRegion: Array<any> = [];
  isFormSubmitted: boolean = false;
  count$: Observable<number> | undefined;
  registrationComplete: boolean = false;

  registrationForm: FormGroup = new FormGroup({
    txtFirstName: new FormControl(''),
    txtMiddleName: new FormControl(''),
    txtLastName: new FormControl(''),
    txtUserName: new FormControl(''),
    txtAddress1: new FormControl(''),
    txtAddress2: new FormControl(''),
    selectedCountry: new FormControl(''),
    selectedState: new FormControl(''),
    selectedCity: new FormControl(''),
    txtZipCode: new FormControl(''),
    txtMobileNo: new FormControl(''),
    txtExt: new FormControl(),
    txtPhone: new FormControl(''),
    txtJobTitle: new FormControl(''),
    txtCompanyName: new FormControl(''),
    txtCompanyEmail: new FormControl(''),
    productIntrestedIn : new FormControl(''),
  });
  constructor(
    private registrationService: RegistrationService,
    private customValidatorService: CustomValidatorService,
    private formBuilder: FormBuilder,
    private alert: AlertService,
    private elementref: ElementRef,
    private logger: LoggerService
  ) {}

  ngOnInit() {
    this.initializeRegistrationForm();
    // this.fillGeoLocation();
    // this.fillProductIntrested();
  }

  private initializeRegistrationForm() {
    this.registrationForm = this.formBuilder.group({
      txtFirstName: [
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
            //this.customValidatorService.notOnlyWhitespace()
          ],
          updateOn: 'blur',
        },
      ],
      txtLastName: [
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
            //this.customValidatorService.notOnlyWhitespace()
          ],
          updateOn: 'blur',
        },
      ],
      txtUserName: [
        '',
        {
          validators: [
            Validators.required,
            Validators.minLength(8),
            Validators.maxLength(50),
            // Validators.pattern(/^([A-z])*[^\s]\1*$/),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
          ],
          asyncValidators: [
            this.customValidatorService.DuplicateUsernameValidator(),
          ],
          updateOn: 'blur',
        },
      ],
      txtCompanyEmail: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(50),
            Validators.pattern(
              /^([a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3})(,[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3})*$/
            ),
          ],
          asyncValidators: [
            this.customValidatorService.DuplicateEmailValidator(),
          ],
          updateOn: 'blur',
        },
      ],
      txtExt: [''],
      txtPhone: [
'',
        {
          validators: [
            Validators.required,
            Validators.minLength(5),
            Validators.maxLength(15),
            // Validators.pattern('^[0-9]*$'),
          ],
          updateOn: 'blur',
        },
      ],
      txtMobileNo: [
        '',
        {
          validators: [
            Validators.maxLength(15),
            Validators.pattern('^[0-9]*$'),
          ],
          updateOn: 'blur',
        },
      ],
      txtJobTitle: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(20),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
            //,this.customValidatorService.notOnlyWhitespace()
          ],
          updateOn: 'blur',
        },
      ],
      txtCompanyName: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(40),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
            //,this.customValidatorService.notOnlyWhitespace()
          ],
          updateOn: 'blur',
        },
      ],
      txtAddress1: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
          ],
          updateOn: 'blur',
        },
      ],
      txtAddress2: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(100),
            Validators.pattern('^[^\\s]+(\\s+[^\\s]+)*$'),
          ],
          updateOn: 'blur',
        },
      ],
      productIntrestedIn : ['',Validators.required],
      selectedCountry: ['', [Validators.required]],
      selectedState: ['', [Validators.required]],
      selectedCity: ['', [Validators.required]],
      txtZipCode: [
        '',
        {
          validators: [
            Validators.minLength(5),
            Validators.maxLength(6),
            Validators.pattern('^[0-9]*$'),
          ],
          updateOn: 'blur',
        },
      ],
      txtFax: [''],
    });
  }

  register() {
    this.isFormSubmitted = true;
    let user: User = new User();
    (user.firstName = this.registrationForm.get('txtFirstName')?.value),
      (user.lastName = this.registrationForm.get('txtLastName')?.value),
      (user.userName = this.registrationForm.get('txtUserName')?.value),
      (user.companyEmail = this.registrationForm.get('txtCompanyEmail')?.value),
      (user.ext =
        this.registrationForm.get('txtExt')?.value['extension'] || '+91'),
      (user.phone = this.registrationForm.get('txtPhone')?.value),
      (user.mobileNo = this.registrationForm.get('txtMobileNo')?.value) ||
        1111111111,
      (user.jobTitle = this.registrationForm.get('txtJobTitle')?.value),
      (user.companyName = this.registrationForm.get('txtCompanyName')?.value),
      (user.address1 = this.registrationForm.get('txtAddress1')?.value),
      (user.address2 = this.registrationForm.get('txtAddress2')?.value),
      (user.productIntrestedIn = this.registrationForm.get('productIntrestedIn')?.value),
      (user.country =
        this.registrationForm.get('selectedCountry')?.value['code']),
      (user.state = this.registrationForm.get('selectedState')?.value['code']),
      (user.city = this.registrationForm.get('selectedCity')?.value['code']),
      (user.zipCode = this.registrationForm.get('txtZipCode')?.value) || '';

    if (this.registrationForm.valid) {
      this.logger.log('user', user);
      this.registrationService
        .registerUser(user)
        .subscribe((userRegistered) => {
          if (userRegistered) {
            this.registrationComplete = true;
          }
        });
    } else {
      this.focusOnInvalidFormControl();
      this.alert.warn('Invalid Inputs', 'Unable to register user');
    }
  }
  cancel() {
    this.registrationForm.reset();
    this.registrationForm.markAsPristine();
    this.registrationForm.markAsUntouched();
    this.isFormSubmitted = false;
  }

  fillProductIntrested(){
    this.registrationService.getProductIntrested().subscribe((productsIntrested)=>{
      this.lstProductinterestedin = productsIntrested.map((productIntrested)=>{
        this.logger.log('product intrested in  is',productIntrested)
        return {
          name : productIntrested.productName,
          code : productIntrested.id
        }
      })
    })
  }

  fillGeoLocation() {
    this.registrationService.getGeoLocations().subscribe((geoLocations) => {
      this.lstCountries = geoLocations.map((Geolocation) => {
        return {
          name: Geolocation.countryName,
          code: Geolocation.id,
          StateList: Geolocation.stateList,
          extension: Geolocation.countryCode,
        };
      });
    });
  }

  fillState(selectedCountry: any) {
    Utility.clearDropdown(this.registrationForm, 'selectedState', '');
    Utility.clearDropdown(this.registrationForm, 'selectedCity', '');
    this.lstCities = [];
    this.lstState = this.lstCountries
      .filter((item) => {
        return item.code.includes(selectedCountry.code);
      })[0]
      .StateList.map((states: any) => {
        return {
          name: states.stateName,
          code: states.id,
          cityList: states.cityList,
        };
      });
  }
  fillCity(selectedState: any) {
    Utility.clearDropdown(this.registrationForm, 'selectedCity', '');
    this.lstCities = this.lstState
      .filter((item) => {
        return item.code.includes(selectedState.code);
      })[0]
      .cityList.map((cities: any) => {
        return {
          name: cities.cityName,
          code: cities.id,
        };
      });
  }

  focusOnInvalidFormControl() {
    for (const key of Object.keys(this.registrationForm.controls)) {
      console.log('initial', key);
      if (this.registrationForm.controls[key].invalid) {
        const invalidControl = this.elementref.nativeElement.querySelector(
          '[formControlName="' + key + '"]'
        );
        invalidControl.focus();
        break;
      }
    }
  }

  restrictKey(event : KeyboardEvent){
    const allowedKeys = ['Backspace', 'Tab', 'ArrowLeft', 'ArrowRight', 'Delete', 'End', 'Home'];
    if (!allowedKeys.includes(event.key) && !/^[0-9]$/.test(event.key)) {
      event.preventDefault();
    }
  }
}
