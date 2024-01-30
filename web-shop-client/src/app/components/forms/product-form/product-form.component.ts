import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl, UntypedFormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { NzFormTooltipIcon } from 'ng-zorro-antd/form';
import { IProductModel } from 'src/app/models/product-model';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  
  constructor() {
  }
  
  validateForm!: UntypedFormGroup;
  @Input() product : IProductModel;

  ngOnInit(): void {
    this.validateForm =  new UntypedFormGroup({
      name: new FormControl<string>('', [
        Validators.required,
      ]),
      description: new FormControl<string>('', [
        Validators.required,
      ]),
      price: new FormControl<string>('', [
        Validators.required,
      ]),
      pictureUrl: new FormControl<string>('', [
        Validators.required,
      ]),
    }) 
  }

  submitForm(): boolean {
    if (this.validateForm.valid) {
      return true;
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
      return false;
    }
  }

}