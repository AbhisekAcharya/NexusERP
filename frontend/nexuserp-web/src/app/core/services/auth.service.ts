import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, timeout } from 'rxjs';

export interface LoginRequest {
    usernameOrEmail: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    userId: string;
    employeeId: string;
    username: string;
    email: string;
    role: string;
}

export interface ForgotPasswordRequest {
    email: string;
}

export interface ForgotPasswordResponse {
    message: string;
}

export interface ResetPasswordRequest {
    token: string;
    newPassword: string;
}

export interface ResetPasswordResponse {
    message: string;
}

export interface ApiResponse<T> {
    data: T;
    message: string;
    statusCode: number;
}

@Injectable({providedIn: 'root'})

export class AuthService {
    private readonly apiUrl = 'https://localhost:7214/api/auth';
    constructor(private http: HttpClient) {}

    login(request: LoginRequest
    ): Observable<ApiResponse<LoginResponse>> {
        return this.http.post<ApiResponse<LoginResponse>>(
            `${this.apiUrl}/login`,
            request
        ).pipe(timeout(5000));
    }

    forgotPassword(request: ForgotPasswordRequest
    ): Observable<ApiResponse<ForgotPasswordResponse>> {
        return this.http.post<ApiResponse<ForgotPasswordResponse>>(
            `${this.apiUrl}/forgot-password`,
            request
        ).pipe(timeout(10000));
    }

    resetPassword(request: ResetPasswordRequest
    ): Observable<ApiResponse<ResetPasswordResponse>> {
        return this.http.post<ApiResponse<ResetPasswordResponse>>(
            `${this.apiUrl}/reset-password`,
            request
        ).pipe(timeout(10000));
    }
}