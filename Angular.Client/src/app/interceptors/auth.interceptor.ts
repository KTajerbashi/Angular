import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  console.log("interceptor");
  let _token = '';
  let _jwt = req.clone({
    setHeaders:{
      Authorization : 'bearer '+_token
    }
  })
  return next(_jwt);
};
