import { inject, Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Persona } from "../Models/persona.model";
import { Usuario } from "../Models/usuario.model";
import { Observable } from "rxjs/internal/Observable";



@Injectable({ providedIn: 'root' })
export class PersonaService {
    private apiUrl = `${environment.apiUrl}/persona`;
    private readonly _http = inject(HttpClient);

    ObtenerTodasPersonas(): Observable<Persona[]> {
        return this._http.get<Persona[]>(this.apiUrl);

    }

     ObtenerPersonaPorId(Id: number): Observable<Persona> {
        return this._http.get<Persona>(`${this.apiUrl}/${Id}`);
    }


    CrearPersona(persona: Persona): Observable<Persona> {
        return this._http.post<Persona>(`${this.apiUrl}/crear`, persona);
    }

    CrearUsuario(usuario: Usuario): Observable<Usuario> {
        return this._http.post<Usuario>(`${this.apiUrl}/crear-usuario`, usuario);
    }

    login(credentials: { nombreUsuario: string, pass: string }): Observable<Usuario> {
        return this._http.post<Usuario>(`${this.apiUrl}/login`, credentials);
    }
}