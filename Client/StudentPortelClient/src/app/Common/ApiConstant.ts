export module ApiConstant {
    const SERVER_URI = 'http://localhost:55109/api/';
   export const AccountApi = {
         Login: SERVER_URI + 'Security/Login'
     };

     export const UserApi = {
        AddUser: SERVER_URI + 'User/AddUser',
        GetAllUser: SERVER_URI + 'User/GetAll'

    };
    export const StudentApi = {
        AddStudent: SERVER_URI + 'Student/AddStudent',
        GetAllStudent:  SERVER_URI + 'Student/GetAll'
        

    };
   }
