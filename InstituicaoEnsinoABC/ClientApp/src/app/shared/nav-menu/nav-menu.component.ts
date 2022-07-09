import { Component, Input } from '@angular/core';
import { StoreService } from '../../store.service';
import { Router } from '@angular/router';
import { faHome, faUserGraduate, faUsers, faSyringe, faFileSignature, faMoneyBillWave } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent {

  faHome = faHome;
  faUserGraduate = faUserGraduate;
  faUsers = faUsers;
  faSyringe = faSyringe;
  faFileSignature = faFileSignature;
  faMoneyBillWave = faMoneyBillWave;

  usuarioLogado: any = {};

  @Input() sistema = '';
  @Input() modulo = '';

  constructor(
    private store: StoreService,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;
  }

  ngOnInit() {

  }

  logout() {
    localStorage.removeItem('ieabc');

    this.router.navigate(['login']);
  }

}
