"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataService = void 0;
var DataService = /** @class */ (function () {
    function DataService() {
        this.data = ["Apple iPhone XR", "Samsung Galaxy S9", "Nokia 9"];
    }
    DataService.prototype.getData = function () {
        return this.data;
    };
    DataService.prototype.addData = function (name) {
        this.data.push(name);
    };
    return DataService;
}());
exports.DataService = DataService;
//# sourceMappingURL=data.service.js.map