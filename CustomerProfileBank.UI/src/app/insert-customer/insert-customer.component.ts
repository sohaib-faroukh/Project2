import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { showNotification } from '../additional/functions';
import { API_BASE_URL } from '../config/config.service';
import { InsertCustomerService } from './insert-customer.service';

@Component({
  selector: 'app-insert-customer',
  templateUrl: './insert-customer.component.html',
  styleUrls: ['./insert-customer.component.scss']
})
export class InsertCustomerComponent implements OnInit {

  public NationalNumber: number;
  public NationalNumber1: number;

  data: any;
  imagePreview: string;
  selectedFile: File;
  apiUrl: string = null;
  formData = new FormData();

  imgUrl:string;

  constructor(
    private srv: InsertCustomerService,
    private http: HttpClient,
    @Inject(API_BASE_URL) _apiUrl_: string) {
    this.apiUrl = _apiUrl_;
  }

  ngOnInit() {
  }

  onFileChange(event) {
    console.log(this.formData);
    this.selectedFile = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (_event_) => {
      this.imagePreview = reader.result.toString();
      this.formData.append("FingerPrintFile", this.selectedFile);
      this.imgUrl=reader.result.toString();
      
    };
    reader.readAsDataURL(this.selectedFile);
  }

  onUploadFile() {


    this.formData.append("NationalNumber",this.NationalNumber.toString())
    this.srv.uploadFileAndNatioNumber(this.formData).subscribe(
      res => {
        console.log(res);
        showNotification("Uploaded Successfully", "bottom", "center", "success");
      },
      err => {
        showNotification("Uploading error", "bottom", "center", "danger");
      })


  }


}
