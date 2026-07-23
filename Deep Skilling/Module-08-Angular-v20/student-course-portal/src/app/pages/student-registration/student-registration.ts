import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-registration',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './student-registration.html',
  styleUrl: './student-registration.css'
})
export class StudentRegistration {

  student = {
    name: '',
    email: '',
    course: ''
  };

  onSubmit() {
    alert('Registration Successful!');
    console.log(this.student);
  }

}