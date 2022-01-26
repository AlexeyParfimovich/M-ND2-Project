import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Budget } from '../models/budget';

@Injectable()
export class BudgetService {

    private url = "https://localhost:5001/api/v1/budgets";

    constructor(private http: HttpClient) {
    }

    getBudgets() {
        return this.http.get(this.url + '/filter');
    }

    getBudget(id: string) {
        return this.http.get(this.url + '/' + id);
    }

    createBudget(product: Budget) {
        return this.http.post(this.url, product);
    }

    updateBudget(product: Budget) {

        return this.http.put(this.url, product);
    }

    deleteBudget(id: string) {
        return this.http.delete(this.url + '/' + id);
    }
}