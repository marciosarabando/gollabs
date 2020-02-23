import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reserva } from '../_models/Reserva';
import { Observable } from 'rxjs';

@Injectable()
export class ReservaService {
    baseURL = 'http://localhost:5000/reserva';

constructor(private http: HttpClient) { }

getAllReservas(): Observable<Reserva[]>{
    return this.http.get<Reserva[]>(this.baseURL);
}

getAllReservasById(id: number): Observable<Reserva[]>{
    return this.http.get<Reserva[]>(this.baseURL);
}

postReservas(reserva: Reserva) {
    return this.http.post(this.baseURL, reserva);
}

putReserva(reserva: Reserva) {
    return this.http.put(`${this.baseURL}/${reserva.id}`, reserva);
}

deleteReserva(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
}

}
