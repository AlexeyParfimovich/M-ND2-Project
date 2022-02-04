import { Injectable } from "@angular/core";
import {
    Router, RouterStateSnapshot, ActivatedRouteSnapshot,
    CanActivate, CanActivateChild, NavigationStart, NavigationEnd, NavigationCancel
} from "@angular/router";
import { Observable } from "rxjs";

import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard
    implements CanActivate, CanActivateChild {

    constructor(
        private router: Router,
        private service: AuthService
    ) {
        this.router.events.subscribe((event) => {
            if (event instanceof NavigationStart) {
                console.log('Access request')
            }

            if (event instanceof NavigationEnd) {
                console.log('Access aproved')
            }

            if (event instanceof NavigationCancel) {
                console.log('Access denied')
                this.router.navigate(['']);
            }
        })
    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | boolean {

        return this.service.isLoggedIn;
        //return confirm('Are you shure, что хотите перейти?');
    }

    canActivateChild(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> | boolean {
        return this.canActivate(route, state)
    }
}