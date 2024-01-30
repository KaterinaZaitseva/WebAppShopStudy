import { Component, Input, OnInit } from '@angular/core';
import { IUserModel } from 'src/app/models/user.model';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.css']
})
export class UserProfilePageComponent {

  constructor(public storageService: TokenStorageService){}

}
