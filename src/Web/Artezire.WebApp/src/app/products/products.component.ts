import {Component} from '@angular/core';
import {CatalogResultListComponent} from '../shared/catalog/catalog-result-list.component';
import {ProductService} from '../services/product.service';

@Component({
    templateUrl: 'products.component.html',
    providers: [ProductService]
})

export class ProductComponent {
}