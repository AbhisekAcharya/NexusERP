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
    ) {

        // Login form
        this.loginForm = this.fb.group({
            usernameOrEmail: [
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

        // Forgot password form...Keep this as username for now. We will change this to email when we implement the Forgot Password API.
        this.forgotPasswordForm = this.fb.group({
            email: [
                '',
                [
                    Validators.required,
                    Validators.email
                ]
            ]
        });
    }

    //  LOGIN FORM 
    get usernameOrEmail() {
        return this.loginForm.get('usernameOrEmail');
    }

    get usernameOrEmailInvalid(): boolean {
        return !!(
            this.usernameOrEmail?.invalid &&
            (this.usernameOrEmail?.touched || this.submitted)
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

    //  FORGOT PASSWORD 
    get forgotEmail() {
        return this.forgotPasswordForm.get('email');
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

    private openLoginResult(type: 'success' | 'error', title: string, message: string
    ): void {
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
        const request = { email: this.forgotPasswordForm.value.email };
        this.isLoading = true;
        this.authService.forgotPassword(request).subscribe({
            next: (response) => {
                this.isLoading = false;
                this.closeForgotPassword();
                this.openLoginResult('success', 'Check Your Email', response.data?.message || response.message || 'If an account exists for this email, a password reset link will be sent.' );
                this.cdr.markForCheck();
            },
            error: (error) => {
                console.error('Forgot password failed:', error);
                this.isLoading = false;
                this.openLoginResult('error', 'Request Failed', error.error?.message || 'Unable to process your password reset request. Please try again.' );
                this.cdr.markForCheck();
            }
        });
    }

    //  LOGIN 
    onLogin(): void {
        this.submitted = true;
        this.loginError = '';
        this.loginForm.markAllAsTouched();
        if (this.loginForm.invalid) {
            return;
        }
        this.isLoading = true;
        const request = {
            usernameOrEmail: this.loginForm.value.usernameOrEmail,
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
                // Token storage will be implemented next.
                // Dashboard navigation will also be implemented next.
            },

            error: (error) => {
                console.error('Login failed:', error);
                this.isLoading = false;
                if (error.status === 401) {
                    this.loginError = 'Invalid username/email or password.';

                } else if (error.name === 'TimeoutError') {
                    this.loginError = 'The server is taking too long to respond. Please check the API and database connection.';

                } else {
                    this.loginError = 'Unable to sign in. Please try again later.';
                }
                this.openLoginResult(
                    'error',
                    'Login Failed',
                    error.error?.message ||
                    error.message ||
                    this.loginError
                );
                this.cdr.markForCheck();
            }
        });
    }
}