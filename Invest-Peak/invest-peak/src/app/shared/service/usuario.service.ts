import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario.model';
import { UsuarioViewModel } from '../models/usuarioViewModel.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioeService {

  apiUrl = 'http://localhost:5000/api/Usuario';
  valor!: string;

  httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  };
  
  constructor(
    private httpClient: HttpClient
  ) { }

  public Post(NovoUsuario: any): Observable<Usuario>{
    console.log(JSON.stringify(NovoUsuario));
    return this.httpClient.post<any>(this.apiUrl,JSON.stringify(NovoUsuario),this.httpOptions);
  }

  public Get(): Observable<Usuario>{
    return this.httpClient.get<Usuario>(this.apiUrl);
  }

  public PutTexto(item:string){
    this.valor = item;
  }
  public ChangeTexto(){
    return this.valor;
  }
}
