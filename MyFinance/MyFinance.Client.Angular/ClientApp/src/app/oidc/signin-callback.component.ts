import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { AuthUrlConstants } from './auth.constants';

@Component({
    selector: 'signin-callback',
    template: ''
})
export class SignInCallbackComponent implements OnInit {

    constructor(
        private service: AuthService,
        private readonly router: Router    ) { }

    ngOnInit() {
        this.service.completeSignIn().then(() => {
            this.router.navigate([AuthUrlConstants.LOGIN_CALLBACK_REDIRECT_URI]);
        });
    }
}