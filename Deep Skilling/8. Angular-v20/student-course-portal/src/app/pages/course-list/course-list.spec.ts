import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';

import { provideMockStore, MockStore } from '@ngrx/store/testing';

import { CourseList } from './course-list';

describe('CourseList', () => {

  let component: CourseList;
  let fixture: ComponentFixture<CourseList>;
  let store: MockStore;

  const initialState = {
    courses: {
      courses: [
        {
          id: 1,
          name: 'Angular',
          credits: 4,
          fee: 12000,
          gradeStatus: 'passed'
        },
        {
          id: 2,
          name: 'ASP.NET Core',
          credits: 3,
          fee: 10000,
          gradeStatus: 'pending'
        }
      ],
      loading: false,
      error: null
    }
  };

  beforeEach(async () => {

    await TestBed.configureTestingModule({

      imports: [
        CourseList
      ],

      providers: [

        provideRouter([]),

        provideHttpClient(),

        provideHttpClientTesting(),

        provideMockStore({
          initialState
        })

      ]

    }).compileComponents();

    store = TestBed.inject(MockStore);

    fixture = TestBed.createComponent(CourseList);

    component = fixture.componentInstance;

    fixture.detectChanges();

  });

  it('should create', () => {

    expect(component).toBeTruthy();

  });

  it('should load initial courses from store', () => {

    expect(component.courses.length).toBeGreaterThan(0);

  });

  it('should show loading state', () => {

    store.setState({

      courses: {
        courses: [],
        loading: true,
        error: null
      }

    });

    fixture.detectChanges();

    expect(component.isLoading).toBeTrue();

  });

});