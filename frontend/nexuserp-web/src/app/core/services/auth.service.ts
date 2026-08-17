import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, timeout } from 'rxjs';

export interface LoginRequest {
    username: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    userId: string;
    employeeId: string;
    username: string;
    role: string;
}

export interface ApiResponse<T> {
    data: T;
    message: string;
    statusCode: number;
}

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private readonly apiUrl = 'https://localhost:7214/api/auth';
    constructor(private http: HttpClient) {}
    login(request: LoginRequest): Observable<ApiResponse<LoginResponse>> {
        return this.http.post<ApiResponse<LoginResponse>>(
            `${this.apiUrl}/login`,
            request
        ).pipe(timeout(5000));
    }
}
