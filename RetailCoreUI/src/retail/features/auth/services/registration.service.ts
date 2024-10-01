import { Injectable } from '@angular/core';
import { HttpService } from '../../../core/http/http.service';
import { Observable, identity, map } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { ApiEndPoints } from '../../../config/api-end-points';
import { ICountry } from '../models/registration/country.model';
import { ApiResponse } from '../../../core/models/api-response.model';
import { LoggerService } from '../../../core/services/logger.service';
import { ICity } from '../models/registration/cities.model';
import { IState } from '../models/registration/state.model';
import { IVerticalMarket } from '../models/registration/verticalMarket.model';
import { IProductIntrested } from '../models/registration/productIntrested.model';
import { IRegion } from '../models/registration/region.model';
import { User } from '../models/registration/user.model';
import { IGeoLocation } from '../models/registration/geoLocation.model';

@Injectable()
export class RegistrationService {
  constructor(
    private http: HttpService,
    private loggerService: LoggerService
  ) {}

  getCounties(): Observable<Array<ICountry>> {
    return this.http
      .get<ApiResponse<Array<ICountry>>>(ApiEndPoints.get_country)
      .pipe(
        map((contries) => {
          return contries.result;
        })
      );
  }

  getCities(): Observable<Array<ICity>> {
    return this.http.get<ApiResponse<Array<ICity>>>(ApiEndPoints.get_city).pipe(
      map((cities) => {
        return cities.result;
      })
    );
  }

  getState(): Observable<Array<IState>> {
    return this.http
      .get<ApiResponse<Array<IState>>>(ApiEndPoints.get_state)
      .pipe(
        map((states) => {
          return states.result;
        })
      );
  }

  // getGeoLocations(): Observable<Array<IState>> {
  //   return this.http
  //     .get<ApiResponse<Array<IState>>>(ApiEndPoints.get_geoLocations)
  //     .pipe(map((geoLocations) => {
  //       return geoLocations
  //     }));
  // }

  getGeoLocations(): Observable<Array<IGeoLocation>> {
    return this.http
      .get<ApiResponse<Array<IGeoLocation>>>(ApiEndPoints.get_geoLocations)
      .pipe(
        map((geoLocation) => {
          //console.log(geoLocation.result)
          return geoLocation.result;
        })
      );
  }

  getProductIntrested(): Observable<Array<IProductIntrested>> {
    return this.http
      .get<ApiResponse<Array<IProductIntrested>>>(
        ApiEndPoints.getSchedule_AllCpqProducts
      )
      .pipe(
        map((productIntrested) => {
          return productIntrested.result;
        })
      );
  }

  getRegion(): Observable<Array<IRegion>> {
    return this.http
      .get<ApiResponse<Array<IRegion>>>(ApiEndPoints.get_region)
      .pipe(
        map((region) => {
          return region.result;
        })
      );
  }

  validateUserByEmail(email : string) {
    return this.http
    .get<ApiResponse<boolean>>(`${ApiEndPoints.validate_useremail}${email}`)
    .pipe(
      map((validateUserEmail) => {
        return validateUserEmail.result;
      })
    );
  }

  validateUserByUsername(username : string)
  {
    return this.http.get<ApiResponse<boolean>>(`${ApiEndPoints.validate_username}${username}`).pipe(map((validateUserName)=>{
      return validateUserName.result
    }));
  }

  registerUser(user: User): Observable<User> {
    this.loggerService.log('user object', user);
    const reqBody = {
      firstName: user.firstName,
      lastName: user.lastName,
      userId: user.userName,
      address1: user.address1,
      address2: user.address2,
      countryId: user.country,
      stateId: user.state,
      cityId: user.city,
      zipCode: user.zipCode,
      phoneNo: user.ext+user.phone,
      jobTitle: user.jobTitle,
      companyName: user.companyName,
      companyEmail: user.companyEmail,
      productIntrestedIn : user.productIntrestedIn,
      MobileNo : user.mobileNo
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.userRegistration, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
         
        })
      );
  }
}
