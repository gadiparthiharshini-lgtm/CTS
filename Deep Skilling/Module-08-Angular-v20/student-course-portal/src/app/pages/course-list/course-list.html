<div *ngIf="isLoading">
    <p>Loading courses...</p>
</div>

<div *ngIf="!isLoading; else noCourses">

    <h2>Available Courses</h2>

    <div
    *ngFor="let course of courses; trackBy: trackByCourseId"
    class="course-card"
    [ngClass]="cardClasses"
    appHighlight="#dff6ff">

        <h3
            [ngStyle]="{
                'color': course.gradeStatus === 'passed' ? 'green' :
                         course.gradeStatus === 'pending' ? 'orange' : 'red'
            }">
            {{ course.name | uppercase }}
        </h3>

        <p>Credits: {{ course.credits | creditLabel }}</p>

        <p>Fee: {{ course.fee | currency:'INR' }}</p>

        <p>Start Date: {{ course.startDate | date:'dd/MM/yyyy' }}</p>

        <div [ngSwitch]="course.gradeStatus">

            <p *ngSwitchCase="'passed'" [ngClass]="course.gradeStatus">
                ✅ Passed
            </p>

            <p *ngSwitchCase="'pending'" [ngClass]="course.gradeStatus">
                ⏳ Pending
            </p>

            <p *ngSwitchCase="'failed'" [ngClass]="course.gradeStatus">
                ❌ Failed
            </p>

            <p *ngSwitchDefault>
                Unknown
            </p>

        </div>

        <button (click)="viewCourse(course.id)">
    Show Details
</button>

    </div>

</div>

<ng-template #noCourses>
    <p>No courses available.</p>
</ng-template>