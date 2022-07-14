import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import {
    HttpErrorResponse, HttpEvent, HttpHandler,
    HttpInterceptor, HttpRequest, HttpResponse
} from "@angular/common/http";
import { Observable, tap } from "rxjs";

import { AuthService } from './auth.service';
import { AuthUrlConstants } from "./auth.constants";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private readonly service: AuthService,
        private readonly router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const authReq = req.clone({
            headers: req.headers.set('Authorization', this.service.getAuthHeaderValue()),
        })

        return next.handle(authReq).pipe(
            tap(
                (event) => {
                    if (event instanceof HttpResponse)
                        console.log('Server response:', event.statusText)
                },
                (err) => {
                    if (err instanceof HttpErrorResponse) {
                        if (err.status == 401 || err.status === 403) {
                            console.log('Unauthorized');
                            this.router.navigate([AuthUrlConstants.LOGIN_CALLBACK_REDIRECT_URI]);
                        }
                    }
                }
            )
        )
    }
}