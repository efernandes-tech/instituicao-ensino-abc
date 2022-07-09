import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { AlunoDataService } from '../../../_data-services/aluno.data-service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
})
export class AlunoComponent {

  faHome = faHome;
  faArrowLeft = faArrowLeft;

  sistema: string = 'gestao';
  modulo: string = 'alunos';
  titulo: string = 'Aluno';

  usuarioLogado: any = {};

  aluno_id: any = 0;
  acao: any = '';
  aluno: any = {};

  isDisabled: any = false;

  constructor(
    private store: StoreService,
    private alunoDataService: AlunoDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.alunoDataService = alunoDataService;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.aluno_id = p.id;
      this.acao = (p.acao ? p.acao : 'cadastrar');

      if (this.aluno_id) {
        this.getById(this.aluno_id);
      }

      if (this.acao == 'detalhes' || this.acao == 'remover') {
        this.isDisabled = true;
      }
    })
  }

  getById(aluno_id) {
    this.alunoDataService.getById(aluno_id).subscribe((data:any[]) => {
      console.log(data);
      this.aluno = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  onSubmit() {
    if (this.aluno.nomeCompleto === undefined || this.aluno.nomeCompleto === '' || this.aluno.nomeCompleto === null) {
      document.getElementById('nome_completo_aluno').focus();
      return;
    }
    if (this.aluno.cpf === undefined || this.aluno.cpf === '' || this.aluno.cpf === null) {
      document.getElementById('inputCpf').focus();
      return;
    }
    if (this.acao == 'cadastrar') {
      this.cadastrarAluno();
    } else if (this.acao == 'editar') {
      this.editarAluno();
    } else if (this.acao == 'remover') {
      this.removerAluno(this.aluno_id);
    }
  }

  cadastrarAluno() {
    this.alunoDataService.post(this.aluno).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  editarAluno() {
    this.alunoDataService.put(this.aluno).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  removerAluno(aluno_id) {
    this.alunoDataService.delete(aluno_id).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['alunos']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
