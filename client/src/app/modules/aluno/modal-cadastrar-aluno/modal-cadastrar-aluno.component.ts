import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-modal-cadastrar-aluno',
  templateUrl: './modal-cadastrar-aluno.component.html',
  styleUrls: ['./modal-cadastrar-aluno.component.css'],
  standalone: true,
  imports: [MatButtonModule, MatDividerModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, FormsModule, MatFormFieldModule, MatInputModule],

})
export class ModalCadastrarAlunoComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ModalCadastrarAlunoComponent>
  ) { }

  ngOnInit() {

  }

}
