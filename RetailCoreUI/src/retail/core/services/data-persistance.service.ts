import { Injectable } from '@angular/core';

@Injectable()
export class DataPersistanceService {
  constructor() { }

  private _access_token: string = '';
  private _userPermissionType: string = '';

  public get access_token(): string {
    return localStorage.getItem('access_token') ?? '';
  }

  public get userGuid(): string {
    return localStorage.getItem('userGuid') ?? '';
  }

  public get userId(): string {
    return localStorage.getItem('userId') ?? '';
  }
  public get userName(): string {
    return localStorage.getItem('userName') ?? '';
  }

  public set access_token(value: string) {
    localStorage.setItem('access_token', value);
  }

  public set userGuid(value: string) {
    localStorage.setItem('userGuid', value);
  }

  public set userId(value: string) {
    localStorage.setItem('userId', value);
  }
  public set userName(value: string) {
    localStorage.setItem('userName', value);
  }
  public set userPermission(value: string) {
    this._userPermissionType = value;
  }
  hasPermission(permisionType: string): boolean {
    return this._userPermissionType == permisionType;
  }
}
