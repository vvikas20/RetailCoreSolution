import { Injectable } from '@angular/core';

@Injectable()
export class LoggerService {

  constructor() { }

  log(message: string, ...optionalParams: any[]): void {
    if (optionalParams.length > 0)
      console.log(`%c[LOG]:%c ${message}`,
        'color: darkgray; font-size: 14px; background-color: lightgray; font-weight: bold;',
        'color: black;',
        optionalParams);
    else
      console.log(`%c[LOG]:%c ${message}`,
        'color: darkgray; font-size: 14px; background-color: lightgray; font-weight: bold;',
        'color: black;');
  }

  info(message: string, ...optionalParams: any[]): void {
    if (optionalParams.length > 0)
      console.log(`%c[INFO]:%c ${message}`,
        'color: darkblue; font-size: 14px; background-color: lightblue; font-weight: bold;',
        'color: blue;',
        optionalParams);
    else
      console.log(`%c[INFO]:%c ${message}`,
        'color: darkblue; font-size: 14px; background-color: lightblue; font-weight: bold;',
        'color: blue;');
  }

  warn(message: string, ...optionalParams: any[]): void {
    if (optionalParams.length > 0)
      console.log(`%c[WARN]:%c ${message}`,
        'color: #FF8C00; font-size: 14px; background-color: yellow; font-weight: bold;',
        'color: orange;',
        optionalParams);
    else
      console.log(`%c[WARN]:%c ${message}`,
        'color: #FF8C00; font-size: 14px; background-color: yellow; font-weight: bold;',
        'color: orange;');
  }

  error(message: string, ...optionalParams: any[]): void {
    if (optionalParams.length > 0)
      console.log(`%c[ERROR]:%c ${message}`,
        'color: darkred; font-size: 14px; background-color: pink; font-weight: bold;',
        'color: red;',
        optionalParams);
    else
      console.log(`%c[ERROR]:%c ${message}`,
        'color: darkred; font-size: 14px; background-color: pink; font-weight: bold;',
        'color: red;');
  }

  debug(message: string, ...optionalParams: any[]): void {
    if (optionalParams.length > 0)
      console.log(`%c[DEBUG]:%c ${message}`,
        'color: #4B0082; font-size: 14px; background-color: #E6E6FA; font-weight: bold;',
        'color: purple;',
        optionalParams);
    else
      console.log(`%c[DEBUG]:%c ${message}`,
        'color: #4B0082; font-size: 14px; background-color: #E6E6FA; font-weight: bold;',
        'color: purple;');
  }

}
