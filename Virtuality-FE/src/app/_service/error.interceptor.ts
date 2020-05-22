import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                // For Unauthorized Error Code -401
                if (error instanceof HttpErrorResponse) {
                    if (error.status === 401) {
                        return throwError(error.statusText);
                    }
                    // For Explicit application Error and will take Server Errors too
                    const applicationError = error.headers.get('Application-Error');
                    if (applicationError) {
                        console.error(applicationError);
                        return throwError(applicationError);
                    }
                    // Chaecking for any other errors
                    // about commented code - to throw error in string
                    const serverError = error.error.errors;
                    let modalStateErrors; // = '';
                    if (serverError) { // && typeof modalStateErrors === 'object'
                    modalStateErrors = Object.values(serverError);
                        // for (const key in serverError) {
                        //     if (serverError[key]) {
                        //         modalStateErrors += serverError[key] + '\n';
                        //     }
                        // }
                    }
                    return throwError(modalStateErrors || serverError || 'Server-Error');
                }
            })
        );
    }
}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};
