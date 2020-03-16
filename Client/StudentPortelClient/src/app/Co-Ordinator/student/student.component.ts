import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import * as _ from 'lodash';
import { Student } from 'src/app/Model/Student';
import { StudentService } from 'src/app/Service/student.service';
import { Utility } from 'src/app/Common/Utility';
import { Gender, Status } from 'src/app/Common/Enum';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  public objstudent: Student = new Student();
  public objstudentedit: Student = new Student();
  public StudentId: number;
  public lstGender: any;
  public lstStatus: any;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;

  constructor(private studentservice: StudentService , private router: Router , private utility: Utility ,
              private ActivateRouter: ActivatedRoute) { }

  ngOnInit() {
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstStatus = this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params[ 'id'] !== undefined) {
      this.objstudentedit.StudentId = this.ActivateRouter.snapshot.params[ 'id'];
      this.studentservice.GetStudentById(this.objstudentedit).subscribe((res: any) => {
        this.objstudent = res;
        console.log(this.objstudent);

      });
      console.log(this.ActivateRouter.snapshot.params[ 'id']);

    }

  }
  AddStudent() {
    console.log(this.objstudent);
    if (this.objstudent.StudentId > 0) {
      this.studentservice.UpdateStudent(this.objstudent).subscribe(res => {
        this.router.navigate(['/student/View']);

        if (res === 1) {
          console.log(res);
        }
        console.log(res);
      });

    } else {
      this.studentservice.AddStudent(this.objstudent).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/student/View']);
          console.log(res);
        }
        console.log(res);
      });
    }
}
fileChangeEvent(fileInput: any) {
  this.imageError = null;
  if (fileInput.target.files && fileInput.target.files[0]) {
      // Size Filter Bytes
      const max_size = 20971520;
      const allowed_types = ['image/png', 'image/jpeg'];
      const max_height = 15200;
      const max_width = 25600;

      if (fileInput.target.files[0].size > max_size) {
          this.imageError =
              'Maximum size allowed is ' + max_size / 1000 + 'Mb';

          return false;
      }

      if (!_.includes(allowed_types, fileInput.target.files[0].type)) {
          this.imageError = 'Only Images are allowed ( JPG | PNG )';
          return false;
      }
      const reader = new FileReader();
      reader.onload = (e: any) => {
          const image = new Image();
          image.src = e.target.result;
          image.onload = rs => {
              const img_height = rs.currentTarget['height'];
              const img_width = rs.currentTarget['width'];

              console.log(img_height, img_width);


              if (img_height > max_height && img_width > max_width) {
                  this.imageError =
                      'Maximum dimentions allowed ' +
                      max_height +
                      '*' +
                      max_width +
                      'px';
                  return false;
              } else {
                  const imgBase64Path = e.target.result;
                  this.cardImageBase64 = imgBase64Path;
                  this.isImageSaved = true;
                  this.objstudent.Image = this.cardImageBase64;
                  // this.previewImagePath = imgBase64Path;
              }
          };
      };

      reader.readAsDataURL(fileInput.target.files[0]);
  }
}

removeImage() {
  this.cardImageBase64 = null;
  this.objstudent.Image =  null;
  this.isImageSaved = false;
}


}
