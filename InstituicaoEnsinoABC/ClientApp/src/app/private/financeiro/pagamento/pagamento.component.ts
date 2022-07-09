import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { ContratoDataService } from '../../../_data-services/contrato.data-service';
import { PagamentoDataService } from '../../../_data-services/pagamento.data-service';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
})
export class PagamentoComponent {

  faHome = faHome;
  faArrowLeft = faArrowLeft;

  sistema: string = 'financeiro';
  modulo: string = 'contratos';
  titulo: string = 'Pagamento';

  usuarioLogado: any = {};

  contrato_id: any = 0;
  parcela_id: any = 0;

  parcela: any = {};
  parcelaJson: any = null;

  constructor(
    private store: StoreService,
    private contratoDataService: ContratoDataService,
    private pagamentoDataService: PagamentoDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.contratoDataService = contratoDataService;
    this.pagamentoDataService = pagamentoDataService;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.parcela_id = p.id_parcela;
      this.contrato_id = p.id_contrato;

      this.getParcelaById(this.parcela_id, this.contrato_id);
    })
  }

  getParcelaById(parcela_id, contrato_id) {
    this.contratoDataService.getParcelaById(parcela_id, contrato_id).subscribe((data:any[]) => {
      console.log(data);
      this.parcela = data;
      this.parcelaJson = JSON.parse(this.parcela.pagamento.pixResponse);
      console.log(this.parcelaJson)
      if (this.parcela.pagamento.pixStatus == 'COMPLETED') {
        this.router.navigate(['contrato/'+this.contrato_id]);
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
