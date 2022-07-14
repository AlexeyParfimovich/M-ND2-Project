const manager = new Oidc.UserManager({
    //Use local storage instead of session storage (default)
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),

    loadUserInfo: true,
    response_mode: "query"
});

manager.signinRedirectCallback()
    .then(function (user) {
        console.log(user);
        window.location.href = "https://localhost:10001";
    })
    .catch(function (error) {
        console.log(error);
    });
