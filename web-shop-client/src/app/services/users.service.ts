import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IUserModel } from "../models/user.model";


@Injectable()
export class UsersService {
    
    constructor(private httpClient: HttpClient) { }


    urlUser: string = "https://localhost:44351/api/Users";


    getAll(): Observable<IUserModel[]> {
        return this.httpClient.get<IUserModel[]>(this.urlUser);
    }

    delete(id: number) {
        return this.httpClient.delete<IUserModel>(this.urlUser + '/' + id);
    }
}