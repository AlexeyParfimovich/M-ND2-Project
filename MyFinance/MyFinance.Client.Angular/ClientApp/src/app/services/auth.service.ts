import { Injectable } from '@angular/core';
//import { HttpClient } from '@angular/common/http';
import { User, UserManager, UserManagerSettings, WebStorageStateStore } from 'oidc-client';
//import { UserManagerSettings } from '../models/user-manager.settings';

@Injectable()
export class AuthService {

    private accessToken = "1234567890";

    isUserDefined = false;
    private user: User | null;
    private manager: UserManager;

    constructor() {
        this.getUserManager();
    }

    getAuthHeaderValue(): string {
        return `${this.user.token_type} ${this.user.access_token}`;
    }

    isLoggedIn(): boolean {
        return this.user != null && !this.user.expired;
    }

    startAuthentication(): Promise<void> {
        return this.manager.signinRedirect();
    }

    completeAuthentication(): Promise<void> {
        return this.manager.signinRedirectCallback().then(user => {
            this.user = user;
        });
    }

    private getUserManager() {
        if (!this.manager) {

            this.manager = new UserManager(this.getUserManagerSettings());

            this.manager.getUser()
                .then((user) => {
                    this.user = user;
                    this.isUserDefined = true;
                });
        }
    }

    private getUserManagerSettings(): UserManagerSettings {
        return {
            //website that responsible for Authentication
            authority: 'https://localhost:6001',

            //uniqe name to identify the project
            client_id: 'client_id_angular',

            //desired Authentication processing flow - for angular is sutible code flow
            response_type: 'code',

            //specify the access privileges, specifies the information returned about the authenticated user.
            scope: 'openid profile MyFinanceAPI',

            //start login process
            redirect_uri: 'https://localhost:11001/auth-callback',

            //start logout process
            post_logout_redirect_uri: 'https://localhost:11001/',

            //silent renew oidc doing it automaticly 
            //silent_redirect_uri: 'https://localhost:11001/silent-callback',
            //automaticSilentRenew: true,

            //filterProtocolClaims: true,
            //loadUserInfo: true,

            // store information about Authentication in localStorage
            userStore: new WebStorageStateStore({ store: window.localStorage })
        }
    }
}