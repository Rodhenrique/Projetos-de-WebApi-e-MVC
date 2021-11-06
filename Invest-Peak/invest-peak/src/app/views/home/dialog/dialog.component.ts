import { Component, OnInit } from '@angular/core';
import { UsuarioeService } from 'src/app/shared/service/usuario.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  public valor!: string;

  constructor(
    private services: UsuarioeService
  ) { }

  ngOnInit(): void {
    this.ChangeValor();
  }

  public ChangeValor(){
    this.valor = this.services.ChangeTexto();
  }
}
