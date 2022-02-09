import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BudgetService } from '../../services/budget.service';
import { Budget } from '../../models/budget';

@Component({
    selector: "budget-create",
    templateUrl: './budget-create.component.html'
})
export class BudgetCreateComponent {

    item: Budget = new Budget(); // добавляемый объект

    constructor(private service: BudgetService, private router: Router) { }

    save() {
        this.service.createItem(this.item).subscribe(data => this.router.navigateByUrl("/budgets"));
    }
}