import { Component } from '@angular/core';
import { StoreService } from '../../../store.service';
import { faHome, faPlus, faSearch, faPencilAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { UsuarioDataService } from '../../../_data-services/usuario.data-service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
})
export class UsuariosComponent {

  faHome = faHome;
  faPlus = faPlus;
  faSearch = faSearch;
  faPencilAlt = faPencilAlt;
  faTrash = faTrash;

  sistema: string = 'gestao';
  modulo: string = 'usuarios';
  titulo: string = 'Usuários';

  usuarioLogado: any = {};

  usuarios: any = [];

  constructor(
    private store: StoreService,
    private usuarioDataService: UsuarioDataService
  ) {
    this.usuarioLogado = store._usuarioLogado;

    this.usuarioDataService = usuarioDataService;
  }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.usuarioDataService.getAll().subscribe((data:any[]) => {
      this.usuarios = data;
    }, error => {
      console.log(error);
      alert('Falha na operação');
    })
  }

}
