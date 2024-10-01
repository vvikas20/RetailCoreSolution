export interface VerifyotpResponse {
  access_token: string;
  isValidOtpValue: boolean[];
  userGuid: string;
}
  