import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { ClienteService } from './Services/cliente.service';
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared,
        HttpModule,
        ReactiveFormsModule,
    ],
    providers: 
    [
        ClienteService,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
