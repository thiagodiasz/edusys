import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EstadoService {
    public url = "http://localhost:5000/";

    constructor(
        private http: HttpClient
    ) {
    
    }
    
    }