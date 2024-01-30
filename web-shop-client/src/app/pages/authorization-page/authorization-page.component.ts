import { Component, OnInit } from '@angular/core';
import { FormControl, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-authorization-page',
  templateUrl: './authorization-page.component.html',
  styleUrls: ['./authorization-page.component.css']
})
export class AuthorizationPageComponent implements OnInit {

  constructor(
    private authService: AuthorizationService, 
    private router: Router
  ) {}
  
  validateForm!: UntypedFormGroup;

  submitForm(): void {
    if (this.validateForm.valid) {
      this.authService.logIn({
          login: this.validateForm.value.userName as string,
          password: this.validateForm.value.password as string 
      })
      .subscribe(() => {
          if(this.authService.userResponseAuthModel != null){
            this.router.navigate(['/home']);
          }
        }
      );
    } 
    else {
      Object.values(this.validateForm.controls).forEach(control => {
          if (control.invalid) {
            control.markAsDirty();
            control.updateValueAndValidity({ onlySelf: true });
          }
        }
      );
    }
  }

  ngOnInit(): void {
    this.validateForm = new UntypedFormGroup({
      userName: new FormControl<string>('', [
        Validators.required,
      ]),
      password: new FormControl<string>('', [
        Validators.required,
      ])
    }) 
  }

}