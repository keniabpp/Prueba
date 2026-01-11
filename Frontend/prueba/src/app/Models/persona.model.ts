
export interface Persona {
    id?: number;
    nombres: string;
    apellidos: string;
    numeroIdentificacion: string;
    tipoIdentificacion: string;
    email: string;
    fechaCreacion?: Date;
    identificacionCompleta?: string;
    nombreCompleto?: string;
}