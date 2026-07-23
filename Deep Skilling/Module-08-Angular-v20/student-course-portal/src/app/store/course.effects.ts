import { Injectable, inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';

import * as CourseActions from './course.actions';
import { CourseService } from '../services/course';

@Injectable()
export class CourseEffects {

  private actions$ = inject(Actions);

  constructor(private courseService: CourseService) {}

  loadCourses$ = createEffect(() =>
    this.actions$.pipe(

      ofType(CourseActions.loadCourses),

      mergeMap(() =>
        this.courseService.getCourses().pipe(

          map(courses =>
            CourseActions.loadCoursesSuccess({ courses })
          ),

          catchError(error =>
            of(
              CourseActions.loadCoursesFailure({
                error: error.message
              })
            )
          )

        )
      )

    )
  );

}