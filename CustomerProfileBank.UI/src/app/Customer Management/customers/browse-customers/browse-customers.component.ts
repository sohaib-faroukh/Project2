import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { CustomersService } from '../customers.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-browse-customers',
  templateUrl: './browse-customers.component.html',
  styleUrls: ['./browse-customers.component.scss']
})
export class BrowseCustomersComponent implements OnInit {

  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  constructor(private srv: CustomersService, private router: Router, private route: ActivatedRoute) { }
  ngOnInit() {
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
