import {
  HttpEvent, HttpHandler,

  HttpInterceptor, HttpRequest, HttpResponse, HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { HttpLoaderService } from './http-loader.service';

@Injectable()
export class HttpRequestInterceptor implements HttpInterceptor {

  constructor(private httpLoaderService: HttpLoaderService) { }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.onStart();

    return next.handle(req).pipe(
      tap((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          this.onEnd();
        }
      }, (err: any) => {
        this.onEnd();
      }));
  }

  private onStart(): void {
    this.httpLoaderService.onRequestStart();
  }

  private onEnd(): void {
    this.httpLoaderService.onRequestEnd();
  }
}

export const httpRequestInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },
];
