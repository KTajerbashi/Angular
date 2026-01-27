import { ApplicationConfig, isDevMode, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { tokenInterceptor } from './interceptors/token-interceptor';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { ProductReducer } from './store/product/product.reducer.store';
import { ProductEffect } from './store/product/product.effect.store';
import { PrfileReducer, ProfileEffect } from './store/userState/userstate.flow.store';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClient(withInterceptors([tokenInterceptor])),
    provideStore({
      productStore: ProductReducer,
      profileStore: PrfileReducer,
    }),
    provideEffects(ProductEffect,ProfileEffect),
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() }),
  ],
};
