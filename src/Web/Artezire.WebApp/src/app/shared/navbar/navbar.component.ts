import { Component, OnInit } from '@angular/core';
import { SecurityService} from '../../services/security.service';

@Component({
    selector: 'art-navbar',
    templateUrl: 'navbar.component.html'
})
export class NavbarComponent implements OnInit{
    constructor(public securityService: SecurityService){}

    ngOnInit() {
        
    }

    public Login() {
        debugger;
        console.log("Do login logic");
        this.securityService.Authorize();
    }

    public Logout() {debugger;
        console.log("Do logout logic");
        this.securityService.Logoff();
    }
}