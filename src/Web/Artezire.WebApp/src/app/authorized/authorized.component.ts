import { Component, OnInit } from '@angular/core';

import { ProductService} from '../services/product.service';

@Component({
    selector: 'art-authorized',
    templateUrl: 'authorized.component.html'
})

export class AuthorizedComponent implements OnInit {

    public message: string;
    public products: any[];

    constructor(private _productsService: ProductService) {
        this.message = 'AuthorizedComponent constructor';
    }

    ngOnInit() {
    }

    GetProducts(){
        this._productsService.GetProductsList().subscribe(
            data => {
                debugger;
                this.products = data;
            },
            error => {
                debugger;
                console.log(error);
            }
        );
    }
}
