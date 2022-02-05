import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'auth-callback',
    template: ''
})
export class AuthCallbackComponent implements OnInit {

    constructor(
        private service: AuthService,
        private readonly router: Router    ) { }

    ngOnInit() {
        this.service.completeSignIn();

        this.router.navigate(
            //[this._authUrlConstantService.getAuthSuccessCallbackRedirectUrl()]
            ['/budgets']
        );
    }
}