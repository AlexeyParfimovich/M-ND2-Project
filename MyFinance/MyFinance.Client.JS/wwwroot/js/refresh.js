const manager = new Oidc.UserManager({
    //Use Local storage instead of Session storage (default)
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage })
})

// Updating configured storage with refreshed data (Session Storage on default)
manager.signinSilentCallback();