import { Component } from '@angular/core';
import { StoreService } from './store.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(
    private store: StoreService
  ) {
    var _ieabc = JSON.parse(localStorage.getItem('ieabc'));

    this.store.token = (_ieabc && _ieabc.token ? _ieabc.token : '');
    this.store.usuario = (_ieabc && _ieabc.usuario ? _ieabc.usuario : '');
  }

}
