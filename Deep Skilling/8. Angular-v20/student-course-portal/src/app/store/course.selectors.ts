import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CourseState } from './course.reducer';

export const selectCourseState =
  createFeatureSelector<CourseState>('courses');

export const selectAllCourses =
  createSelector(
    selectCourseState,
    (state) => state.courses
  );

export const selectLoading =
  createSelector(
    selectCourseState,
    (state) => state.loading
  );

export const selectError =
  createSelector(
    selectCourseState,
    (state) => state.error
  );