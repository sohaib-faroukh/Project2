import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { CustomersService } from '../customers.service';
import { Router, ActivatedRoute } from '@angular/router';
import { extract_keys, showNotification, catchConnectionError } from 'src/app/additional/functions';
import { Customer } from 'src/app/models/Customer';
import { confirm } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-browse-customers',
  templateUrl: './browse-customers.component.html',
  styleUrls: ['./browse-customers.component.scss']
})
export class BrowseCustomersComponent implements OnInit {

  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  Keys: string[] = [];
  Customers:any[]=[];

  constructor(private srv: CustomersService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let res = this.route.snapshot.data["Customers"];

    console.log(res);

    this.Keys = extract_keys(res);
    console.log(this.Keys);
    this.Customers = res;
  }


  IsAutharized(event:string){
    return true;
  }



  deactivate(id: number) {
    var result = confirm("Are you sure?", "Delete Confirm");

    result.then((dialogResult) => {

      console.log(dialogResult);
      if (dialogResult == true) {
        this.srv.deactivate(id).subscribe(
          res => {
            if (res) {

              let ix = this.Customers.findIndex(ele => ele.Id == id);
              if(ix!=-1){
                this.Customers[ix].Status="INACTIVE";
              }
              showNotification("Dactivated succesfully", "bottom", "center", "success");
               console.log("DELETED : " + JSON.stringify(res));
            }
            else{
              showNotification("Deleted Failed , no result has returned", "bottom", "center", "danger");
              console.log("Deleted Failed , no result has returned , the result : "+res );
        
            }
          },
          err => {
            showNotification("Error : "+JSON.stringify(err), "bottom", "center", "danger");
            catchConnectionError(err);
          })
      }
    });
  }

  navigate(action: string, id?: number) {

    if (action.trim().toLowerCase() == 'edit') {
      this.router.navigate(['./', 'edit', id ? id : -1], { relativeTo: this.route });
    }
    else if (action.trim().toLowerCase() == 'add') {
      this.router.navigate(['./', 'add'], { relativeTo: this.route });
    }
  }


}
