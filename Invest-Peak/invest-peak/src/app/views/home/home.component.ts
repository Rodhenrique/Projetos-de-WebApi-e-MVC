import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Usuario } from 'src/app/shared/models/usuario.model';
import { UsuarioeService } from 'src/app/shared/service/usuario.service';
import { DialogComponent } from './dialog/dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public formUser!: FormGroup;
  
  constructor(
    private fb: FormBuilder,
    private service: UsuarioeService,
    public dialog: MatDialog
    ) { }
    
    ngOnInit(): void {
    this.formUser = this.fb.group({
      nome: ['',[Validators.required]],
      parcelas: ['',[Validators.required]],
      valor: ['',[Validators.required]]
    })
  }

  postUser(){
    if(this.formUser.value.nome != "" && this.formUser.value.parcelas != "" && this.formUser.value.valor){
      this.service.Post(this.formUser.value).subscribe(data =>{
        this.service.PutTexto(data.toString());
        this.dialog.open(DialogComponent);
        this.formUser.reset();
      })
    }
  }
}

