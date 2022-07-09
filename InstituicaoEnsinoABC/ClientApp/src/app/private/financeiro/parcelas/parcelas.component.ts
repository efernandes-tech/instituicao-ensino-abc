import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faPlus, faSearch, faPencilAlt, faTrash, faArrowLeft, faDollarSign } from '@fortawesome/free-solid-svg-icons';
import { ContratoDataService } from '../../../_data-services/contrato.data-service';

interface Contrato {
    [parcelas:string]: any;
}

@Component({
  selector: 'app-parcelas',
  templateUrl: './parcelas.component.html',
})
export class ParcelasComponent {

  faHome = faHome;
  faPlus = faPlus;
  faSearch = faSearch;
  faPencilAlt = faPencilAlt;
  faTrash = faTrash;
  faArrowLeft = faArrowLeft;
  faDollarSign = faDollarSign;

  sistema: string = 'financeiro';
  modulo: string = 'contratos';
  titulo: string = 'Parcelas';

  usuarioLogado: any = {};

  parcelas: any = [];

  contrato_id: any = 0;

  constructor(
    private store: StoreService,
    private contratoDataService: ContratoDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.contratoDataService = contratoDataService;
  }

  ngOnInit() {
    console.log('start component');
    this.route.params.subscribe(p => {
      this.contrato_id = p.id_contrato;
    });
    this.getAll(this.contrato_id);
  }

  getAll(contrato_id) {
    console.log('getAll');
    this.contratoDataService.getById(contrato_id).subscribe((data:Contrato) => {
      console.log(data);
      this.parcelas = data.parcelas;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
