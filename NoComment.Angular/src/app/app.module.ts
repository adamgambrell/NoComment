// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ForumsComponent } from './components/forums/forums.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { IncidentsComponent } from './components/incidents/incidents.component';

// Routes
import { routing } from './app.routes';

// Pipes
import { MomentDatePipe } from './pipes/moment-date.pipe';

// Services
import { NoCommentService } from './services/noComment.service';
import { HttpService } from './services/http.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ForumsComponent,
    NavigationComponent,
    ForbiddenComponent,
    IncidentsComponent,
		MomentDatePipe
  ],
  imports: [
    BrowserModule,
    routing,
    HttpModule,
  ],
  providers: [
    HttpService,
    NoCommentService,
    { provide: APP_BASE_HREF, useValue: '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
