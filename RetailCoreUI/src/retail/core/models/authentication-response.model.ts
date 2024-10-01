export interface AuthenticationResponse {
  access_token: string;
  username: string;
  isAuthenticated: string;
  isValidCaptcha: boolean;
  isMFAEnabled: boolean;
  mfaOptionsDetail: Map<string, string>;
  userId: string;
  userGuid: string;
}
