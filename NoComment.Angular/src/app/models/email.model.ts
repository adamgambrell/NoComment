import { Forum } from "./forum.model";

export class Email {
    public messageId: String;
    public inReplyToId: String;
    public date: Date;
    public authorEmail: String;
    public authorName: String;
    public subject: String;
    public content: String;
    public rootEmailId: String;
    public forum: Forum;
}
// [ForeignKey("RootEmailId")]
// public virtual Forum Forum { get; set; }