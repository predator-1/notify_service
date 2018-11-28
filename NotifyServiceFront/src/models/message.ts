export interface IMessage{
    id?:string;
    recipients:string[];
    subject:string;
    body:string;
    isSent?:boolean;
}