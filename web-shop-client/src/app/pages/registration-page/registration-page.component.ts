import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, ValidationErrors, UntypedFormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Observer, tap } from 'rxjs';
import { UserFormComponent } from 'src/app/components/forms/user-form/user-form.component';
import { IUserRegistrationModel } from 'src/app/models/user-registration.model';
import { AuthorizationService } from 'src/app/services/authorization.service';

@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrls: ['./registration-page.component.css']
})
export class RegistrationPageComponent {
  constructor(
    private authorizationService: AuthorizationService,
    private router: Router
  ){ }

  @ViewChild(UserFormComponent) userFormComponent: UserFormComponent | undefined;

  registerUser: IUserRegistrationModel = {
    login: '',
    password: ''
  };
  loginValid: boolean = true;

  resetForm(e: MouseEvent): void {
    this.userFormComponent?.resetForm(e);
  }

  submitForm(): void {
    if(this.userFormComponent?.submitForm()){
      this.authorizationService.signUp(this.registerUser).subscribe(() => {
        if(this.loginValid){
          this.authorizationService.logIn(this.registerUser).subscribe(() => {
            if(this.authorizationService.userResponseAuthModel != null){
              this.router.navigate(['/home']);
            }
          })
        }
      })
    }
  }

}
