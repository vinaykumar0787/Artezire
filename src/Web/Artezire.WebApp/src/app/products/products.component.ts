import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'art-product',
    templateUrl: 'products.component.html'
})

export class ProductComponent implements OnInit {

    public message: string;
    public values: any[];

    constructor() {
        this.message = 'ProductComponent constructor';
    }

    ngOnInit() {
    }
}
