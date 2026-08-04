import { Component, signal } from '@angular/core';
// import { RouterOutlet } from '@angular/router';
import { Login } from './features/auth/login/login';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Login],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // protected readonly title = signal('nexuserp-web');
}
