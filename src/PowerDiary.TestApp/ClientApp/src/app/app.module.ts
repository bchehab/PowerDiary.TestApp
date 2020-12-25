import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule, MatProgressSpinnerModule, MatSelectModule, MatSnackBarModule } from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { DailyReportComponent } from './daily-report/daily-report.component';
import { HomeComponent } from './home/home.component';
import { HourlyReportComponent } from './hourly-report/hourly-report.component';
import { httpErrorsInterceptorProviders } from './http-error.interceptor';
import { httpRequestInterceptorProviders } from './http-request.interceptor';
import { LoadingIndicatorComponent } from './loading-indicator/loading-indicator.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DailyReportComponent,
    HourlyReportComponent,
    LoadingIndicatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    FormsModule,
    MatPaginatorModule,
    MatSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'daily', component: DailyReportComponent },
      { path: 'hourly', component: HourlyReportComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [httpErrorsInterceptorProviders, httpRequestInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
