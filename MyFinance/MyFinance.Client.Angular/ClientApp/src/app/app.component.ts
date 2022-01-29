import { Component } from '@angular/core';
     
class Item{
    company: string;
    title: string;
    price: number;
    select: boolean;
     
    constructor(company: string, title: string, price: number) {
        this.company = company;
        this.title = title;
        this.price = price;
        this.select = false;
    }
}
 
@Component({
    selector: 'main-app',
    templateUrl: './app.component.html'
})
export class AppComponent { 

    company: string = "";
    title: string = "";
    price: number = 0;

    items: Item[] = [];
    companies: string[] = ["Apple", "Huawei", "Xiaomi", "Samsung", "LG", "Motorola", "Alcatel"];

    addItem(): void {
        this.items.push(new Item(this.company, this.title, this.price));
    }
}