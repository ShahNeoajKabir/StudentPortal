export class RequestMessage {
    UserId: string;
    SessionId: number;
    Content: string;
    UserTypeId: number;

    constructor(UserID, SessionId, reqBody: any, UserTypeId) {
        this.UserId = UserID;
        this.SessionId = SessionId;
        this.Content = JSON.stringify(reqBody);
        this.UserTypeId = UserTypeId;
    }
}
