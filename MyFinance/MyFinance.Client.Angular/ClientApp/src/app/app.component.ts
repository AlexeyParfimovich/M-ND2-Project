import { Component } from '@angular/core';

@Component({
    selector: 'app',
    template: 
        `<div class="container-fluid body-content">
            <h1>MyFinance</h1>
            <nav>
                <a routerLink="">Log in</a> |
                <a routerLink="/budgets">Budgets</a> |
                <a routerLink="/about">About</a>
            </nav>
            <router-outlet></router-outlet>
        </div>`,
})
export class AppComponent {}