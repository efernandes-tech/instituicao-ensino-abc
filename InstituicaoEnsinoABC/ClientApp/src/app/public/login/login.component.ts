import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../../_data-services/usuario.data-service';
import { Router } from '@angular/router';
import { StoreService } from '../../store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

   usuarioLogin: any = {};
   usuarioLogado: boolean = false;

  constructor(
    private usuarioDataService: UsuarioDataService,
    private router: Router,
    private store: StoreService,
    ) {
      this.usuarioLogado = store._usuarioLogado ? true : false;
  }

  ngOnInit() {
    console.log('start component');
  }

  authenticate() {
    this.usuarioDataService.authenticate(this.usuarioLogin).subscribe((data:any) => {
      console.log(data);
      if (data.usuario) {
        localStorage.setItem('ieabc', JSON.stringify(data));

        this.store.usuario = data.usuario;
        this.store.token = data.token;

        this.router.navigate(['home']);
      } else {
        alert('Usuário inválido');
      }
    }, error => {
      console.error(error);
      alert('Usuário inválido');
    })
  }

}
