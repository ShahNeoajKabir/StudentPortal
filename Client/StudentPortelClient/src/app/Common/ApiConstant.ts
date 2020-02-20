export module ApiConstant {
    const SERVER_URI = 'http://localhost:55109/api/';
   export const AccountApi = {
         Login: SERVER_URI + 'Security/Login'
     };

     export const UserApi = {
        AddUser: SERVER_URI + 'User/AddUser'
    };
   }
// export module ApiConstant{

//     export const AccountApi = {
//         Login: 'Security/Login'

//     };
//     export const UserApi={
//         AddUser: 'User/AddUser'
//     }

// }