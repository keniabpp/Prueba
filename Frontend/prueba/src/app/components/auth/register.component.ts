import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../../Models/persona.model';
import { Usuario } from '../../Models/usuario.model';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  
  persona : Persona [] = [];

  isLoading = false;
  errorMessage = '';
  successMessage = '';
  personaId: number | null = null;
  
  

  constructor(
    private personaService: PersonaService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.listPersonas();

  }

  listPersonas() {
    this.personaService.ObtenerTodasPersonas().subscribe({
      next: (data) => {
        this.persona = data;
        console.log(this.persona);
      },
      error: (err) => {
        console.error('Error al cargar usuarios:', err);
      }
    })
  }

  // crear persona

  nuevaPersona: Persona = {

   
    nombres: '',
    apellidos: '',
    numeroIdentificacion: '',
    tipoIdentificacion: '',
    email: '',
    fechaCreacion: new Date(),
  };


    addPersona(): void {
    // Validar que no haya campos vacíos
    if (!this.nuevaPersona.nombres || !this.nuevaPersona.apellidos || 
        !this.nuevaPersona.numeroIdentificacion || !this.nuevaPersona.tipoIdentificacion || 
        !this.nuevaPersona.email) {
      this.errorMessage = 'Todos los campos son obligatorios';
      this.successMessage = '';
      return;
    }
    
    // Validar formato de email
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(this.nuevaPersona.email)) {
      this.errorMessage = 'Ingrese un email válido';
      this.successMessage = '';
      return;
    }
    
    this.personaService.CrearPersona(this.nuevaPersona).subscribe({
      next: (personaCreada) => {
        this.listPersonas();
        this.personaId = personaCreada.id!;
        this.successMessage = 'Persona creada correctamente';
        this.errorMessage = '';
        this.nuevaPersona = {

          nombres: '',
          apellidos: '',
          numeroIdentificacion: '',
          tipoIdentificacion: '',
          email: '',
          fechaCreacion: new Date(),
        };
        console.log('Usuario creado:', personaCreada);

      },

      error: (err) => {
        // console.error('Error al cargar usuarios:', err);
        this.successMessage = '';
        this.personaId = null;

        if (err.error?.errores?.length) {

          this.errorMessage = err.error.errores.map((e: any) => e.mensaje);
        }
        else if (err.error?.mensaje) {

          this.errorMessage = err.error.mensaje;
        }
        else {
          this.errorMessage = 'No se pudo registrar el usuario';
        }
      }

    })
  }

  // Método para copiar el ID al portapapeles
  copyToClipboard(): void {
    if (this.personaId) {
      navigator.clipboard.writeText(this.personaId.toString()).then(() => {
        console.log('ID copiado al portapapeles');
      }).catch(err => {
        console.error('Error al copiar: ', err);
      });
    }
  }
  
  // Método para abrir modal de usuario
  navigateUsuario(): void {
    if (this.personaId) {
      this.nuevoUsuario.personaId = this.personaId;
      this.showModal = true;
    }
  }
  
  // Método para cerrar modal
  closeModal(): void {
    this.showModal = false;
    this.nuevoUsuario = {
      personaId: 0,
      nombreUsuario: '',
      pass: '',
      fechaCreacion: new Date()
    };
  }

  // Modal properties
  showModal = false;
  showPassword = false;
  

  
  // Usuario para crear
  nuevoUsuario: Usuario = {
    personaId: 0,
    nombreUsuario: '',
    pass: '',
    fechaCreacion: new Date()
  };
  
  // Método para crear usuario
  crearUsuario(): void {
    // Validar que no haya campos vacíos
    if (!this.nuevoUsuario.nombreUsuario || !this.nuevoUsuario.pass) {
      this.errorMessage = 'Todos los campos son obligatorios';
      return;
    }
    
    // Validar longitud mínima de contraseña
    if (this.nuevoUsuario.pass.length < 8) {
      this.errorMessage = 'La contraseña debe tener al menos 8 caracteres';
      return;
    }
    
    // Validar carácter especial en contraseña
    const caracteresEspeciales = /[!@#$%^&*()_+\-=\[\]{}|;:,.<>?]/;
    if (!caracteresEspeciales.test(this.nuevoUsuario.pass)) {
      this.errorMessage = 'La contraseña debe contener al menos un carácter especial (!@#$%^&*()_+-=[]{}|;:,.<>?)';
      return;
    }
    
    if (this.personaId) {
      this.nuevoUsuario.personaId = this.personaId;
      this.personaService.CrearUsuario(this.nuevoUsuario).subscribe({
        next: (usuarioCreado) => {
          console.log('Usuario creado:', usuarioCreado);
          this.closeModal();
          this.successMessage = 'Usuario creado exitosamente. Redirigiendo al login...';
          this.personaId = null;
          this.errorMessage = ''; // Limpiar mensaje de error
          // Rediriger al login después de 1 segundos
          setTimeout(() => {
            this.router.navigate(['/login']);
          }, 1000);
        },
        error: (err) => {
          console.error('Error al crear usuario:', err);
          this.errorMessage = err.error || 'Error al crear el usuario';
        }
      });
    }
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToHome() {
    this.router.navigate(['/']);
  }

  // Método para alternar visibilidad de contraseña
  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }
}