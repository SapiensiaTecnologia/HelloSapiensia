import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable'; 
import { ICliente } from '../Models/cliente.interface';




@Injectable()
export class ClienteService {

    constructor(private http: Http) {}

    //get - pegar dados
    getClientes() {
        return this.http.get("/api/clientes")
            .map(data => <ICliente[]>data.json());
    }

    //post - incluir dados
    addCliente(cliente: ICliente) {
        return this.http.post("/api/clientes", cliente);
    }

    //put - alterar dados /api/clientes/1
    editCliente(cliente: ICliente) {
        return this.http.put(`/api/clientes/${cliente.id}`, cliente);
    }

    //delete - deletar dados /api/clientes/1
    deleteCliente(clienteId: number) {
        return this.http.delete(`/api/clientes/${clienteId}`);
    }
}