import { Routes } from '@angular/router';

export const routes: Routes = [

    {
        path: 'login',
        loadComponent: () =>
            import('./features/auth/login/login')
                .then(m => m.Login)
    },

    {
        path: 'reset-password',
        loadComponent: () =>
            import('./features/auth/reset-password/reset-password')
                .then(m => m.ResetPassword)
    },

    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },

    {
        path: '**',
        redirectTo: 'login'
    }
];