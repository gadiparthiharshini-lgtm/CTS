import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../services/course';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home implements OnInit {

  portalName = 'Student Course Portal';

  isPortalActive = true;

  message = '';

  searchTerm = '';

  courseCount = 0;

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {

  this.courseService.getCourses().subscribe({

    next: (courses) => {
      this.courseCount = courses.length;
    },

    error: (err) => {
      console.error('Error loading courses:', err);
    }

  });

  console.log('Home Component initialized');

}
}