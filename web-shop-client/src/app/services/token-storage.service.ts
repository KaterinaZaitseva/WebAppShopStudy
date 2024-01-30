import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IUserResponseAuthorizationModel } from '../models/user-response-authorization.model';

const KEY_LOGIN = 'Login';
const KEY_ROLE = 'Role';
const KEY_TOKEN = 'Token';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private cookieService: CookieService){}

  saveUser(user: IUserResponseAuthorizationModel){
    this.deleteUser();
    this.cookieService.set(KEY_LOGIN, user.login);
    this.cookieService.set(KEY_ROLE, user.role);
    this.cookieService.set(KEY_TOKEN,user.jwtToken);
  }

  deleteUser(): void{
    this.cookieService.delete(KEY_LOGIN);
    this.cookieService.delete(KEY_ROLE);
    this.cookieService.delete(KEY_TOKEN);
  }

  getUserLogin(): string {
    return this.cookieService.get(KEY_LOGIN);
  }

  getUserRole(): string {
    return this.cookieService.get(KEY_ROLE);
  }

  getUserToken(): string {
    return this.cookieService.get(KEY_TOKEN);
  }
}