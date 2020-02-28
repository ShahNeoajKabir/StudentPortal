import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  public isLoader = false;

  startLoader() {
    this.isLoader = true;
  }

  stopLoader() {
    this.isLoader = false;
  }
}
