import { Routes } from "@angular/router";
import { LoginComponent } from "./pages/login/login.component";
import { RegistrationComponent } from "./pages/registration/registration.component";

const Auth_Routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegistrationComponent }
        ]
    }
];

export { Auth_Routes };