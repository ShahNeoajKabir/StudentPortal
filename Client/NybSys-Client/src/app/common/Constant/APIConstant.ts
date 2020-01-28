export module ApiConstant {
    export const AuthenticationApi = {
        Login: 'security/login',
        Logout: 'security/logout',
        ChangePassword:  'security/change-password',
        ForgotPassword:  'security/forgotpassword',
        ResetPassword:  'security/reset-password'
    };

    export const UserApi = {
        AddUser: 'Security/create-user',
        UpdateUser: 'Security/update-user',
        UserFilter: 'Security/get-users-by-filter',
        GetUser: 'Security/get-user',
        ResetPassword: 'Security/reset-password'
    };

    export const LogApi = {
        AuditLogFilter: 'Log/get-auditlog-by-filter',
        SessionLogFilter: 'Security/get-session-by-filter',
        CancelSession: 'Security/cancel-session'
    };

    export const AccessRight = {
        GetAllAccessRight : 'Security/get-all-access-control',
        GetAllAccessRightByRole : 'Security/get-access-control-by-role',
    };
}
