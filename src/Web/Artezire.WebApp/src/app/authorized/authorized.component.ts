import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'art-authorized',
    templateUrl: 'authorized.component.html'
})

export class AuthorizedComponent implements OnInit {

    public message: string;
    public values: any[];

    constructor() {
        this.message = 'AuthorizedComponent constructor';
    }

    ngOnInit() {
    }
}
