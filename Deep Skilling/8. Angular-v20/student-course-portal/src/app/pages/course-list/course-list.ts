import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Highlight } from '../../directives/highlight';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';
import { CourseService } from '../../services/course';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import * as CourseActions from '../../store/course.actions';
import * as CourseSelectors from '../../store/course.selectors';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, Highlight, CreditLabelPipe],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList implements OnInit {

  isLoading = true;
  isExpanded = false;

  courses: any[] = [];
  
  constructor(private courseService: CourseService, 
    private router: Router, 
    private store: Store) { }
  
  toggleDetails() {
    this.isExpanded = !this.isExpanded;
  }

  get cardClasses() {
    return {
      expanded: this.isExpanded
    };
  }
  viewCourse(id: number) {
  this.router.navigate(['/courses', id]);
}
viewDetails(id: number) {
  this.router.navigate(['/courses', id]);
}

  ngOnInit(): void {

  this.store.dispatch(CourseActions.loadCourses());

  this.store.select(CourseSelectors.selectAllCourses)
    .subscribe(courses => {
      this.courses = courses;
    });

  this.store.select(CourseSelectors.selectLoading)
    .subscribe(loading => {
      this.isLoading = loading;
    });

}

}