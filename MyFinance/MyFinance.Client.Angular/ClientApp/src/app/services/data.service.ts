import { Injectable, Optional } from '@angular/core';
import { LogService } from './log.service';

@Injectable()
export class DataService {

    private data: string[] = ["Apple iPhone XR", "Samsung Galaxy S9", "Nokia 9"];

    constructor(@Optional() private logger: LogService) { }

    getData(): string[] {
        if (this.logger)
            this.logger.write('getting data');

        return this.data;
    }

    addData(name: string) {
        this.data.push(name);

        if (this.logger)
            this.logger.write('adding data');
    }
}