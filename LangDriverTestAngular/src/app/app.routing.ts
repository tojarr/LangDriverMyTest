import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { EditDictionaryComponent } from './edit-dictionary/edit-dictionary.component';
import { RegistrationComponent } from './registration/registration.component';
//import { DictionaryComponent } from './dictionary/dictionary.component'

const appRoutes: Routes = [
    {
        path: '',
        component: LoginComponent,
    },
    {
        path: 'registration',
        component: RegistrationComponent
    },
    {
        path: 'editDictionary',
        component: EditDictionaryComponent
    }/*,
    {
        path: 'dictionary',
        component: DictionaryComponent
    }*/
];

export const routing = RouterModule.forRoot(appRoutes, { useHash: true });