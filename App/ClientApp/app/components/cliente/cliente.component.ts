import { Component, OnInit, OnDestroy } from '@angular/core';
import { ClienteService } from '../../Services/cliente.service';
import { ICliente } from '../../Models/cliente.interface';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { Provider } from '@angular/core';

@Component({
    selector: 'app-cliente',
    templateUrl: './cliente.component.html',
    providers: [ClienteService]
})
        
export class ClienteComponent implements OnInit {

    clientes: ICliente[] = [];
    cliente: ICliente = <ICliente>{};

    //formulario
    formLabel: string;
    isEditMode: boolean = false;
    form: FormGroup;

    constructor(private clienteService: ClienteService,
        private fb: FormBuilder) {
        this.form = fb.group({
            "nome": ["", Validators.required],
            "endereco": ["", Validators.required],
            "telefone": ["", Validators.required],
            "email": ["", Validators.required]
        });

        this.formLabel = "Adicionar Cliente";
    }


    ngOnInit() {
        this.getClientes();
    }

    private getClientes() {
        this.clienteService.getClientes().subscribe(
            data => this.clientes = data,
            error => alert(error),
            () => console.log(this.clientes)

        );
    }


    onSubmit() {

        this.cliente.nome = this.form.controls["nome"].value;
        this.cliente.endereco = this.form.controls["endereco"].value;
        this.cliente.telefone = this.form.controls["telefone"].value;
        this.cliente.email = this.form.controls["email"].value;

        if (this.isEditMode) { // editar
            this.clienteService.editCliente(this.cliente)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                });
        } else { // incluir
            this.clienteService.addCliente(this.cliente)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                });
        }
    };

    edit(cliente: ICliente) {
        this.formLabel = "Editar Cliente";
        this.isEditMode = true;
        this.cliente = cliente;
        this.form.get("nome")!.setValue(cliente.nome);
        this.form.get("endereco")!.setValue(cliente.endereco);
        this.form.get("telefone")!.setValue(cliente.telefone);
        this.form.get("email")!.setValue(cliente.email);
    };
        
    cancel() {
        this.formLabel = "Adicionar Cliente";
        this.isEditMode = false;
        this.cliente = <ICliente>{};
        this.form.get("nome")!.setValue('');
        this.form.get("endereco")!.setValue('');
        this.form.get("telefone")!.setValue('');
        this.form.get("email")!.setValue('');
    };

    delete(cliente: ICliente) {
        if (confirm("Deseja excluir essa cliente?")) {
            this.clienteService.deleteCliente(cliente.id)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                })
        }
    };
}