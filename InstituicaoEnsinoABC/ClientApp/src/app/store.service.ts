import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  _token: string;
  _usuarioLogado: any;

  constructor() { }

  set token(value) {
    this._token = value;
  }

  get token() {
    return this._token;
  }

  set usuario(value) {
    this._usuarioLogado = value;
  }

  get usuario() {
    return this._usuarioLogado;
  }
}
