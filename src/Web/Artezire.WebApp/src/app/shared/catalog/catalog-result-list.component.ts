import {Component, OnInit, OnDestroy, EventEmitter} from '@angular/core';
import {ProductModel} from '../models/product.model';
import {ProductService} from '../../services/product.service';

@Component({
    selector: 'catalog-result-list-component',
    templateUrl: 'catalog-result-list.component.html',
})

export class CatalogResultListComponent implements OnInit, OnDestroy {
    

    products: ProductModel[] = [];
    productCount: number = 0;

    constructor(private _service: ProductService) {
    }

    /**
     * update variables used in the template (change detection)
     */
    private updateProducts(products: ProductModel[]) {
        this.productCount = products.length;
        this.products = products.slice(0, 20);
    }

    ngOnInit() {debugger;
        /**
         * subscribe to the update event of ProductService to keep result-list in sync
         */
        this._service.GetProductsList().subscribe((products: ProductModel[])=> {
            this.updateProducts(products);
        });

        
    }

    ngOnDestroy() {
        
    }
}