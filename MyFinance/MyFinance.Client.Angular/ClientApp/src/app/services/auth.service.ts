import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User, UserManager, WebStorageStateStore } from 'oidc-client';
import { UserManagerSettings } from '../models/user-manager.settings';

@Injectable()
export class AuthService {

    private accessToken = "1234567890";
    public isLoggedIn = true;

    isUserDefined = false;
    private user: User | null;
    private userManager: UserManager;

    constructor(private http: HttpClient) {
    }

    getAccessToken() {
        return this.accessToken;
    }

    private getUserManager() {
        if (!this.userManager) {
            const userManagerSettings: UserManagerSettings =
                new UserManagerSettings();

            //set up settings
            userManagerSettings.authority = 'https://localhost:6001'; //website that responsible for Authentication
            userManagerSettings.client_id = 'client_id_angular'; //uniqe name to identify the project
            userManagerSettings.response_type = 'code'; //desired Authentication processing flow - for angular is sutible code flow

            //specify the access privileges, specifies the information returned about the authenticated user.
            userManagerSettings.scope = 'openid profile MyFinanceAPI';

            //start login process
            userManagerSettings.redirect_uri = 'http://localhost:11001/login-callback';

            //start logout process
            userManagerSettings.post_logout_redirect_uri = 'http://localhost:11001/logout-callback';

            //silent renew oidc doing it automaticly 
            userManagerSettings.automaticSilentRenew = true;
            userManagerSettings.silent_redirect_uri = 'http://localhost:11001/silent-callback'; 

            // store information about Authentication in localStorage
            userManagerSettings.userStore = new WebStorageStateStore({
                store: window.localStorage,
            });

            this.userManager = new UserManager(userManagerSettings);

            this.userManager.getUser().then((user) => {
                this.user = user;
                this.isUserDefined = true;
            });
        }
    }
}