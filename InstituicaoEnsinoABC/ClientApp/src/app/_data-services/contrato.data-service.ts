import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { StoreService } from '../store.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class ContratoDataService {

  module: string = environment.apiUrl + '/api/contrato';

  headers: HttpHeaders;

  constructor(
    private http: HttpClient,
    private store: StoreService,
  ) {
    this.headers = new HttpHeaders({
      'Content-Type':'application/json; charset=utf-8',
      'authorization': `bearer ${this.store.token}`
    })
  }

  getAll() {
    return this.http.get(this.module, { headers: this.headers });
  }

  getById(contrato_id) {
    return this.http.get(`${this.module}/${contrato_id}`, { headers: this.headers });
  }

  post(data) {
    return this.http.post(this.module, data, { headers: this.headers });
  }

  put(data) {
    return this.http.put(this.module, data, { headers: this.headers });
  }

  delete(contrato_id) {
    return this.http.delete(`${this.module}/${contrato_id}`, { headers: this.headers });
  }

  getParcelaAll(contrato_id) {
    return this.http.get(this.module+'/parcela/'+contrato_id, { headers: this.headers });
  }

  getParcelaById(parcela_id, contrato_id) {
    return this.http.get(`${this.module}/parcela/${parcela_id}/${contrato_id}`, { headers: this.headers });
  }

  postParcela(data) {
    return this.http.post(this.module+'/parcela', data, { headers: this.headers });
  }

  putParcela(data) {
    return this.http.put(this.module+'/parcela', data, { headers: this.headers });
  }

  deleteParcela(parcela_id) {
    return this.http.delete(`${this.module}/parcela/${parcela_id}`, { headers: this.headers });
  }

}
