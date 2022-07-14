import { Component, OnInit } from '@angular/core';
import { BudgetService } from '../../services/budget.service';
import { Budget } from '../../models/budget';

@Component({
    selector: "budget-list",
    templateUrl: './budget-list.component.html',
})
export class BudgetListComponent implements OnInit {

    items: Budget[];

    constructor(private service: BudgetService) { }

    ngOnInit() {
        this.service.getItems().subscribe((data: Budget[]) => this.items = data);
    }

    load() {
        this.service.getItems().subscribe((data: Budget[]) => this.items = data);
    }

    delete(id: any) {
        this.service.deleteItem(id).subscribe(data => this.load());
    }
}