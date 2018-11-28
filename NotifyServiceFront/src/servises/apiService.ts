import axios from 'axios';
import { IMessage } from '../models/message';

const baseUrl = "http://localhost:50509/api";

interface IApiResponse{
    isSuccess:boolean;
    data?:any;
    error?:string;
}

interface IApiResponseGetAllMessages extends IApiResponse {
    data?:IMessage[];
}

interface IApiResponseSendMessage extends IApiResponse {
    data?:IMessage;
}

export default class {
    async getAllMessages():Promise<IApiResponseGetAllMessages>{
        try{
            const result = await axios.get(`${baseUrl}/Notify/GetAllMessages`);
            return {isSuccess:true, data:result.data};
        } catch {
            return  {isSuccess:true, error: 'api error'};
        }
        
    }

    async sendMessage(message:IMessage):Promise<IApiResponseSendMessage>{
        try{
            const result = await axios({
                method: 'post',
                url: `${baseUrl}/Notify/Send`,
                data: message,
                }
            );
            return {isSuccess:true, data:result.data};
        } catch(ex) {
            return  {isSuccess:true, error: 'api error'};
        }
    }
}