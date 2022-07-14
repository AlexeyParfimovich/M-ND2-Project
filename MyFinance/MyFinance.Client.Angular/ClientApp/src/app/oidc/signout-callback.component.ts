import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { AuthUrlConstants } from './auth.constants';

@Component({
    selector: 'signout-callback',
    template: ''
})
export class SignOutCallbackComponent implements OnInit {

    constructor(
        private service: AuthService,
        private readonly router: Router
    ) { }

    ngOnInit() {
        this.service.completeSignOut().then(() => {
            this.router.navigate([AuthUrlConstants.LOGOUT_CALLBACK_REDIRECT_URI]);
        });
    }
}