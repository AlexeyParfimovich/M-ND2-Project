import { Component, OnInit } from '@angular/core';
import { BudgetService } from './services/budget.service';
import { Budget } from './models/budget';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [BudgetService]
})
export class AppComponent implements OnInit {

    budget: Budget = new Budget();   // изменяемый товар
    budgets: Budget[];               // массив товаров
    tableMode: boolean = true;        // табличный режим

    constructor(private budgetService: BudgetService) { }

    ngOnInit() {
        this.loadBudgets();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadBudgets() {
        this.budgetService.getBudgets()
            .subscribe((data: Budget[]) => this.budgets = data);
    }

    // сохранение данных
    save() {
        if (this.budget.id == null) {
            this.budgetService.createBudget(this.budget)
                .subscribe((data: Budget) => this.budgets.push(data));
        } else {
            this.budgetService.updateBudget(this.budget)
                .subscribe(data => this.loadBudgets());
        }
        this.cancel();
    }

    change(b: Budget) {
        this.budget = b;
    }

    cancel() {
        this.budget = new Budget();
        this.tableMode = true;
    }

    delete(b: Budget) {
        console.log("delete budget "+ b.id);
        this.budgetService.deleteBudget(b.id)
            .subscribe(data => this.loadBudgets());
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}