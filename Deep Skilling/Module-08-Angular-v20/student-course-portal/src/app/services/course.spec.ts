import { TestBed } from '@angular/core/testing';
import {
  provideHttpClient,
  withInterceptorsFromDi
} from '@angular/common/http';

import {
  provideHttpClientTesting,
  HttpTestingController
} from '@angular/common/http/testing';

import { CourseService } from './course';

describe('CourseService', () => {

  let service: CourseService;
  let httpMock: HttpTestingController;

  beforeEach(() => {

    TestBed.configureTestingModule({
      providers: [
        CourseService,
        provideHttpClient(withInterceptorsFromDi()),
        provideHttpClientTesting()
      ]
    });

    service = TestBed.inject(CourseService);
    httpMock = TestBed.inject(HttpTestingController);

  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {

    expect(service).toBeTruthy();

  });

  it('should fetch courses', () => {

    const mockCourses = [

      {
        id: 1,
        name: 'Angular'
      },

      {
        id: 2,
        name: 'ASP.NET Core'
      }

    ];

    service.getCourses().subscribe(courses => {

      expect(courses.length).toBe(2);

      expect(courses[0].name).toBe('Angular');

    });

    const req = httpMock.expectOne(
      'http://localhost:3000/courses'
    );

    expect(req.request.method).toBe('GET');

    req.flush(mockCourses);

  });

  it('should handle server error', () => {

    service.getCourses().subscribe({

      next: () => fail('Expected error'),

      error: err => {

        expect(err.status).toBe(500);

      }

    });

    const req = httpMock.expectOne(
      'http://localhost:3000/courses'
    );

    req.flush(
      'Server Error',
      {
        status: 500,
        statusText: 'Server Error'
      }
    );

  });

});