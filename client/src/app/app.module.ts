import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { TestErrorComponent } from './test-error/test-error.component';
import {ErrorInterceptor} from './core/interceptors/error.interceptor';
import {NgxSpinnerModule} from 'ngx-spinner';
import {LoadingInterceptors} from './core/interceptors/loading.interceptors';

@NgModule({
  declarations: [
    AppComponent,
    TestErrorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    NgxSpinnerModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptors, multi: true},
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }