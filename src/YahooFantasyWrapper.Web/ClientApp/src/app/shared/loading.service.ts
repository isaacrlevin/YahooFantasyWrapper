import { Injectable } from '@angular/core';


@Injectable()
export class LoadingService {
  constructor() { }

  public loaded: boolean;

  isLoaded() {
    if (this.loaded === undefined) {
      this.loaded = true;
    }
    return this.loaded;
  }
}
