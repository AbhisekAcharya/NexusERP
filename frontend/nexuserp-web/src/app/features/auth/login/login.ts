import { ChangeDetectorRef, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})

export class Login {
    loginForm: FormGroup;
    forgotPasswordForm: FormGroup;
    submitted = false;
    forgotPasswordSubmitted = false;
    showPassword = false;
    showForgotPasswordModal = false;
    showLoginResultModal = false;
    loginResultType: 'success' | 'error' = 'success';
    loginResultTitle = '';
    loginResultMessage = '';
    isLoading = false;
    loginError = '';
    constructor(
        private fb: FormBuilder,
        private authService: AuthService,
        private router: Router,
        private cdr: ChangeDetectorRef
    ) 
    {

        this.loginForm = this.fb.group({
            username: [
                '',
                [
                    Validators.required,
                    Validators.minLength(3)
                ]
            ],

            password: [
                '',
                [
                    Validators.required,
                    Validators.minLength(8)
                ]
            ],

            rememberMe: [false]
        });

        this.forgotPasswordForm = this.fb.group({
            username: [
                '',
                [
                    Validators.required,
                    Validators.minLength(3)
                ]
            ]
        });
    }

    get username() {
        return this.loginForm.get('username');
    }

    get usernameInvalid(): boolean {
        return !!(
            this.username?.invalid &&
            (this.username?.touched || this.submitted)
        );
    }

    get password() {
        return this.loginForm.get('password');
    }

    get passwordInvalid(): boolean {
        return !!(
            this.password?.invalid &&
            (this.password?.touched || this.submitted)
        );
    }

    togglePassword(): void {
        this.showPassword = !this.showPassword;
    }

    get forgotEmail() {
        return this.forgotPasswordForm.get('username');
    }

    openForgotPassword(): void {
        this.showForgotPasswordModal = true;
        this.forgotPasswordSubmitted = false;
        this.forgotPasswordForm.reset();
    }

    closeForgotPassword(): void {
        this.showForgotPasswordModal = false;
        this.forgotPasswordSubmitted = false;
        this.forgotPasswordForm.reset();
    }

    closeLoginResult(): void {
        this.showLoginResultModal = false;
    }

    private openLoginResult(type: 'success' | 'error', title: string, message: string): void {
        this.loginResultType = type;
        this.loginResultTitle = title;
        this.loginResultMessage = message;
        this.showLoginResultModal = true;
    }

    submitForgotPassword(): void {
        this.forgotPasswordSubmitted = true;
        this.forgotPasswordForm.markAllAsTouched();

        if (this.forgotPasswordForm.invalid) {
            return;
        }

        console.log('Forgot password requested for:', this.forgotPasswordForm.value.username);
        this.closeForgotPassword();
    }

    onLogin(): void {
    this.submitted = true;
    this.loginError = '';
    this.loginForm.markAllAsTouched();
    if (this.loginForm.invalid) {
        return;
    }
    this.isLoading = true;
    const request = {
        username: this.loginForm.value.username,
        password: this.loginForm.value.password
    };
    this.authService.login(request).subscribe({
        next: (response) => {
            console.log('Login successful:', response);
            this.isLoading = false;
            this.openLoginResult(
                'success',
                'Login Successful',
                response.message || 'Welcome back to NexusERP.'
            );
            this.cdr.markForCheck();
            // We'll handle token storage next.
            // We'll also add dashboard navigation next.
        },
        error: (error) => {
            console.error('Login failed:', error);
            this.isLoading = false;
            if (error.status === 401) {
                this.loginError = 'Invalid username or password.';
            } else if (error.name === 'TimeoutError') {
                this.loginError = 'The server is taking too long to respond. Please check the API and database connection.';
            } else {
                this.loginError =
                    'Unable to sign in. Please try again later.';
            }
            this.openLoginResult(
                'error',
                'Login Failed',
                error.error?.message || error.message || this.loginError
            );
            this.cdr.markForCheck();
        }
    });
}
}
