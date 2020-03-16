import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentRegisteredCourseComponent } from './student-registered-course.component';

describe('StudentRegisteredCourseComponent', () => {
  let component: StudentRegisteredCourseComponent;
  let fixture: ComponentFixture<StudentRegisteredCourseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentRegisteredCourseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentRegisteredCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
