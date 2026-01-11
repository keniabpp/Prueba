import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../../Models/persona.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  usuario: any = null;
  personas: Persona[] = [];
  mostrarPersonas = false;
  cargandoPersonas = false;

  constructor(
    private router: Router,
    private personaService: PersonaService
  ) {}

  ngOnInit(): void {
    // Obtener usuario del localStorage
    const usuarioGuardado = localStorage.getItem('usuario');
    if (usuarioGuardado) {
      this.usuario = JSON.parse(usuarioGuardado);
    } else {
      // Si no hay usuario, redireccionar al login
      this.router.navigate(['/login']);
    }
  }

  logout(): void {
    localStorage.removeItem('usuario');
    this.router.navigate(['/login']);
  }
  
  verPersonas(): void {
    this.mostrarPersonas = !this.mostrarPersonas;
    
    if (this.mostrarPersonas && this.personas.length === 0) {
      this.listPersonas();
    }
  }
  
  listPersonas(): void {
    this.cargandoPersonas = true;
    this.personaService.ObtenerTodasPersonas().subscribe({
      next: (data) => {
        this.personas = data;
        this.cargandoPersonas = false;
      },
      error: (err) => {
        console.error('Error al cargar personas:', err);
        this.cargandoPersonas = false;
      }
    });
  }
}