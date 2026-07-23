import { HttpInterceptorFn } from '@angular/common/http';
import { tap } from 'rxjs';

export const loggingInterceptor: HttpInterceptorFn = (req, next) => {

  console.log('Request URL:', req.url);
  console.log('HTTP Method:', req.method);

  return next(req).pipe(

    tap(event => {
      console.log('Response received:', event);
    })

  );

};