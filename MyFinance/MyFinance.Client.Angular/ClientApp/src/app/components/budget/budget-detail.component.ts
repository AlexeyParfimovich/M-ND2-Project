import { Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BudgetService } from '../../services/budget.service';
import { Budget } from '../../models/budget';

@Component({
    selector: "budget-detail",
    templateUrl: './budget-detail.component.html'
})
export class BudgetDetailComponent implements OnInit{

    id: any;
    item: Budget;    // отображаемый объект
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
}