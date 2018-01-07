import { Email } from "./email.model";

export class Forum {
    public rootEmailId: String;
    public subject: String;
    public creationDate: Date;
    public emails: Email[];
}