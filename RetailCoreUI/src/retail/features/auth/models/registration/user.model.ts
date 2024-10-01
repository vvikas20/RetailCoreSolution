export class User {
  userId: string = '';
  firstName: string = '';
  lastName: string = '';
  userName: string = '';
  userID : string =''
  address1: string = '';
  address2: string = '';
  productIntrestedIn : string ='';
  country: string = '';
  state: string = '';
  city: string = '';
  zipCode: string = '';
  mobileNo: string = '';
  ext: string = '';
  phone: string = '';
  jobTitle: string = '';
  companyName: string = '';
  companyEmail: string = '';
  isSelected: boolean = false;
  id: string = '';
  userTypeId: string = '';
}
export interface IUser {
  id: string ;
  userId: string;
  firstName: string;
  lastName: string;
  customerDetailId: string ;
  customerCompanyName: string ;
  address1: string ;
  address2: string ;
  countryID: string ;
  countryName: string ;
  stateID: string ;
  stateName: string ;
  cityID: string;
  cityName: string ;
  companyEmail: string ;
  zipCode: string ;
  mobileNo: string ;
  phoneNo: string ;
  jobTitle: string ;
  isActive: boolean ;
  created: string ;
  isCompanyExists: boolean ;
  brandId: string ;
  brandName: string ;
  domainName: string ;
  productIntrestedIn : string;
}
