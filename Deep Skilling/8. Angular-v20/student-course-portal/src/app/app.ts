import { Component } from '@angular/core';
import { Header } from './components/header/header';
import { Home } from './pages/home/home';
import { CourseList } from './pages/course-list/course-list';
import { StudentRegistration } from './pages/student-registration/student-registration';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [
    Header,
    Home,
    CourseList,
    StudentRegistration,
    RouterOutlet
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  portalTitle = 'Student Course Portal';

  onHomeMenuClicked(message: string) {
    alert(message);
  }

}