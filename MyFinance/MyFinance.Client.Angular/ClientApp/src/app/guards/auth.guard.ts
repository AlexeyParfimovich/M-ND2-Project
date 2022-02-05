import { Injectable } from "@angular/core";
import {
    Router, RouterStateSnapshot, ActivatedRouteSnapshot,
    CanActivate, CanActivateChild, NavigationStart, NavigationEnd, NavigationCancel
} from "@angular/router";

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

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.service.isSignedIn()) {
            return true;
        }

        this.service.startSignIn();
        return false;
    }

    async canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.canActivate(route, state)
    }
}