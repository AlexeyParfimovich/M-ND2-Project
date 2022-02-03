import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BudgetService } from '../../services/budget.service';
import { Budget } from '../../models/budget';

@Component({
    selector: "budget-edit",
    templateUrl: './budget-edit.component.html'
})
export class BudgetEditComponent implements OnInit {

    id: any;
    item: Budget;    // изменяемый объект
    loaded: boolean = false;

    constructor(private service: BudgetService, private router: Router, activeRoute: ActivatedRoute) {
        this.id = activeRoute.snapshot.params["id"];
    }

    ngOnInit() {
        if (this.id)
            this.service.getItem(this.id)
                .subscribe((data: Budget) => {
                    this.item = data;
                    if (this.item != null) this.loaded = true;
                });
    }

    save() {
        this.service.updateItem(this.item).subscribe(data => this.router.navigateByUrl("/"));
    }
}