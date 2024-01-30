import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { IUserModel } from 'src/app/models/user.model';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent {

  constructor(private nzMessageService: NzMessageService,
    private usersService: UsersService) {}
  

  @Input() user: IUserModel;
  @Output() onChange : EventEmitter<any> = new EventEmitter();
 

  updateProducts(): void {
    this.onChange?.emit();
  }


  cancelDelete(): void {
    this.nzMessageService.info('Cancellation of deletion');
  }

  confirmDelete(): void {
    this.nzMessageService.info('Successful deletion');
    this.usersService.delete(this.user.id!).subscribe(
      () => this.updateProducts()
    );
  }

}
