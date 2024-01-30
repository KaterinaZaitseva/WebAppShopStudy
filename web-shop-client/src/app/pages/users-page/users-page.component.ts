import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserModel } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.css']
})
export class UsersPageComponent implements OnInit{

  constructor(public usersService: UsersService) { }
  

  term: string = '';
  users$: Observable<IUserModel[]>;

  
  ngOnInit(): void {
    this.updateProducts();
  }

  updateProducts(): void {
    this.users$ = this.usersService.getAll();
  }

}