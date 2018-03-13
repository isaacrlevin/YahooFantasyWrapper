import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { JsonViewerComponent } from './components/json-viewer/json-viewer.component';
import { HomeComponent } from './containers/home/home.component';
import { InteractiveComponent } from './containers/interactive/interactive.component';
import { LoadingModule } from 'ngx-loading';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginService, LoadingService, UserService, InteractiveService, LoadingInterceptor } from './shared/index';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    JsonViewerComponent,
    HomeComponent,
    InteractiveComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    LoadingModule,
    FormsModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'interactive', component: InteractiveComponent }
    ])
  ],
  providers: [
    LoginService,
    LoadingService,
    UserService,
    InteractiveService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
