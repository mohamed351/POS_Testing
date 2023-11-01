import { Component } from '@angular/core';
import { sampleData } from './datasource';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  data:any[] = [];
  title = 'testing_syncfusion';
  public selectionSettings?: Object;
  public rowDrop?: Object;

  constructor(){
    this.data = sampleData;
  }
}
