import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { StoreService } from './store.service';

@Injectable({
  providedIn: 'root'
})
export class AppGuard implements CanActivate {

  constructor(
    private store: StoreService,
    private router: Router
  ) {}

  canActivate() {
    if ( ! this.store.token) {
      this.router.navigate(['login']);
      return;
    }

    return true;
  }
}
