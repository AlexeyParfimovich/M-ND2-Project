import { Injectable } from '@angular/core';
import { User, UserManager, UserManagerSettings, WebStorageStateStore } from 'oidc-client';

@Injectable()
export class AuthService {

    isUserDefined = false;
    private user: User | null;
    private manager: UserManager;

    constructor() {
        this.getUserManager();
    }

    getClaims() {
        return this.user?.profile;
    }

    getAuthHeaderValue(): string {
        return `${this.user.token_type} ${this.user.access_token}`;
    }

    isSignedIn(): boolean {
        return this.user != null && !this.user.expired;
    }

    startSignIn(): Promise<void> {
        return this.manager.signinRedirect();
    }

    completeSignIn(): Promise<void> {
        return this.manager.signinRedirectCallback().then(user => {
            this.user = user;
        });
    }

    startSignOut(): Promise<void> {
        this.getUserManager();
        return this.manager.signoutRedirect();
    }

    completeSignOut() {
        this.getUserManager();
        this.user = null;
        return this.manager.signoutRedirectCallback();
    }

    silentSignIn() {
        this.getUserManager();
        return this.manager.signinSilentCallback();
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
            redirect_uri: 'https://localhost:11001/signin-callback',

            //start logout process
            post_logout_redirect_uri: 'https://localhost:11001/signout-callback',

            //silent renew oidc doing it automaticly 
            silent_redirect_uri: 'https://localhost:11001/silent-callback.html',
            automaticSilentRenew: true,

            //filterProtocolClaims: true,
            //loadUserInfo: true,

            // store information about Authentication in localStorage
            userStore: new WebStorageStateStore({ store: window.localStorage })
        }
    }
}