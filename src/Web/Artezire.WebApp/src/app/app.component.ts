import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { SecurityService} from './services/security.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app works fine and fine and fine';

   constructor(public securityService: SecurityService) {
     }

    ngOnInit() {
        console.log("ngOnInit _securityService.AuthorizedCallback");
        debugger;
        if (window.location.hash) {
            this.securityService.AuthorizedCallback();
        }
    }
}
