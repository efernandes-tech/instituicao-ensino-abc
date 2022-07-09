import { Component } from '@angular/core';
import { StoreService } from '../../store.service';
import { Router } from '@angular/router';
import { faSignOutAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
})
export class NavBarComponent {

  faSignOutAlt = faSignOutAlt;

  usuarioLogado: any = {};

  constructor(
    private store: StoreService,
    private router: Router
  ) {
    this.usuarioLogado = store._usuarioLogado;
  }

  ngOnInit() {
    console.log(this.usuarioLogado)
  }

  logout() {
    localStorage.removeItem('ieabc');

    this.router.navigate(['login']);
  }

}
