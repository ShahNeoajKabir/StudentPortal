
export module ApiConstant {

    const SERVER_URI = 'http://localhost:55109/api/';
   export const AccountApi = {
         Login: SERVER_URI + 'Security/Login'
     };

     export const UserApi = {
        AddUser: SERVER_URI + 'User/AddUser',
        UpdateUser: SERVER_URI + 'User/UpdateUser',

        GetAllUser: SERVER_URI + 'User/GetAll',
        GetUserById: SERVER_URI + 'User/GetbyID'


    };
    export const StudentApi = {
        AddStudent: SERVER_URI + 'Student/AddStudent',
        GetAllStudent:  SERVER_URI + 'Student/GetAll',
        UpdateStudent: SERVER_URI + 'Student/UpdateStudent',
        GetStudentById: SERVER_URI + 'Student/GetById'
    };
    export const ParentsApi = {
        AddParents: SERVER_URI + 'Parents/AddParents',
        GetAllParents: SERVER_URI + 'Parents/GetAll',
        UpdateParents: SERVER_URI + 'Parents/UpdateParents',
        GetParentsById: SERVER_URI + 'Parents/GetById'
    };
    export const CourseApi = {
        AddCourse: SERVER_URI + 'Course/AddCourse',
        GetAllCourse: SERVER_URI + 'Course/GetAll',
        UpdateCourse: SERVER_URI + 'Course/UpdateCourse',
        GetCourseById: SERVER_URI + 'Course/GetById'
    };
    export const TeacherApi = {
        AddTeacher: SERVER_URI + 'Teacher/AddTeacher',
        GetAllTeacher: SERVER_URI + 'Teacher/GetAll',
        UpdateTeacher: SERVER_URI +'Teacher/UpdateTeacher',
        GetTeacherById: SERVER_URI + 'Teacher/GetById'
    };
    export const SemesterApi ={
        AddSemester: SERVER_URI + 'Semester/AddSemester',
        ViewSemester: SERVER_URI + 'Semester/GetAll',
        UpdateSemester: SERVER_URI + 'Semester/UpdateSemester',
        GetTeacherById: SERVER_URI + 'Semester/GetById'

    };
    export const RoutineApi ={
        AddRoutine: SERVER_URI + 'Routine/AddRoutine',
        ViewRoutine: SERVER_URI + 'Routine/GetAll',
        UpdateRoutine: SERVER_URI + 'Routine/UpdateRoutine',
        GetRoutineById: SERVER_URI + 'Routine/GetById'

    };


   }
