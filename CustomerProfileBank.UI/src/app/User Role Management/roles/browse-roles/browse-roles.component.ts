import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { Role } from 'src/app/models/Role';
import { RolesService } from '../roles.service';
import { Router, ActivatedRoute } from '@angular/router';
import { extract_keys } from 'src/app/additional/functions';
import { confirm } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-browse-roles',
  templateUrl: './browse-roles.component.html',
  styleUrls: ['./browse-roles.component.scss']
})
export class BrowseRolesComponent implements OnInit {

  Roles: Role[] = [];
  Keys: string[] = [];
  
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  constructor(private srv: RolesService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    let res = this.route.snapshot.data["Roles"];
    if (res) {
      this.Keys = extract_keys(res);
      console.log(this.Keys);
      this.Roles = res;
    }
  }






  deactivate(id: number) {
    var result = confirm("Are you sure?", "Delete Confirm");

    result.then((dialogResult) => {

      console.log(dialogResult);
      if (dialogResult == true) {
        this.srv.deactivate(id).subscribe(
          res => {
            this.Roles[this.Roles.findIndex(ele => ele.id == id)] = res;
            this.dataGrid.instance.refresh();
          },
          err => {
            console.log(err);
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
