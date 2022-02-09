import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: 
        `<div class="container-fluid body-content">
            <h1>MyFinance</h1>
            <router-outlet></router-outlet>
        </div>`,
})
export class AppComponent {}