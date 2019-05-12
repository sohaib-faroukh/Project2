import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../users.service';
import { isArray, isObject } from 'util';
import { User } from 'src/app/models/User';
import { confirm } from 'devextreme/ui/dialog';
import { DxDataGridComponent } from 'devextreme-angular';
import { extract_keys, catchConnectionError, showNotification } from 'src/app/additional/functions';

@Component({
  selector: 'app-browse-users',
  templateUrl: './browse-users.component.html',
  styleUrls: ['./browse-users.component.scss']
})
export class BrowseUsersComponent implements OnInit {

  Users: User[] = [];
  Keys: string[] = [];
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  constructor(private srv: UsersService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    let res = this.route.snapshot.data["Users"];

    console.log(res);

    this.Keys = extract_keys(res);
    console.log(this.Keys);
    this.Users = res;
  }






  deactivate(id: number) {
    var result = confirm("Are you sure?", "Delete Confirm");

    result.then((dialogResult) => {

      console.log(dialogResult);
      if (dialogResult == true) {
        this.srv.deactivate(id).subscribe(
          res => {
            if (res) {
              this.Users.splice(this.Users.findIndex(ele => ele.Id == id), 1);
              showNotification("Deleted succesfully", "bottom", "center", "success");
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



