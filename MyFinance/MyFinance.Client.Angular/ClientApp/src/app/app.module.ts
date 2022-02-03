import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
//import { AppAboutComponent } from './app-about.component';
import { AppNotFoundComponent } from './app-notfound.component';

import { BudgetListComponent } from './components/budget/budget-list.component';
import { BudgetFormComponent } from './components/budget/budget-form.component';
import { BudgetDetailComponent } from './components/budget/budget-detail.component';
import { BudgetCreateComponent } from './components/budget/budget-create.component';
import { BudgetEditComponent } from './components/budget/budget-edit.component';

import { BudgetService } from './services/budget.service';

// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: BudgetListComponent },
    { path: 'create', component: BudgetCreateComponent },
    { path: 'edit/:id', component: BudgetEditComponent },
    { path: 'detail/:id', component: BudgetDetailComponent },
    { path: '**', component: AppNotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, AppNotFoundComponent,
        BudgetListComponent, BudgetCreateComponent, BudgetEditComponent,
        BudgetFormComponent, BudgetDetailComponent],
    providers: [BudgetService], // регистрация сервисов
    bootstrap: [AppComponent]
})
export class AppModule { }