import { Component } from '@angular/core';
import { StoreService } from '../../../store.service';
import { faHome, faPlus, faSearch, faPencilAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { AlunoDataService } from '../../../_data-services/aluno.data-service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
})
export class AlunosComponent {

  faHome = faHome;
  faPlus = faPlus;
  faSearch = faSearch;
  faPencilAlt = faPencilAlt;
  faTrash = faTrash;

  sistema: string = 'gestao';
  modulo: string = 'alunos';
  titulo: string = 'Alunos';

  usuarioLogado: any = {};

  alunos: any = [];

  constructor(
    private store: StoreService,
    private alunoDataService: AlunoDataService
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.alunoDataService = alunoDataService;
  }

  ngOnInit() {
    console.log('start component');
    this.getAll();
  }

  getAll() {
    console.log('getAll');
    this.alunoDataService.getAll().subscribe((data:any[]) => {
      console.log(data);
      this.alunos = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
