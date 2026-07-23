import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { routes } from './app.routes';
import { loggingInterceptor } from './interceptors/logging-interceptor';
import { provideStore } from '@ngrx/store';
import { courseReducer } from './store/course.reducer';
import { provideEffects } from '@ngrx/effects';
import { CourseEffects } from './store/course.effects';

export const appConfig: ApplicationConfig = {
  providers: [
  provideRouter(routes),

  provideHttpClient(
    withInterceptors([
      loggingInterceptor
    ])
  ),

  provideStore({
    courses: courseReducer
  }),

  provideEffects([
    CourseEffects
  ])
]
};