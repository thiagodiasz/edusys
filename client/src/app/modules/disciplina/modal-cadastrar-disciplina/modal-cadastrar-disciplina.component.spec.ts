/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ModalCadastrarDisciplinaComponent } from './modal-cadastrar-disciplina.component';

describe('ModalCadastrarDisciplinaComponent', () => {
  let component: ModalCadastrarDisciplinaComponent;
  let fixture: ComponentFixture<ModalCadastrarDisciplinaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalCadastrarDisciplinaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalCadastrarDisciplinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
