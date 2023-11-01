import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Query, ViewChild } from '@angular/core';
import { Detail, Product } from './models/Product';
import { DropDownList, DropDownListComponent } from '@syncfusion/ej2-angular-dropdowns';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  @ViewChild('dropdown') public dropdown?: DropDownListComponent;
  public editparams: Object | undefined;
  data:Product | undefined | null = null;
  dropdownObj:any;
  elem:any;
  public dropdownFields: Object = { text: 'text', value: 'value' }
  details:Detail[] = [];
   editSettings = {
    allowEditing: true,
    allowAdding: true,
    allowDeleting: true,
};

  constructor(private httpClient:HttpClient){

  }
  ngOnInit(): void {
    this.httpClient.get<Product>("https://localhost:44396/api/Products/1").subscribe(c=>{
      this.data =  c;
      this.details =  this.buildTree(c.details,null);
      console.log(this.details);

    });

    this.editparams = {
      create: () => {
          this.elem = document.createElement('input');
          return this.elem;
      },
      read: () => {
          return this.dropdownObj.text;
      },
      destroy: () => {
          this.dropdownObj .destroy();
      },
      write: (args: { rowData: any, column: any }) => {

          this.dropdownObj  = new DropDownList({
            dataSource: [{text:"GS1",value:"GS1"}, {text:"EGS", value:"EGS"}] ,
               fields: { text: 'text', value: 'value' }
          });
          this.dropdownObj .appendTo(this.elem);
      }
  }

  }
  title = 'testing_new_structure';

  buildTree(data: Detail[], parentId?: number | null): Detail[] {
    const result: Detail[] = [];
    for (const item of data) {
      if (item.parentId === parentId ) {
        const children = this.buildTree(data, item.id);
        if (children.length > 0) {
          item.children = children;
        }
        result.push(item);
      }
    }

    return result;
  }




}
