import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StoreService } from '../../../store.service';
import { faHome, faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import { UsuarioDataService } from '../../../_data-services/usuario.data-service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
})
export class UsuarioComponent {

  faHome = faHome;
  faArrowLeft = faArrowLeft;

  sistema: string = 'gestao';
  modulo: string = 'usuarios';
  titulo: string = 'Usuário';

  usuarioLogado: any = {};

  usuario_id: any = 0;
  acao: any = '';
  usuario: any = {};

  isDisabled: any = false;
  resenha: any = '';
  pwdRequired: any = false;

  constructor(
    private store: StoreService,
    private usuarioDataService: UsuarioDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.usuarioDataService = usuarioDataService;
  }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.usuario_id = p.id;
      this.acao = (p.acao ? p.acao : 'cadastrar');

      if (this.usuario_id) {
        this.getById(this.usuario_id);
      }

      if (this.acao == 'detalhes' || this.acao == 'remover') {
        this.isDisabled = true;
      }
      if (this.acao == 'cadastrar') {
        this.pwdRequired = true;
      }
    })
  }

  getById(usuario_id) {
    this.usuarioDataService.getById(usuario_id).subscribe((data:any[]) => {
      console.log(data);
      this.usuario = data;
      this.usuario.senha = '';
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  onSubmit() {
    if (this.usuario.login === undefined || this.usuario.login === '' || this.usuario.login === null) {
      document.getElementById('inputLogin').focus();
      return;
    }
    if (this.usuario.email === undefined || this.usuario.email === '' || this.usuario.email === null) {
      document.getElementById('inputEmail').focus();
      return;
    }
    if (this.acao == 'cadastrar') {
      if (this.usuario.senha === undefined || this.usuario.senha === '' || this.usuario.senha === null) {
        document.getElementById('inputSenha').focus();
        return;
      }
      this.cadastrarUsuario();
    } else if (this.acao == 'editar') {
      this.editarUsuario();
    } else if (this.acao == 'remover') {
      this.removerUsuario(this.usuario_id);
    }
  }

  cadastrarUsuario() {
    if (this.usuario.senha && this.usuario.senha != this.resenha) {
      alert('Senhas divergentes');
      return;
    }
    this.usuarioDataService.post(this.usuario).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['usuarios']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  editarUsuario() {
    if (this.usuario.senha && this.usuario.senha != this.resenha) {
      alert('Senhas divergentes');
      return;
    }
    this.usuarioDataService.put(this.usuario).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['usuarios']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

  removerUsuario(usuario_id) {
    this.usuarioDataService.delete(usuario_id).subscribe(data => {
      if (data) {
        alert('Operação realizada com sucesso');
        this.router.navigate(['usuarios']);
      } else {
        alert('Falha na operação');
      }
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
