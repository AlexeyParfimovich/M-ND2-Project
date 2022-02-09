import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../oidc/auth.service';
import { AuthUrlConstants } from '../../oidc/auth.constants';

@Component({
    selector: 'app-budgets',
    templateUrl: './budgets.component.html',
})
export class BudgetsComponent {

    constructor(
        private service: AuthService,
        private readonly router: Router
    ) { }

    signOut() {
        if (this.service.isSignedIn()) {
            this.service.startSignOut();
        }
        else {
            this.router.navigate([AuthUrlConstants.LOGOUT_CALLBACK_REDIRECT_URI]);
        }
    }
}