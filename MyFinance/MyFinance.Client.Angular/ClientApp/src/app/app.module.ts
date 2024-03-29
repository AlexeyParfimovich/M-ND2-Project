﻿import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppHomeComponent } from './app-home.component';

import { SignInCallbackComponent } from './oidc/signin-callback.component';
import { SignOutCallbackComponent } from './oidc/signout-callback.component';

import { BudgetsComponent } from './components/budget/budgets.component';
import { BudgetListComponent } from './components/budget/budget-list.component';
import { BudgetFormComponent } from './components/budget/budget-form.component';
import { BudgetDetailComponent } from './components/budget/budget-detail.component';
import { BudgetCreateComponent } from './components/budget/budget-create.component';
import { BudgetEditComponent } from './components/budget/budget-edit.component';

import { BoldDirective } from './directives/bold.directive';

import { AuthGuard } from './oidc/auth.guard';
import { AuthInterceptor } from './oidc/auth.interceptor';
import { AuthService } from './oidc/auth.service';

import { BudgetService } from './services/budget.service';

// определение дочерних маршрутов
const itemRoutes: Routes = [
    { path: '', component: BudgetListComponent },
    { path: 'create', component: BudgetCreateComponent },
    { path: 'edit/:id', component: BudgetEditComponent },
    { path: 'detail/:id', component: BudgetDetailComponent }
];

// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: AppHomeComponent },
    {
        path: 'budgets', component: BudgetsComponent,
        canActivate: [AuthGuard], canActivateChild: [AuthGuard],
        children: itemRoutes
    },
    { path: 'signin-callback', component: SignInCallbackComponent },
    { path: 'signout-callback', component: SignOutCallbackComponent },
    { path: '**', redirectTo: '', }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations:
        [AppComponent, AppHomeComponent,
         BudgetsComponent, BudgetListComponent, BudgetDetailComponent,
         BudgetCreateComponent, BudgetEditComponent, BudgetFormComponent,
         BoldDirective],
    providers: [
        AuthGuard,
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        AuthService,
        BudgetService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }