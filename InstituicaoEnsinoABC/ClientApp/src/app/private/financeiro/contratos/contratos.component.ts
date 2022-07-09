import { Component } from '@angular/core';
import { StoreService } from '../../../store.service';
import { faHome, faPlus, faSearch, faPencilAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { ContratoDataService } from '../../../_data-services/contrato.data-service';

@Component({
  selector: 'app-contratos',
  templateUrl: './contratos.component.html',
})
export class ContratosComponent {

  faHome = faHome;
  faPlus = faPlus;
  faSearch = faSearch;
  faPencilAlt = faPencilAlt;
  faTrash = faTrash;

  sistema: string = 'financeiro';
  modulo: string = 'contratos';
  titulo: string = 'Contratos';

  usuarioLogado: any = {};

  contratos: any = [];

  constructor(
    private store: StoreService,
    private contratoDataService: ContratoDataService
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.contratoDataService = contratoDataService;
  }

  ngOnInit() {
    console.log('start component');
    this.getAll();
  }

  getAll() {
    console.log('getAll');
    this.contratoDataService.getAll().subscribe((data:any[]) => {
      console.log(data);
      this.contratos = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
