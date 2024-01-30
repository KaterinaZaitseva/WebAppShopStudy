import { HttpInterceptor, HttpRequest, HttpHandler, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';

@Injectable()
export class AuthorizarionInterceptor implements HttpInterceptor {

    constructor(private tokenStorageService: TokenStorageService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        const token = this.tokenStorageService.getUserToken();

        if (!token) {
            return next.handle(request);
        }

        request = request.clone({
            headers: request.headers.set('Authorization', 'Bearer ' + token)
        });

        return next.handle(request);
    }
}