import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {routing, appRoutingProviders} from './app.routes';

import { AppComponent } from './app.component';
import { HeaderComponent} from './shared/header/header.component';
import { NavbarComponent} from './shared/navbar/navbar.component';
import { HomeComponent} from './home/home.component';
import { ProductComponent} from './products/products.component';
import { ForbiddenComponent} from './forbidden/forbidden.component';
import { UnauthorizedComponent} from './unauthorized/unauthorized.component';
import { AuthorizedComponent} from './authorized/authorized.component';

import {Configuration} from './app.constants';
import { SecurityService} from './services/security.service';
import { ProductService} from './services/product.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ForbiddenComponent,
    UnauthorizedComponent,
    AuthorizedComponent,
    HeaderComponent,
    NavbarComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    SecurityService, 
    ProductService,
    Configuration,
    appRoutingProviders
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
