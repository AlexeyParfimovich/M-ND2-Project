import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DataModule } from './data/data.module';
import { BoldDirective } from './directives/bold.directive';

import { DataService } from './services/data.service';
import { LogService } from './services/log.service';

@NgModule({
    imports: [BrowserModule, FormsModule, DataModule],
    declarations: [AppComponent, BoldDirective],
    providers: [DataService, LogService],
    bootstrap: [AppComponent]
})
export class AppModule { }
