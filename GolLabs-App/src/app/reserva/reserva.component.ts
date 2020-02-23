import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../_services/reserva.service';
import { Reserva } from '../_models/Reserva';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsModalService, BsLocaleService } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reserva',
  templateUrl: './reserva.component.html',
  styleUrls: ['./reserva.component.css']
})
export class ReservaComponent implements OnInit {

  reservas: Reserva[];
  reserva: Reserva;
  registerForm: FormGroup;
  modoSalvar = 'post';
  bodyDeletarReserva = "";
  dataHoraPartida = "";

  constructor(
                  private reservaService: ReservaService
                , private fb: FormBuilder
                , private modalService: BsModalService
                , private localeService: BsLocaleService
                , private toastr: ToastrService
              ) 
      {
          this.localeService.use('pt-br');
      }

  ngOnInit() {
    this.validation();
    this.getReservas();
  }

  getReservas() {
    this.reservaService.getAllReservas().subscribe(
      (_reservas: Reserva[]) => {
        this.reservas = _reservas;
        //this.eventosFiltrados = this.eventos;
    }, error => {
      console.log(error);
    });
  }

  novaReserva(template: any){
    //this.modoSalvar = 'post';
    this.openModal(template);
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  validation(){
    this.registerForm = this.fb.group({
      nome: ['', Validators.required],
      dataHoraPartida: ['', Validators.required],
      origem: ['', Validators.required],
      destino: ['', Validators.required]
    });
  }

  incluirReserva(template: any){
    if(this.registerForm.valid)
    {
      if(this.modoSalvar === 'post'){
        this.reserva = Object.assign({}, this.registerForm.value);
        this.reservaService.postReservas(this.reserva).subscribe(
          (novaReserva: Reserva) => {
            template.hide();
            this.getReservas();
            this.toastr.success('Reserva incluída com sucesso!');
          }, error => {
            this.toastr.error(`Erro ao inserir: ${error}`);
          }
        );
      }
      else
      {
        this.reserva = Object.assign({id: this.reserva.id}, this.registerForm.value);
        this.reservaService.putReserva(this.reserva).subscribe(
          (novoEvento: Reserva) => {
            template.hide();
            this.getReservas();
            this.toastr.success('Reserva alterada com sucesso!');
          }, error => {
            this.toastr.error(`Erro ao alterar: ${error}`);
          }
        );
      }
    }
  }

  editarReserva(reserva: Reserva, template: any){
    this.modoSalvar = 'put';
    this.openModal(template);
    this.reserva = reserva;
    this.registerForm.patchValue(reserva);
  }

  excluirReserva(reserva: Reserva, template: any) {
    this.openModal(template);
    this.reserva = reserva;
    this.bodyDeletarReserva = `Deseja excluir a Reserva de: ${reserva.nome}, Código: ${reserva.id}`;
  }

  confirmeDelete(template: any) {
    this.reservaService.deleteReserva(this.reserva.id).subscribe(
      () => {
          template.hide();
          this.getReservas();
          this.toastr.success('Reserva excluída com sucesso!');
        }, error => {
          this.toastr.success('Erro ao tentar excluir!');
          console.log(error);
        }
    );
  }

}
