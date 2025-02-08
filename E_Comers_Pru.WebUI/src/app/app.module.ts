import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginService } from './shared/service/login.service';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { validatorAccessRouterGuard } from './auth/service/aut.guard';
import { authInterceptorInterceptor } from './auth/service/auth.interceptos';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule,
    HttpClientModule
  ],
  providers: [LoginService,
    provideHttpClient(withInterceptors([authInterceptorInterceptor]))],
  bootstrap: []
})
export class AppModule { }
