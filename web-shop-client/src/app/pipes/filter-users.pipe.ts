import { Pipe, PipeTransform } from '@angular/core';
import { IUserModel } from '../models/user.model';

@Pipe({
  name: 'filterUsers'
})
export class FilterUsersPipe implements PipeTransform {

  transform(users: IUserModel[], search: string): IUserModel[] {
    if(search.length === 0) return users
    return users.filter(u => u.login.toLowerCase().includes(search.toLowerCase()));
  }

}
