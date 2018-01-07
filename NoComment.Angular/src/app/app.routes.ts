import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from '../app/app.component';
import { HomeComponent } from './components/home/home.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { Navigation } from 'selenium-webdriver';
import { NavigationComponent } from './components/navigation/navigation.component';
import { ForumsComponent } from './components/forums/forums.component';
export const routes: Routes = [
	{ path: '', component: HomeComponent },  // home page
	{ path: 'forbidden', component: ForbiddenComponent },
	{ path: 'forums', component: ForumsComponent },
];

export const routing = RouterModule.forRoot(routes);