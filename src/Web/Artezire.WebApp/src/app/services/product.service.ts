import { Injectable, EventEmitter } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { Configuration } from '../app.constants';
import {ProductModel} from '../shared//models/product.model';

import { SecurityService} from './security.service';

@Injectable()
export class ProductService {

    public IsAuthorized: boolean;
    public HasAdminRole: boolean;

    products: ProductModel[] = [];

    constructor(private _http: Http, private _securityService: SecurityService){}

    

    public GetProductsList(): Observable<ProductModel[]>{
        debugger;
        // add authorization header with jwt token
        let headers = new Headers({ 'Authorization': 'Bearer ' + this._securityService.GetToken() });
        let options = new RequestOptions({ headers: headers });

        let url = 'http://localhost:65180/api/product';
        return this._http.get(url, options)
                .map((response: Response) => response.json());
    }

}