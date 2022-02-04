import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import {
    HttpErrorResponse, HttpEvent, HttpHandler,
    HttpInterceptor, HttpRequest, HttpResponse
} from "@angular/common/http";
import { Observable, tap } from "rxjs";

import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private readonly service: AuthService,
        private readonly router: Router
    ) { }

    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {

        const accessToken = this.service.getAccessToken();

        const authReq = req.clone({
            headers: req.headers.set('Authorization', `Bearer ${accessToken}`),
        })

        return next.handle(authReq).pipe(
            tap(
                (event) => {
                    if (event instanceof HttpResponse)
                        console.log('Server response')
                },
                (err) => {
                    if (err instanceof HttpErrorResponse) {
                        if (err.status == 401 || err.status === 403) {
                            console.log('Unauthorized');
                            this.router.navigate(['/unauthorized']);
                        }
                    }
                }
            )
        )
    }
}