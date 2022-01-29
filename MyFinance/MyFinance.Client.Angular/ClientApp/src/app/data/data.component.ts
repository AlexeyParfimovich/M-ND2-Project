import { Component, Optional } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
    selector: 'data-comp',
    template: `<div>
        <div>
                <input [(ngModel)]="newItem" placeholder = "Модель" />
                <button (click)="addItem(newItem)">Добавить</button>
        </div>
        <table>
            <tr *ngFor="let item of items">
                <td>{{item}}</td>
            </tr>
        </table>
    </div>`,
})
export class DataComponent {

    newItem: string = "";
    items: string[] = [];

    constructor(private dataService: DataService) { }

    addItem(name: string) {

        this.dataService.addData(name);
    }
    ngOnInit() {
        this.items = this.dataService.getData();
    }
}