import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './oidc/auth.service';
import { AuthUrlConstants } from './oidc/auth.constants';

@Component({
    selector: 'app-home',
    template: 
        `<div class="container body-content">
            <h1>Home</h1>
            <nav>
                <a bold (click)="signIn()" class="nav-link">Sign in</a>
            </nav>
        </div>`
})
export class AppHomeComponent {

    constructor(
        private service: AuthService,
        private readonly router: Router
    ) { }

    signIn() {
        if (!this.service.isSignedIn()) {
            this.service.startSignIn();
        }
        else {
            this.router.navigate([AuthUrlConstants.LOGIN_CALLBACK_REDIRECT_URI]);
        }
    }
}