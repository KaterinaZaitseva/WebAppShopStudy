import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, tap, catchError } from 'rxjs';

import { IUserAuthorizationModel } from '../models/user-authorization.model';
import { IUserResponseAuthorizationModel } from '../models/user-response-authorization.model';
import { TokenStorageService } from './token-storage.service';
import { IUserRegistrationModel } from '../models/user-registration.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private http: HttpClient,
    private tokenStorageService: TokenStorageService
  ) { }

  private authorizeUrl = 'https://localhost:44351/api/Authorization/Authorize';
  private registerUrl = 'https://localhost:44351/api/Authorization/Register';
  userResponseAuthModel: IUserResponseAuthorizationModel; 

  logIn(userAuthModel: IUserAuthorizationModel): Observable<IUserResponseAuthorizationModel> {
    return this.http.post<IUserResponseAuthorizationModel>(this.authorizeUrl, userAuthModel)
      .pipe(
        tap(userResponseAuthModel => {
          if(userResponseAuthModel != null) {
            this.tokenStorageService.saveUser(userResponseAuthModel);
            this.userResponseAuthModel = userResponseAuthModel;
          }
        })
      )
  }

  logOut(): void {
    this.tokenStorageService.deleteUser();
  }

  signUp(userRegModel: IUserRegistrationModel) {
    return this.http.post(this.registerUrl, userRegModel);
  }
}
