import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter, ActivatedRoute } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';

import { CourseDetail } from './course-detail';

describe('CourseDetail', () => {

  let component: CourseDetail;
  let fixture: ComponentFixture<CourseDetail>;

  beforeEach(async () => {

    await TestBed.configureTestingModule({

      imports: [
        CourseDetail
      ],

      providers: [

        provideRouter([]),

        provideHttpClient(),

        provideHttpClientTesting(),

        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: {
                get: () => '1'
              }
            }
          }
        }

      ]

    }).compileComponents();

    fixture = TestBed.createComponent(CourseDetail);

    component = fixture.componentInstance;

    fixture.detectChanges();

  });

  it('should create', () => {

    expect(component).toBeTruthy();

  });

});