import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'auth-callback',
    template: ''
})
export class AuthCallbackComponent implements OnInit {

    constructor(private service: AuthService) { }

    ngOnInit() {
        this.service.completeAuthentication();
    }
}