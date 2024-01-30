import { Component, Input } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, ValidationErrors, UntypedFormBuilder, Validators } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { IUserRegistrationModel } from 'src/app/models/user-registration.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent {

  constructor(private fb: UntypedFormBuilder) {
    this.validateForm = this.fb.group({
      login: ['', [this.duplicateValidator]],
      password: ['', [Validators.required]],
      confirm: ['', [this.confirmValidator]],
    });
  }

  @Input() registerUser: IUserRegistrationModel;
  @Input() loginValid: boolean;

  validateForm!: UntypedFormGroup;

  submitForm(): boolean {
    if (this.validateForm.valid) 
      return true;
    return false;
  }

  resetForm(e: MouseEvent): void {
    e.preventDefault();
    this.validateForm.reset();
    for (const key in this.validateForm.controls) {
      if (this.validateForm.controls.hasOwnProperty(key)) {
        this.validateForm.controls[key].markAsPristine();
        this.validateForm.controls[key].updateValueAndValidity();
      }
    }
  }

  validateConfirmPassword(): void {
    setTimeout(() => this.validateForm.controls.confirm.updateValueAndValidity());
  }

  confirmValidator = (control: UntypedFormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { error: true, required: true };
    } else if (control.value !== this.validateForm.controls.password.value) {
      return { confirm: true, error: true };
    }
    return {};
  };
  
  duplicateValidator = (control: UntypedFormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { error: true, required: true };
    } else if (!this.loginValid) {
      return {  duplicated: true, error: true };
    }
    return {};
  };

}
