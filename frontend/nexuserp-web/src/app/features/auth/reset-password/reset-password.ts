import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
    selector: 'app-reset-password',
    standalone: true,
    imports: [ CommonModule, ReactiveFormsModule ],
    templateUrl: './reset-password.html',
    styleUrl: './reset-password.css'
})
export class ResetPassword implements OnInit {
    resetPasswordForm: FormGroup;
    submitted = false;
    isLoading = false;
    showPassword = false;
    showConfirmPassword = false;
    token = '';
    errorMessage = '';
    resetSuccessful = false;

    constructor(
        private fb: FormBuilder,
        private authService: AuthService,
        private route: ActivatedRoute,
        private router: Router,
        private cdr: ChangeDetectorRef
    ) {

        this.resetPasswordForm = this.fb.group({
            newPassword: [
                '',
                [
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(128)
                ]
            ],
            confirmPassword: [
                '',
                [
                    Validators.required
                ]
            ]

        });
    }

    ngOnInit(): void {
        this.route.queryParamMap.subscribe(params => {

            this.token = params.get('token') || '';

            if (!this.token) {
                this.errorMessage =
                    'Invalid password reset link. Please request a new password reset link.';
            }

            this.cdr.markForCheck();
        });
    }

    get newPassword() {
        return this.resetPasswordForm.get('newPassword');
    }

    get confirmPassword() {
        return this.resetPasswordForm.get('confirmPassword');
    }

    togglePassword(): void {
        this.showPassword = !this.showPassword;
    }

    toggleConfirmPassword(): void {
        this.showConfirmPassword = !this.showConfirmPassword;
    }

    passwordsDoNotMatch(): boolean {

        return !!(
            this.newPassword?.value &&
            this.confirmPassword?.value &&
            this.newPassword.value !== this.confirmPassword.value
        );
    }

    onResetPassword(): void {

        this.submitted = true;
        this.errorMessage = '';

        this.resetPasswordForm.markAllAsTouched();

        if (this.resetPasswordForm.invalid) {
            return;
        }

        if (!this.token) {

            this.errorMessage =
                'Invalid password reset link. Please request a new reset link.';

            return;
        }

        if (this.passwordsDoNotMatch()) {

            this.errorMessage =
                'Passwords do not match.';

            return;
        }

        this.isLoading = true;

        const request = {
            token: this.token,
            newPassword: this.newPassword?.value
        };

        this.authService.resetPassword(request).subscribe({

            next: (response) => {

                console.log('Password reset successful:', response);

                this.isLoading = false;
                this.resetSuccessful = true;

                this.cdr.markForCheck();
            },

            error: (error) => {

                console.error('Password reset failed:', error);

                this.isLoading = false;

                this.errorMessage =
                    error.error?.message ||
                    'Unable to reset your password. The link may be invalid or expired.';

                this.cdr.markForCheck();
            }
        });
    }

    goToLogin(): void {
        this.router.navigate(['/login']);
    }
}