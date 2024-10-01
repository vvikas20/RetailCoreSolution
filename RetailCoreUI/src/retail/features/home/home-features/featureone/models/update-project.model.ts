export class updateProject {
    ID : string= ''
    projectName: string = '';
    verticalMarketId: string = '';
    projectPhaseId: string = '';
    description: string = '';
    ExpectedBidDueDate: string | null = null;
    probability: number = 0;
    purchasingContractor: string = '';
    designEngineer: string = '';
    accountManagerWithContractor: string = '';
    accountManagerWithEngineer: string = '';
    customerAccountManager: string = '';
    customerManager: string = '';
    projectStatus: number = 1;
    createdBy: string = '';
  }

  export class UpdateProjectCustomerParameter {
    ID : string ='';
    customerCompanyDetailID: string = '';
    customerLocationName: string = '';
    customerAddress1: string = '';
    customerAddress2: string = '';
    countryID: string = '';
    stateId: string = '';
    cityId: string = '';
    zipCode: string = '';
  }

  export class ProjectDocumentParameter {
    fileName: string = ''
    documentDescription : | null = null;
  }
  export class ProjectUserParameter {
    UserId: string = '';
    permissionLevelID: string = '';
  }
  