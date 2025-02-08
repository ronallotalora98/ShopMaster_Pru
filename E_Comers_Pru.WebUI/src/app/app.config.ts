import { provideHttpClient, withInterceptors } from "@angular/common/http";
import { ApplicationConfig } from "@angular/core";
import { provideRouter } from "@angular/router";
import { authInterceptorInterceptor } from "./auth/service/auth.interceptos";
import { routes } from "./app-routing.module";


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    // provideStore(rootReducer),
    provideHttpClient(withInterceptors([authInterceptorInterceptor])),
  ],
};

// function provideStore(rootReducer: any): import("@angular/core").Provider | import("@angular/core").EnvironmentProviders {
//   throw new Error("Function not implemented.");
// }
