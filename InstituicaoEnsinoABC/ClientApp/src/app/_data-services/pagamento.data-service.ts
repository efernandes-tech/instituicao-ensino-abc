import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { StoreService } from '../store.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class PagamentoDataService {

  module: string = environment.apiUrl + '/api/pagamento';

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

}
