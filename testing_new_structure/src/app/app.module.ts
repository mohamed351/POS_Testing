import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TreeGridModule , RowDDService, EditService } from '@syncfusion/ej2-angular-treegrid';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';

import {HttpClientModule} from "@angular/common/http";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TreeGridModule,
    DropDownListModule,
    HttpClientModule
  ],
  providers: [RowDDService , EditService],
  bootstrap: [AppComponent]
})
export class AppModule { }
