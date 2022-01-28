import { Component } from '@angular/core';
     
class Item{
    purchase: string;
    done: boolean;
    price: number;
     
    constructor(purchase: string, price: number) {
  
        this.purchase = purchase;
        this.price = price;
        this.done = false;
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

    edit(p: Budget) {
        this.budget = p;
    }

    cancel() {
        this.budget = new Budget();
        this.tableMode = true;
    }

    addItem(text: string, price: number): void {
         
        if(text==null || text.trim()=="" || price==null)
            return;
        this.items.push(new Item(text, price));
    }
}