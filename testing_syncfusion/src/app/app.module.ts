import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TreeGridModule } from '@syncfusion/ej2-angular-treegrid';
import { RowDDService } from '@syncfusion/ej2-angular-treegrid';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TreeGridModule
  ],
  providers: [RowDDService],
  bootstrap: [AppComponent]
})
export class AppModule { }
