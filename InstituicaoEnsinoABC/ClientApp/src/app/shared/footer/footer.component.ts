import { Component, Input } from '@angular/core';
import { StoreService } from '../../store.service';
import { Router } from '@angular/router';
import { faHome } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent {

  faHome = faHome;

  usuarioLogado: any = {};

  @Input() sistema = '';
  @Input() modulo = '';

  dtHoje: string = new Date().toLocaleDateString();

  constructor(
    private store: StoreService,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;
  }

  ngOnInit() {

  }

}
