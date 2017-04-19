import { ModuleWithProviders } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { HomeComponent} from './home/home.component';
import { ProductComponent} from './products/products.component';
import { ForbiddenComponent} from './forbidden/forbidden.component';
import { UnauthorizedComponent} from './unauthorized/unauthorized.component';
import { AuthorizedComponent} from './authorized/authorized.component';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'home'
    },
    {
        path: 'home',
        component: HomeComponent
    },    
    {
        path: 'products',
        component: ProductComponent
    },
    {
        path: 'authorized',
        component: AuthorizedComponent
    },
    {
        path: '**',
        redirectTo: '/home',
        pathMatch: 'full'
    }
];

export const appRoutingProviders: any[] = [
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
