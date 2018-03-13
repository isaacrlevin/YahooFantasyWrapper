import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { LoadingService } from './loading.service';
import 'rxjs/add/operator/do';
@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private loadingService: LoadingService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loadingService.loaded = false
    return next.handle(req).do((event: HttpEvent<any>) => {
      this.loadingService.loaded = true;
    }, error => console.error(error));
  }
}
