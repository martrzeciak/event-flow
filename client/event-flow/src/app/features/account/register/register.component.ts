import { Component, inject } from '@angular/core';
import { TextInputComponent } from "../../../shared/components/text-input/text-input.component";
import { SnackbarService } from '../../../core/services/snackbar.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms'
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-register',
  imports: [
    ReactiveFormsModule,
    MatButton,
    TextInputComponent
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  private formBuilder = inject(FormBuilder);
  private snack = inject(SnackbarService);
  validationErrors?: string[];

  registerForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
  });

  onSubmit() {
  }
}
