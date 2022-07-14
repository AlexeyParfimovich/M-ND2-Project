import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Budget } from '../models/budget';

@Injectable()
export class BudgetService {

    private url = "https://localhost:5001/api/v1/budgets";

    constructor(private http: HttpClient) {
    }

    getItems() {
        return this.http.get(this.url + '/filter');
    }

    getItem(id: string) {
        return this.http.get(this.url + '/' + id);
    }

    createItem(item: Budget) {
        return this.http.post(this.url, item);
    }

    updateItem(item: Budget) {
        return this.http.put(this.url, item);
    }

    deleteItem(id: string) {
        return this.http.delete(this.url + '/' + id);
    }
}