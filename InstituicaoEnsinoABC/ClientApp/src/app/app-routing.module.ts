import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './public/page-not-found/page-not-found.component';

import { LoginComponent } from './public/login/login.component';
import { HomeComponent } from './private/home/home.component';

import { UsuariosComponent } from './private/gestao/usuarios/usuarios.component';
import { UsuarioComponent } from './private/gestao/usuario/usuario.component';
import { AlunosComponent } from './private/gestao/alunos/alunos.component';
import { AlunoComponent } from './private/gestao/aluno/aluno.component';

import { ContratosComponent } from './private/financeiro/contratos/contratos.component';
import { ParcelasComponent } from './private/financeiro/parcelas/parcelas.component';
import { PagamentoComponent } from './private/financeiro/pagamento/pagamento.component';

import { AppGuard } from './app.guard';

const routes: Routes = [
    // app
    { path: '', component: HomeComponent, pathMatch: 'full' , canActivate: [AppGuard] },
    { path: 'home', component: HomeComponent, canActivate: [AppGuard] },
    { path: 'login', component: LoginComponent },
    // gestao
    { path: 'usuarios', component: UsuariosComponent , canActivate: [AppGuard] },
      { path: 'usuario', component: UsuarioComponent , canActivate: [AppGuard] },
      { path: 'usuario/:id/:acao', component: UsuarioComponent , canActivate: [AppGuard] },
    { path: 'alunos', component: AlunosComponent , canActivate: [AppGuard] },
      { path: 'aluno', component: AlunoComponent , canActivate: [AppGuard] },
      { path: 'aluno/:id/:acao', component: AlunoComponent , canActivate: [AppGuard] },
    // financeiro
    { path: 'contratos', component: ContratosComponent , canActivate: [AppGuard] },
    { path: 'contrato/:id_contrato', component: ParcelasComponent , canActivate: [AppGuard] },
    { path: 'pagamento/:id_parcela/:id_contrato', component: PagamentoComponent, canActivate: [AppGuard] },

    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
