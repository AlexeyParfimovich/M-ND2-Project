import { Component, OnInit, NgModule } from '@angular/core';
import { BudgetService } from './services/budget.service';
import { Budget } from './models/budget';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [BudgetService]
})
export class AppComponent implements OnInit {

    item: Budget = new Budget();   // изменяемый объект
    items: Budget[];               // массив объектов
    tableMode: boolean = true;     // табличный режим

    constructor(private service: BudgetService) { }

    // загрузка данных при старте компонента  
    ngOnInit() {
        this.loadItems();
    }

    // получение данные через сервис
    loadItems() {
        this.service.getItems()
            .subscribe((data: Budget[]) => this.items = data);
    }

    // сохранение данных
    save() {
        if (this.item.id == null) {
            this.service.createItem(this.item)
                .subscribe((data: Budget) => this.items.push(data));
        } else {
            this.service.updateItem(this.item)
                .subscribe(data => this.loadItems());
        }
        this.cancel();
    }

    // изменение данных
    change(item: Budget) {
        this.item = item;
    }

    // отменить изменения
    cancel() {
        this.item = new Budget();
        this.tableMode = true;
    }

    // удалить объект
    delete(item: Budget) {
        //console.log("delete budget "+ item.id);
        this.service.deleteItem(item.id)
            .subscribe(data => this.loadItems());
    }

    // добавить объект
    add() {
        this.cancel();
        this.tableMode = false;
    }
}