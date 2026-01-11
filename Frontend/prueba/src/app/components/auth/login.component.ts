import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  nombreUsuario = '';
  pass = '';
  showPassword = false;

  
  errorMessage = '';

  constructor(
    private personaService: PersonaService,
    private router: Router,
    
  ) {}

  login() {
    if (!this.nombreUsuario || !this.pass) {
      this.errorMessage = 'Por favor complete todos los campos';
      return;
    }

    const credentials = {
      nombreUsuario: this.nombreUsuario,
      pass: this.pass
    };

    this.personaService.login(credentials).subscribe({
      next: (usuario) => {
        console.log('Login exitoso:', usuario);
        console.log('Navegando al dashboard...');
        // Guardar usuario en localStorage
        localStorage.setItem('usuario', JSON.stringify(usuario));
        // Redireccionar al dashboard
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        console.error('Error en login:', err);
        this.errorMessage = 'Credenciales inválidas';
      }
    });
  }

  

  navigateToRegister() {
    this.router.navigate(['/register']);
  }

  navigateToHome() {
    this.router.navigate(['/']);
  }

  // Método para alternar visibilidad de contraseña
  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
}