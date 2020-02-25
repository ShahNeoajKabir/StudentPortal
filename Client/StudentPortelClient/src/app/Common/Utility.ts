import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class Utility {

    enumToArray(enums: any): Object[] {
        const StringIsNumber = value => isNaN(Number(value)) === false;
        return Object.keys(enums).filter(StringIsNumber)
          .map(key => ({ key: key, value: enums[key] }));
      }
}
