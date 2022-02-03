import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AuthInterceptor } from './auth.interceptor';
import { AuthenticationService } from './authentication.service';
import { LoginCallbackComponent} from './components/login-callback.component';
import { LogoutCallbackComponent } from './components/logout-callback.component';

@NgModule({
    declarations: [
        LoginCallbackComponent,
        LogoutCallbackComponent,
        //SilentCallbackComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
    ],
    providers: [
        AuthGuard,
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        AuthenticationService,
    ],
    exports: [
        LoginCallbackComponent,
        LogoutCallbackComponent,
        //SilentCallbackComponent,
    ]
})
export class NgAuthModule { }