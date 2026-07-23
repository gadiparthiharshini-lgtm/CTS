import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { CourseService } from '../../services/course';

@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.css'
})
export class CourseDetail implements OnInit {

  course: any;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService
  ) {}

  ngOnInit(): void {

  const id = Number(this.route.snapshot.paramMap.get('id'));

  this.courseService.getCourseById(id).subscribe({

    next: (data) => {
      this.course = data;
    },

    error: (err) => {
      console.error('Error loading course:', err);
      this.course = null;
    }

  });

}

}