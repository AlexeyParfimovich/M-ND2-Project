import { Component, Input } from '@angular/core';
import { Budget } from '../../models/budget';

@Component({
    selector: "budget-form",
    templateUrl: './budget-form.component.html'
})
export class BudgetFormComponent {
    @Input() item: Budget;
}