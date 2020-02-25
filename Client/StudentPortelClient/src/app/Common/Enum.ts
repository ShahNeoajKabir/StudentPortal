export enum Gender {
    Male= 1,
    Female= 2,
    Select= -1
}
export enum Status {
    Active= 1,
    Inactive= 2,
    Delete= 3

}
export enum UserType {
    Admin= 1,
    CoOrdinator= 2,
    Studen= 3,
    Accounts= 4,
    Teacher= 5,
    Parents= 6,
    SuperAdmin= -1

}
export enum MarksType {
    Quiz1= 1,
    Quiz2= 2,
    Quiz3= 3,
    MidTerm= 4,
    Final= 5,

}
export enum ErrorCode {
    INTERNAL_SERVER_ERROR = 500,
    BAD_REQUEST = 400,
    NOT_FOUND = 404,
    UNAUTHENTICATE = 401,
    UNAUTHORIZED = 403,
    TOKEN_EXPIRED = 402,
    SESSION_EXPIRED = 419,
    MISSING_TOKEN = 417,
    INVALID_TOKEN_FORMAT = 406
}
