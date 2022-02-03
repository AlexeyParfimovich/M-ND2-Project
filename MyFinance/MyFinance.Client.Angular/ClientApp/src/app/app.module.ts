import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BudgetListComponent } from './budget/budget-list.component';
import { BudgetFormComponent } from './budget/budget-form.component';
import { BudgetCreateComponent } from './budget/budget-create.component';
import { BudgetEditComponent } from './budget/budget-edit.component';
import { NotFoundComponent } from './app-notfound.component';

import { BudgetService } from './services/budget.service';

// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: BudgetListComponent },
    { path: 'create', component: BudgetCreateComponent },
    { path: 'edit/:id', component: BudgetEditComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, BudgetListComponent, BudgetCreateComponent, BudgetEditComponent,
        BudgetFormComponent, NotFoundComponent],
    providers: [BudgetService], // регистрация сервисов
    bootstrap: [AppComponent]
})
export class AppModule { }